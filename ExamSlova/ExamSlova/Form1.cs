using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using static System.Console;

namespace ExamSlova
{
    public partial class Form1 : Form
    {
        private List<string> words = null;
        private ConcurrentBag<Statistic> lstatistic = new ConcurrentBag<Statistic>();
        private ConcurrentBag<TopWords> lTopWords = new ConcurrentBag<TopWords>();
        private CancellationTokenSource cancellationTokenSource;
        private Task searchTask;
        private bool isPaused = false;
        private string resultsFolderPath;

        public Form1()
        {
            // Проверка единственного экземпляра уже сделана в Program.Main через именованный Mutex.
            InitializeComponent();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            Task task = Task.Run(() => FillDriveNodes());
            EnableControlButtons(true);

            FormClosing += Form1_FormClosing;

            if (Environment.GetCommandLineArgs().Length > 1)
            {
               
                string folderPath = Environment.GetCommandLineArgs()[1];
                if (Directory.Exists(folderPath))
                {
                    RunSearchCommandLine(folderPath);
                }
                else
                {
                    MessageBox.Show("Папка не найдена: " + folderPath);
                }
                Application.Exit();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (searchTask != null && !searchTask.IsCompleted)
            {
                cancellationTokenSource?.Cancel();
                searchTask.Wait(5000);
            }
        }
        private void RunSearchCommandLine(string folderPath)
        {
           
            if (words != null && words.Count > 0)
            {
                MessageBox.Show("Поиск в папке: " + folderPath);
                MessageBox.Show("Запретные слова: " + string.Join(", ", words));

                resultsFolderPath = "CommandLineResults";

                cancellationTokenSource = new CancellationTokenSource();
                CancellationToken token = cancellationTokenSource.Token;

                searchTask = Task.Run(() =>
                {
                    DirectoryInfo di = new DirectoryInfo(folderPath);
                    Search(di, token); 

                    GenerateReport();
                    Application.Exit();
                }, token);
            }
            else
            {
                MessageBox.Show("Запрещенные слова не загружено.");
            }
        }
        private void FillDriveNodes()
        {
            treeViewDirections.Nodes.Clear();
            treeViewDirections.Nodes.Clear();

            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    driveNode.Tag = drive;
                    GetNodeNext(driveNode, drive.Name);
                    UpdateTreeView(driveNode);
                }
            }
            catch (Exception) { }
        }
        private void UpdateTreeView(TreeNode tn)
        {
            if (treeViewDirections.InvokeRequired)
                treeViewDirections.Invoke(new Action<TreeNode>(UpdateTreeView), tn);
            else
                treeViewDirections.Nodes.Add(tn);
        }
        private void GetNodeNext(TreeNode tn, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                if (dirs.Length == 0) return;

                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    dirNode.Tag = dir;

                    GetNodeNext(dirNode, dir);
                    tn.Nodes.Add(dirNode);
                }
            }
            catch (Exception) { }
        }
        private void buttonFindWords_Click(object sender, EventArgs e)
        {
            FormFordWords fw = new FormFordWords(words);
            fw.WordsUpdated += OnWordsUpdated;
            fw.Show();
        }

        private void OnWordsUpdated(List<string> updatedWords)
        {
            words = updatedWords;
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxPapka.Text == null || string.IsNullOrEmpty(textBoxPapka.Text))
            {
                MessageBox.Show("Выберите папку для сохранения результатов!");
                return;
            }

            if (words == null|| words.Count == 0)
            {
                MessageBox.Show("Загрузите или введите запрещенные слова.");
                return;
            }

            TreeNode tn = treeViewDirections.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("Выберите, где будет проводиться поиск");
                return;
            }

            progressBar.Value = 0;
            listBoxFiles.Items.Clear();
            buttonStatistic.Visible = false;
            progressBar.Visible = true;
            labelFiles.Visible = true;

            resultsFolderPath = textBoxPapka.Text;  

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            isPaused = false;
            EnableControlButtons(false);

            searchTask = Task.Run(() =>
            {
                try
                {
                    lstatistic = new ConcurrentBag<Statistic>();
                    lTopWords = new ConcurrentBag<TopWords>();

                    DirectoryInfo di = new DirectoryInfo(tn.FullPath);
                    Search(di, token);

                    if (lstatistic.Count > 0)
                        UpdateButton(true);

                    if (!token.IsCancellationRequested)
                    {
                        GenerateReport();
                    }
                }
                finally
                {
                    // Единственное место, где показывается итог и освобождается CancellationTokenSource,
                    // независимо от того, завершился поиск сам или был отменён кнопкой "Отмена".
                    UpdateSearchCompleteUI();
                }
            }, token);

            await searchTask;
        }
        private void GenerateReport()
        {
            try
            {
                var topWordsReport = lTopWords.GroupBy(w => w.Word)
                                           .Select(g => new { Word = g.Key, Count = g.Sum(x => x.Count) })
                                           .OrderByDescending(g => g.Count)
                                           .Take(10)
                                           .ToList();
                StringBuilder report = new StringBuilder();
                report.AppendLine("Отчет о поиске запрещенных слов");
                report.AppendLine("Дата: " + DateTime.Now.ToString());
                report.AppendLine("========================================");
                report.AppendLine("Найденные файлы:");

                foreach (var stat in lstatistic)
                {
                    report.AppendLine($"Файл: {stat.PathFile}");
                    report.AppendLine($"Размер: {stat.Size} байт");
                    report.AppendLine($"Запрещенное слово: {stat.Word}");
                    report.AppendLine($"Количество замен: {stat.NumWordFound}");
                    report.AppendLine("----------------------------------------");
                }

                report.AppendLine("========================================");
                report.AppendLine("Топ-10 запрещенных слов:");

                foreach (var topWord in topWordsReport)
                {
                    report.AppendLine($"Слово: {topWord.Word}, Количество: {topWord.Count}");
                }
                string reportFilePath = Path.Combine(resultsFolderPath, "report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
                File.WriteAllText(reportFilePath, report.ToString(), Encoding.UTF8);
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        listBoxFiles.Items.Add("Отчет сохранен в: " + reportFilePath);
                    }));
                }
                else
                {
                    listBoxFiles.Items.Add("Отчет сохранен в: " + reportFilePath);
                }

                if (resultsFolderPath != null && Directory.Exists(resultsFolderPath))
                    System.Diagnostics.Process.Start("explorer.exe", resultsFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отчета: " + ex.Message);
            }
        }

        private void EnableControlButtons(bool startEnabled)
        {
           
            buttonStart.Enabled = startEnabled;
            buttonPause.Enabled = !startEnabled;
            buttonResume.Enabled = !startEnabled;
            buttonCancel.Enabled = !startEnabled;
        }


        private void UpdateButton(bool b)
        {
            if (buttonStatistic.InvokeRequired)
                buttonStatistic.Invoke(new Action<bool>(UpdateButton), b);

            else buttonStatistic.Visible = b;
        }
        private void Search(DirectoryInfo di, CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }


                DirectoryInfo[] directories = di.GetDirectories();

                foreach (DirectoryInfo dir in directories)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    while (isPaused && !token.IsCancellationRequested)
                    {
                        Thread.Sleep(100);
                    }

                    Search(dir, token);
                }


                if (directories.Count() == 0 || di.GetFiles().Count() > 0)
                {
                    if ((di.GetFiles().Count() / 2 * 100) < 100)
                        UpdateProgressBar(di.GetFiles().Count() / 2 * 100);

                    else
                        UpdateProgressBar(100);

                    FileInfo[] files = di.GetFiles();
                    Parallel.ForEach(files, new ParallelOptions { CancellationToken = token, MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        while (isPaused && !token.IsCancellationRequested)
                        {
                            Thread.Sleep(100);
                        }

                        ProcessFile(file, token);

                    });
                }
            }
            catch (OperationCanceledException)
            {           
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }
        private void ProcessFile(FileInfo file, CancellationToken token)
        {

            bool isFind = false;
            int cFound = 0;

            try
            {
                string fileText = File.ReadAllText(file.FullName);
                string originalFileText = fileText; 
                UpdateLable(file.FullName); 
                string replacedFileText = fileText;

                foreach (string word in words)
                {
                    if (token.IsCancellationRequested) return; 

                    string pattern = Regex.Escape(word); 
                    string replacement = new string('*', 7);

                    int wordCount = Regex.Matches(replacedFileText, pattern, RegexOptions.IgnoreCase).Count; 

                    if (wordCount > 0)
                    {
                        isFind = true;
                        cFound += wordCount;
                        replacedFileText = Regex.Replace(replacedFileText, pattern, replacement, RegexOptions.IgnoreCase); 
                    }


                    if (isFind)
                    {
                        UpdateList(file.FullName);
                        string copyPath = Path.Combine(resultsFolderPath, "newFiles");
                        if (!Directory.Exists(copyPath))
                        {
                            Directory.CreateDirectory(copyPath);
                        }
                        string destinationPath = Path.Combine(copyPath, file.Name);
                        try
                        {
                            File.Copy(file.FullName, destinationPath, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось скопировать файл: {ex.Message}"); 
                        }
                        string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 8);
                        string replacedFilePath = Path.Combine(resultsFolderPath, "newFiles", Path.GetFileNameWithoutExtension(file.Name) + "_replaced_" + uniqueSuffix + ".txt");
                        File.WriteAllText(replacedFilePath, replacedFileText, Encoding.UTF8);
                        lstatistic.Add(new Statistic(word, file.FullName, (int)file.Length, cFound));
                        lTopWords.Add(new TopWords(word, cFound));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Исключение при обработке файла {file.FullName}: {ex.Message}");
            }
        }
        private void UpdateSearchCompleteUI()
        {

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateSearchCompleteUI));
                return;
            }

            progressBar.Visible = false;
            labelFiles.Visible = false;
            EnableControlButtons(true);

            bool wasCancelled = cancellationTokenSource != null && cancellationTokenSource.IsCancellationRequested;
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;

            if (wasCancelled)
                MessageBox.Show("Поиск отменен.");
            else
                MessageBox.Show("Поиск завершен!");
        }
        private void UpdateProgressBar(int v)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, v))));
            }
            else
            {
                progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, v));
            }
        }  
        private void UpdateLable(string text)
        {
            if (labelFiles.InvokeRequired)
                labelFiles.Invoke(new Action<string>(UpdateLable), text);

            else
                labelFiles.Text = text;
        }
        private void UpdateList(string text)
        {
            if (listBoxFiles.InvokeRequired)
                listBoxFiles.Invoke(new Action<string>(UpdateList), text);

            else
                listBoxFiles.Items.Add(text);
        }
        private void buttonPapka_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = true;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPapka.Text = folderDialog.SelectedPath;
                }
            }
        }
        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm fs = new StatisticForm(lstatistic.ToList());
            fs.Show();
        }

        private async void buttonCancel_Click(object sender, EventArgs e)
        {
            // Освобождение CancellationTokenSource и сообщение об итоге поиска
            // делает UpdateSearchCompleteUI — она вызывается самим searchTask
            // в блоке finally, когда тот заметит отмену и завершится.
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }

            buttonCancel.Enabled = false;

            try
            {
                await searchTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене: {ex.Message}");
            }
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            isPaused = false;
            buttonPause.Enabled = true;
            buttonResume.Enabled = false;

        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            buttonPause.Enabled = false;
            buttonResume.Enabled = true;

        }

    }
}
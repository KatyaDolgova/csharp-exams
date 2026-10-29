using ExamMonitoring.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace ExamMonitoring
{
    public partial class FormReport : Form
    {
        private Form1 _form1;
        public FormReport(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void buttonKeys_Click(object sender, EventArgs e)
        {
            LoadLogFile("keystrokes.txt");
        }

        private void buttonProcesses_Click(object sender, EventArgs e)
        {
            LoadLogFile("processes.txt");
        }

        private void buttonViolations_Click(object sender, EventArgs e)
        {
            string violationsFolderPath = _form1.GetLogFilePath();
            if (Directory.Exists(violationsFolderPath))
            {
                listBoxReport.Items.Clear();

                AddReportFiles(violationsFolderPath, "violation_*.txt", "Клавиатура");
                AddReportFiles(violationsFolderPath, "banned_app_*.txt", "Запуск приложения");
            }
            else
            {
                MessageBox.Show("Папка с нарушениями не найдена");
            }
        }

        private void AddReportFiles(string folder, string pattern, string kind)
        {
            foreach (string file in Directory.GetFiles(folder, pattern))
            {
                listBoxReport.Items.Add("--------------------");
                listBoxReport.Items.Add($"Файл: {Path.GetFileName(file)} ({kind})");
                try
                {
                    foreach (string line in File.ReadAllLines(file))
                    {
                        listBoxReport.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    listBoxReport.Items.Add($"Ошибка загрузки файла {Path.GetFileName(file)}: {ex.Message}");
                }
            }
        }

        private void LoadLogFile(string filename)
        {
            string logPath = _form1.GetLogFilePath();
            string filePath = Path.Combine(logPath, filename);

            listBoxReport.Items.Clear();

            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        listBoxReport.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла с логами: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл лога не найден", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

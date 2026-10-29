
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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;

namespace ExamMonitoring
{
    public partial class Form1 : Form
    {
        private const int KEYSTROKE_BUFFER_SIZE = 50;
        public string _logFilePath = "logs";

        public bool _logKeyStrokes = false;
        public bool _moderationEnabled = false;
        public List<string> _forbiddenWords = new List<string>();
        public List<string> _bannedApps = new List<string>();

        private StringBuilder _keyStrokeBuffer = new StringBuilder();
        private bool _monitoringActive = false;
        private ProcessMonitor _processMonitor;
        private DateTime _monitoringStartTime;

        public event EventHandler<StringEventArgs> ActivityLogged;

        //
        private IntPtr hHook = IntPtr.Zero;
        private WinEventDelegate procDelegate = null;
        private object _processHookLock = new object();

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            QueryLimitedInformation = 0x00001000
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool QueryFullProcessImageName(IntPtr hProcess, int dwFlags, StringBuilder lpExeName, ref int lpdwSize);

        //

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static Form1 _instance;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                try
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    string key = ((Keys)vkCode).ToString();
                    _instance?.ProcessKeyStroke(key);
                }
                catch (Exception)
                {
                    // исключение внутри хука нельзя пробрасывать наружу: система отключит хук
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public Form1()
        {
            InitializeComponent();
            _instance = this;
            EnsureLogDirectoryExists();
            LoadSettings();
            _processMonitor = new ProcessMonitor(this);

            ActivityLogged += LogActivity;
            btStopMonitoring.Enabled = false;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (_monitoringActive)
            {
                StopMonitoring();
            }
            _instance = null;
        }
        public void EnsureLogDirectoryExists()
        {
            if (!Directory.Exists(_logFilePath))
            {
                Directory.CreateDirectory(_logFilePath);
            }
        }
        public void LoadSettings()
        {
            try
            {
                ApplySettings(AppSettings.Load(out bool created));
                if (created)
                {
                    MessageBox.Show("Файл настроек не найден. Файл settings.txt со значениями по умолчанию был создан. Пожалуйста, настройте его.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ApplySettings(AppSettings settings)
        {
            _logKeyStrokes = settings.LogKeyStrokes;
            _moderationEnabled = settings.ModerationEnabled;
            _logFilePath = settings.ResolvedLogPath;
            _forbiddenWords = settings.ForbiddenWordList;
            _bannedApps = settings.BannedProcessList;
            EnsureLogDirectoryExists();
        }

        public string GetLogFilePath()
        {
            return _logFilePath;
        }
        public virtual void OnActivityLogged(object sender, StringEventArgs e)
        {
            ActivityLogged?.Invoke(sender, e);
        }

        public void ProcessKeyStroke(string key)
        {
            if (!_monitoringActive) return;

            if (_logKeyStrokes)
            {
                LogKeyStroke(key);
            }

            _keyStrokeBuffer.Append(key);
            if (_keyStrokeBuffer.Length > KEYSTROKE_BUFFER_SIZE)
            {
                _keyStrokeBuffer.Remove(0, _keyStrokeBuffer.Length - KEYSTROKE_BUFFER_SIZE);
            }

            if (_moderationEnabled)
            {
                string bufferContent = _keyStrokeBuffer.ToString().ToLower();
                foreach (string word in _forbiddenWords)
                {
                    if (bufferContent.Contains(word))
                    {
                        OnActivityLogged(this, new StringEventArgs { StringValue = $"Обнаружено запрещенное слово: {word}" });
                        CreateViolationReport(word, bufferContent);

                        _keyStrokeBuffer.Clear();
                        break;
                    }
                }
            }
        }
        private void CreateViolationReport(string word, string content)
        {
            string reportFileName = $"violation_{DateTime.Now:yyyyMMdd_HHmmss_fff}.txt";
            string reportPath = Path.Combine(_logFilePath, reportFileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(reportPath))
                {
                    writer.WriteLine($"Запрещенное слово: {word}");
                    writer.WriteLine($"Обнаружено в тексте: {content}");
                }
                OnActivityLogged(this, new StringEventArgs { StringValue = $"Создан отчет о нарушении: {reportFileName}" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета о нарушении: {ex.Message}");
            }
        }
        private void LogKeyStroke(string key)
        {
            string logFilePath = Path.Combine(_logFilePath, "keystrokes.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Нажата клавиша: {key}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в файл keystrokes.txt: {ex.Message}");
            }
        }
        private void LogActivity(object sender, StringEventArgs e)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {e.StringValue}\r\n";
            AppendToActivityLog(logEntry);
        }
        private void AppendToActivityLog(string logEntry)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendToActivityLog), logEntry);
                return;
            }

            listBox1.Items.Add(logEntry);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        public List<string> GetBannedApps()
        {
            return _bannedApps.ToList();
        }
        public class StringEventArgs : EventArgs
        {
            public string StringValue { get; set; }
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            FormSetting settingsForm = new FormSetting(this);
            settingsForm.ShowDialog();
        }
        private void Report_Click(object sender, EventArgs e)
        {
            FormReport reportForm = new FormReport(this);
            reportForm.Show();
        }
        private void btStartMonitoring_Click(object sender, EventArgs e)
        {
            if (!_monitoringActive)
            {
                _monitoringActive = true;
                _hookID = SetHook(_proc);

                // ProcessMonitor.Start() сам запускает отслеживание смены окон (StartProcessTracking)
                _processMonitor.Start();

                btStartMonitoring.Enabled = false;
                btStopMonitoring.Enabled = true;
                _monitoringStartTime = DateTime.Now;

            }
            else
            {
                MessageBox.Show("Мониторинг уже активен", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btStopMonitoring_Click(object sender, EventArgs e)
        {
            StopMonitoring();
        }
        private void StopMonitoring()
        {
            if (_monitoringActive)
            {
                _monitoringActive = false;
                if (_processMonitor != null)
                {
                    _processMonitor.Stop();
                }
                StopProcessTracking();
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;

                btStartMonitoring.Enabled = true;
                btStopMonitoring.Enabled = false;
            }
            else
            {
                MessageBox.Show("Мониторинг ещё не активен", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void StartProcessTracking()
        {
            lock (_processHookLock)
            {
                if (procDelegate == null)
                {
                    procDelegate = new WinEventDelegate(WinEventProc);
                    hHook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);

                    if (hHook == IntPtr.Zero)
                    {
                        MessageBox.Show("Ошибка: Не удалось установить Wineventhook. Код ошибки: " + Marshal.GetLastWin32Error());

                    }
                }
            }
        }

        public void StopProcessTracking()
        {
            lock (_processHookLock)
            {
                if (hHook != IntPtr.Zero)
                {
                    bool unhooked = UnhookWinEvent(hHook);
                    if (!unhooked)
                    {
                        MessageBox.Show("Ошибка: Не удалось прекратить WinEventHook. Код ошибки: " + Marshal.GetLastWin32Error());
                    }
                    hHook = IntPtr.Zero;
                    procDelegate = null;
                }
            }
        }

        private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            try
            {
                uint processId;
                GetWindowThreadProcessId(hwnd, out processId);
                if (processId == 0) return;

                IntPtr processHandle = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, (int)processId);
                if (processHandle == IntPtr.Zero) return;

                string processName;
                try
                {
                    int capacity = 2000;
                    StringBuilder stringBuilder = new StringBuilder(capacity);
                    if (!QueryFullProcessImageName(processHandle, 0, stringBuilder, ref capacity)) return;

                    processName = Path.GetFileName(stringBuilder.ToString());
                }
                finally
                {
                    CloseHandle(processHandle);
                }

                if (!string.IsNullOrEmpty(processName))
                {
                    bool isBanned = _bannedApps.Any(bannedApp => processName.Equals(bannedApp, StringComparison.OrdinalIgnoreCase));
                    if (isBanned)
                    {
                        CreateBannedAppReport(processName);
                    }
                    LogProcessStart(processName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка WinEventProc: {ex.Message}");
            }
        }
        private void CreateBannedAppReport(string appName)
        {
            string reportFileName = $"banned_app_{DateTime.Now:yyyyMMdd_HHmmss_fff}.txt";
            string reportPath = Path.Combine(_logFilePath, reportFileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(reportPath))
                {
                    writer.WriteLine($"Запрещенное приложение запущено: {appName}");
                    writer.WriteLine($"Время запуска: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                }
                OnActivityLogged(this, new StringEventArgs { StringValue = $"Создан отчет о запуске запрещенного приложения: {reportFileName}" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета о запрещенном приложении: {ex.Message}");
            }
        }
        private void LogProcessStart(string processName)
        {
            string logFilePath = Path.Combine(_logFilePath, "processes.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Запущено приложение: {processName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в файл processes.txt: {ex.Message}");
            }
        }
    }
}

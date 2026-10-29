using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamMonitoring
{

    public class ProcessMonitor
    {
        private Form1 _form1;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private Task _monitoringTask;
        private bool _isRunning = false;

        public ProcessMonitor(Form1 form1)
        {
            _form1 = form1;
        }

        public void Start()
        {
            _isRunning = true;
            _form1.StartProcessTracking();
            _monitoringTask = Task.Run(() => MonitorProcesses(_cts.Token));
        }
        public void Stop()
        {
            if (!_isRunning)
                return;

            _isRunning = false;
            _cts.Cancel();
            _form1.StopProcessTracking();

            try
            {
                _monitoringTask.Wait(5000);
                if (!_monitoringTask.IsCompleted)
                {
                    MessageBox.Show("Задача мониторинга процесса не была выполнена в течение заданного времени ожидания.");
                }
            }
            catch (AggregateException ex)
            {
                foreach (var innerException in ex.InnerExceptions)
                {
                    MessageBox.Show($"Ошибка при остановке задачи мониторинга: {innerException.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при остановке задачи мониторинга: {ex.Message}");
            }
            finally
            {
                _cts.Dispose();
                _cts = new CancellationTokenSource();
            }
        }

        // Вызовы в UI-поток идут через BeginInvoke: Stop() ждёт эту задачу в UI-потоке,
        // поэтому синхронный Invoke мог бы привести к взаимной блокировке.
        private void RunOnUi(Action action)
        {
            if (_form1.IsDisposed || !_form1.IsHandleCreated) return;
            _form1.BeginInvoke(action);
        }

        private async Task MonitorProcesses(CancellationToken token)
        {
            int ownProcessId = Process.GetCurrentProcess().Id;

            while (!token.IsCancellationRequested && _isRunning)
            {
                try
                {
                    var banned = new HashSet<string>(
                        _form1.GetBannedApps().Select(app => Path.GetFileNameWithoutExtension(app)),
                        StringComparer.OrdinalIgnoreCase);

                    if (banned.Count > 0)
                    {
                        foreach (Process process in Process.GetProcesses())
                        {
                            using (process)
                            {
                                token.ThrowIfCancellationRequested();

                                if (process.Id == ownProcessId || !banned.Contains(process.ProcessName))
                                    continue;

                                string name = process.ProcessName;
                                try
                                {
                                    process.Kill();
                                    string message = $"Запрещенный процесс '{name}' был прекращен.";
                                    RunOnUi(() =>
                                    {
                                        _form1.OnActivityLogged(this, new Form1.StringEventArgs { StringValue = message });
                                    });
                                }
                                catch (Exception ex)
                                {
                                    string error = $"Ошибка прекращения процесса '{name}': {ex.Message}";
                                    RunOnUi(() => MessageBox.Show(error));
                                }
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    string error = $"Ошибка мониторинга процессов: {ex.Message}";
                    RunOnUi(() => MessageBox.Show(error));
                }

                try
                {
                    await Task.Delay(5000, token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }

    }
}

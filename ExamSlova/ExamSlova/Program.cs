using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSlova
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var mutex = new Mutex(true, "ExamSlova"))
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("Приложение уже запущено!");
                }
            }
        }
    }
}

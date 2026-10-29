using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExamMonitoring
{
    public class AppSettings
    {
        public static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.txt");

        public bool LogKeyStrokes { get; set; }
        public bool ModerationEnabled { get; set; }
        public string LogFilePath { get; set; } = "logs";
        public string ForbiddenWords { get; set; } = "";
        public string BannedProcesses { get; set; } = "";

        public List<string> ForbiddenWordList => SplitList(ForbiddenWords).Select(s => s.ToLower()).ToList();
        public List<string> BannedProcessList => SplitList(BannedProcesses);

        /// <summary>
        /// Загружает настройки. Если файла нет, создаёт его со значениями по умолчанию
        /// и возвращает их; в этом случае <paramref name="created"/> = true.
        /// </summary>
        public static AppSettings Load(out bool created)
        {
            created = false;
            if (!File.Exists(FilePath))
            {
                var defaults = new AppSettings();
                defaults.Save();
                created = true;
                return defaults;
            }

            var settings = new AppSettings();
            foreach (string line in File.ReadAllLines(FilePath))
            {
                int separator = line.IndexOf('=');
                if (separator < 0) continue;

                string key = line.Substring(0, separator).Trim();
                string value = line.Substring(separator + 1).Trim();
                switch (key)
                {
                    case "LogKeyStrokes": settings.LogKeyStrokes = bool.Parse(value); break;
                    case "ModerationEnabled": settings.ModerationEnabled = bool.Parse(value); break;
                    case "LogFilePath": if (value.Length > 0) settings.LogFilePath = value; break;
                    case "ForbiddenWords": settings.ForbiddenWords = value; break;
                    case "BannedProcesses": settings.BannedProcesses = value; break;
                }
            }
            return settings;
        }

        public void Save()
        {
            File.WriteAllLines(FilePath, new[]
            {
                $"LogKeyStrokes={LogKeyStrokes}",
                $"ModerationEnabled={ModerationEnabled}",
                $"LogFilePath={LogFilePath}",
                $"ForbiddenWords={ForbiddenWords}",
                $"BannedProcesses={BannedProcesses}",
            });
        }

        /// <summary>Относительный путь к логам считается от папки приложения.</summary>
        public string ResolvedLogPath =>
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFilePath));

        private static IEnumerable<string> SplitList(string value)
        {
            return value.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0);
        }
    }
}

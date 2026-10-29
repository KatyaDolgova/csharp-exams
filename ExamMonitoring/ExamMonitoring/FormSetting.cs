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

namespace ExamMonitoring
{
    public partial class FormSetting : Form
    {
        private Form1 _form1;

        public FormSetting(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            LoadSettings();

        }
        private void LoadSettings()
        {
            try
            {
                AppSettings settings = AppSettings.Load(out bool created);

                checkBoxKeys.Checked = settings.LogKeyStrokes;
                checkBoxModerate.Checked = settings.ModerationEnabled;
                textBoxPath.Text = settings.LogFilePath;
                textBoxForbiddenWords.Text = settings.ForbiddenWords;
                textBoxBanned.Text = settings.BannedProcesses;

                if (created)
                {
                    MessageBox.Show("Файл настроек не найден. Файл settings.txt со значениями по умолчанию был создан. Пожалуйста, настройте его.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new AppSettings
                {
                    LogKeyStrokes = checkBoxKeys.Checked,
                    ModerationEnabled = checkBoxModerate.Checked,
                    LogFilePath = string.IsNullOrWhiteSpace(textBoxPath.Text) ? "logs" : textBoxPath.Text.Trim(),
                    ForbiddenWords = textBoxForbiddenWords.Text,
                    BannedProcesses = textBoxBanned.Text,
                };
                settings.Save();
                _form1.ApplySettings(settings);

                MessageBox.Show("Настройки успешно сохранены.", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении настроек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

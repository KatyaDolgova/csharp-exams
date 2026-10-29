namespace ExamMonitoring
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Settings = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.btStartMonitoring = new System.Windows.Forms.Button();
            this.btStopMonitoring = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Settings.Location = new System.Drawing.Point(27, 35);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(204, 69);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Настройки";
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Report
            // 
            this.Report.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Report.Location = new System.Drawing.Point(27, 110);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(204, 73);
            this.Report.TabIndex = 2;
            this.Report.Text = "Посмотреть отчет";
            this.Report.UseVisualStyleBackColor = false;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // btStartMonitoring
            // 
            this.btStartMonitoring.BackColor = System.Drawing.Color.Beige;
            this.btStartMonitoring.Location = new System.Drawing.Point(27, 215);
            this.btStartMonitoring.Name = "btStartMonitoring";
            this.btStartMonitoring.Size = new System.Drawing.Size(204, 67);
            this.btStartMonitoring.TabIndex = 3;
            this.btStartMonitoring.Text = "Начать мониторинг";
            this.btStartMonitoring.UseVisualStyleBackColor = false;
            this.btStartMonitoring.Click += new System.EventHandler(this.btStartMonitoring_Click);
            // 
            // btStopMonitoring
            // 
            this.btStopMonitoring.BackColor = System.Drawing.Color.LavenderBlush;
            this.btStopMonitoring.Location = new System.Drawing.Point(27, 288);
            this.btStopMonitoring.Name = "btStopMonitoring";
            this.btStopMonitoring.Size = new System.Drawing.Size(204, 71);
            this.btStopMonitoring.TabIndex = 4;
            this.btStopMonitoring.Text = "Завершить мониторинг";
            this.btStopMonitoring.UseVisualStyleBackColor = false;
            this.btStopMonitoring.Click += new System.EventHandler(this.btStopMonitoring_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(265, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(726, 324);
            this.listBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1060, 401);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btStopMonitoring);
            this.Controls.Add(this.btStartMonitoring);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.Settings);
            this.Name = "Form1";
            this.Text = "Главное окно";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.Button btStartMonitoring;
        private System.Windows.Forms.Button btStopMonitoring;
        private System.Windows.Forms.ListBox listBox1;
    }
}


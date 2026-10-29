namespace ExamMonitoring
{
    partial class FormReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxReport = new System.Windows.Forms.ListBox();
            this.buttonKeys = new System.Windows.Forms.Button();
            this.buttonProcesses = new System.Windows.Forms.Button();
            this.buttonViolations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxReport
            // 
            this.listBoxReport.FormattingEnabled = true;
            this.listBoxReport.ItemHeight = 20;
            this.listBoxReport.Location = new System.Drawing.Point(12, 12);
            this.listBoxReport.Name = "listBoxReport";
            this.listBoxReport.Size = new System.Drawing.Size(662, 324);
            this.listBoxReport.TabIndex = 0;
            // 
            // buttonKeys
            // 
            this.buttonKeys.BackColor = System.Drawing.Color.LemonChiffon;
            this.buttonKeys.Location = new System.Drawing.Point(12, 362);
            this.buttonKeys.Name = "buttonKeys";
            this.buttonKeys.Size = new System.Drawing.Size(200, 98);
            this.buttonKeys.TabIndex = 1;
            this.buttonKeys.Text = "Просмотр нажатий клавиш";
            this.buttonKeys.UseVisualStyleBackColor = false;
            this.buttonKeys.Click += new System.EventHandler(this.buttonKeys_Click);
            // 
            // buttonProcesses
            // 
            this.buttonProcesses.BackColor = System.Drawing.Color.LemonChiffon;
            this.buttonProcesses.Location = new System.Drawing.Point(231, 362);
            this.buttonProcesses.Name = "buttonProcesses";
            this.buttonProcesses.Size = new System.Drawing.Size(218, 98);
            this.buttonProcesses.TabIndex = 2;
            this.buttonProcesses.Text = " Просмотр процессов";
            this.buttonProcesses.UseVisualStyleBackColor = false;
            this.buttonProcesses.Click += new System.EventHandler(this.buttonProcesses_Click);
            // 
            // buttonViolations
            // 
            this.buttonViolations.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.buttonViolations.Location = new System.Drawing.Point(465, 362);
            this.buttonViolations.Name = "buttonViolations";
            this.buttonViolations.Size = new System.Drawing.Size(209, 98);
            this.buttonViolations.TabIndex = 3;
            this.buttonViolations.Text = "Просмотр нарушений";
            this.buttonViolations.UseVisualStyleBackColor = false;
            this.buttonViolations.Click += new System.EventHandler(this.buttonViolations_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(696, 498);
            this.Controls.Add(this.buttonViolations);
            this.Controls.Add(this.buttonProcesses);
            this.Controls.Add(this.buttonKeys);
            this.Controls.Add(this.listBoxReport);
            this.Name = "FormReport";
            this.Text = "Результаты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxReport;
        private System.Windows.Forms.Button buttonKeys;
        private System.Windows.Forms.Button buttonProcesses;
        private System.Windows.Forms.Button buttonViolations;
    }
}
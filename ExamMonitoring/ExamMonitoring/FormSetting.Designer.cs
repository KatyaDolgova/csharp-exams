namespace ExamMonitoring
{
    partial class FormSetting
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
            this.checkBoxKeys = new System.Windows.Forms.CheckBox();
            this.checkBoxModerate = new System.Windows.Forms.CheckBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxForbiddenWords = new System.Windows.Forms.TextBox();
            this.textBoxBanned = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxKeys
            // 
            this.checkBoxKeys.AutoSize = true;
            this.checkBoxKeys.Location = new System.Drawing.Point(12, 107);
            this.checkBoxKeys.Name = "checkBoxKeys";
            this.checkBoxKeys.Size = new System.Drawing.Size(353, 24);
            this.checkBoxKeys.TabIndex = 0;
            this.checkBoxKeys.Text = "Регистрировать запущенные приложения";
            this.checkBoxKeys.UseVisualStyleBackColor = true;
            // 
            // checkBoxModerate
            // 
            this.checkBoxModerate.AutoSize = true;
            this.checkBoxModerate.Location = new System.Drawing.Point(12, 45);
            this.checkBoxModerate.Name = "checkBoxModerate";
            this.checkBoxModerate.Size = new System.Drawing.Size(290, 24);
            this.checkBoxModerate.TabIndex = 1;
            this.checkBoxModerate.Text = "Регистрировать нажатия клавиш";
            this.checkBoxModerate.UseVisualStyleBackColor = true;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 282);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(288, 26);
            this.textBoxPath.TabIndex = 2;
            // 
            // textBoxForbiddenWords
            // 
            this.textBoxForbiddenWords.Location = new System.Drawing.Point(12, 164);
            this.textBoxForbiddenWords.Name = "textBoxForbiddenWords";
            this.textBoxForbiddenWords.Size = new System.Drawing.Size(288, 26);
            this.textBoxForbiddenWords.TabIndex = 4;
            // 
            // textBoxBanned
            // 
            this.textBoxBanned.Location = new System.Drawing.Point(12, 218);
            this.textBoxBanned.Name = "textBoxBanned";
            this.textBoxBanned.Size = new System.Drawing.Size(288, 26);
            this.textBoxBanned.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Запрещенные слова (через запятую)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Запрещенные приложения (через запятую)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя файла лога";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonSave.Location = new System.Drawing.Point(503, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(154, 89);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить настройки";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(671, 364);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBanned);
            this.Controls.Add(this.textBoxForbiddenWords);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.checkBoxModerate);
            this.Controls.Add(this.checkBoxKeys);
            this.Name = "FormSetting";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxKeys;
        private System.Windows.Forms.CheckBox checkBoxModerate;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxForbiddenWords;
        private System.Windows.Forms.TextBox textBoxBanned;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSave;
    }
}
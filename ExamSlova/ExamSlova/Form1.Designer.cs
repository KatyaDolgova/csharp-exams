namespace ExamSlova
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
            this.buttonFindWords = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPapka = new System.Windows.Forms.Button();
            this.textBoxPapka = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonStatistic = new System.Windows.Forms.Button();
            this.treeViewDirections = new System.Windows.Forms.TreeView();
            this.labelFiles = new System.Windows.Forms.Label();
            this.buttonResume = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFindWords
            // 
            this.buttonFindWords.Location = new System.Drawing.Point(826, 25);
            this.buttonFindWords.Name = "buttonFindWords";
            this.buttonFindWords.Size = new System.Drawing.Size(215, 75);
            this.buttonFindWords.TabIndex = 0;
            this.buttonFindWords.Text = "Ввести запрещенные слова";
            this.buttonFindWords.UseVisualStyleBackColor = true;
            this.buttonFindWords.Click += new System.EventHandler(this.buttonFindWords_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonStart.Location = new System.Drawing.Point(826, 240);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(215, 83);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPapka
            // 
            this.buttonPapka.Location = new System.Drawing.Point(826, 106);
            this.buttonPapka.Name = "buttonPapka";
            this.buttonPapka.Size = new System.Drawing.Size(215, 71);
            this.buttonPapka.TabIndex = 2;
            this.buttonPapka.Text = "Выбрать папку для копирования";
            this.buttonPapka.UseVisualStyleBackColor = true;
            this.buttonPapka.Click += new System.EventHandler(this.buttonPapka_Click);
            // 
            // textBoxPapka
            // 
            this.textBoxPapka.Location = new System.Drawing.Point(826, 194);
            this.textBoxPapka.Name = "textBoxPapka";
            this.textBoxPapka.ReadOnly = true;
            this.textBoxPapka.Size = new System.Drawing.Size(215, 26);
            this.textBoxPapka.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 447);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1011, 53);
            this.progressBar.TabIndex = 4;
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 20;
            this.listBoxFiles.Location = new System.Drawing.Point(319, 25);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(489, 344);
            this.listBoxFiles.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Coral;
            this.buttonCancel.Location = new System.Drawing.Point(676, 385);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 51);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Остановить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonStatistic
            // 
            this.buttonStatistic.Location = new System.Drawing.Point(826, 329);
            this.buttonStatistic.Name = "buttonStatistic";
            this.buttonStatistic.Size = new System.Drawing.Size(215, 43);
            this.buttonStatistic.TabIndex = 7;
            this.buttonStatistic.Text = "Статистика";
            this.buttonStatistic.UseVisualStyleBackColor = true;
            this.buttonStatistic.Click += new System.EventHandler(this.buttonStatistic_Click);
            // 
            // treeViewDirections
            // 
            this.treeViewDirections.Location = new System.Drawing.Point(26, 82);
            this.treeViewDirections.Name = "treeViewDirections";
            this.treeViewDirections.Size = new System.Drawing.Size(273, 333);
            this.treeViewDirections.TabIndex = 8;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Location = new System.Drawing.Point(22, 524);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(0, 20);
            this.labelFiles.TabIndex = 9;
            // 
            // buttonResume
            // 
            this.buttonResume.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.buttonResume.Location = new System.Drawing.Point(528, 385);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(142, 51);
            this.buttonResume.TabIndex = 10;
            this.buttonResume.Text = "Возобновить";
            this.buttonResume.UseVisualStyleBackColor = false;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.Color.Moccasin;
            this.buttonPause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPause.Location = new System.Drawing.Point(389, 385);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(133, 51);
            this.buttonPause.TabIndex = 11;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 60);
            this.label1.TabIndex = 12;
            this.label1.Text = "Подождите загрузку \r\nнакопителей информации \r\nи выберите нужный:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.treeViewDirections);
            this.Controls.Add(this.buttonStatistic);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxPapka);
            this.Controls.Add(this.buttonPapka);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFindWords);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindWords;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPapka;
        private System.Windows.Forms.TextBox textBoxPapka;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonStatistic;
        private System.Windows.Forms.TreeView treeViewDirections;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label label1;
    }
}


namespace ExamSlova
{
    partial class FormFordWords
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
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.listBoxWords = new System.Windows.Forms.ListBox();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.buttonDelWord = new System.Windows.Forms.Button();
            this.buttonAddFromFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(16, 47);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(322, 26);
            this.textBoxWord.TabIndex = 0;
            // 
            // listBoxWords
            // 
            this.listBoxWords.FormattingEnabled = true;
            this.listBoxWords.ItemHeight = 20;
            this.listBoxWords.Location = new System.Drawing.Point(16, 93);
            this.listBoxWords.Name = "listBoxWords";
            this.listBoxWords.Size = new System.Drawing.Size(322, 364);
            this.listBoxWords.TabIndex = 1;
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonAddWord.Location = new System.Drawing.Point(370, 58);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(140, 82);
            this.buttonAddWord.TabIndex = 2;
            this.buttonAddWord.Text = "добавить слово";
            this.buttonAddWord.UseVisualStyleBackColor = false;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // buttonDelWord
            // 
            this.buttonDelWord.BackColor = System.Drawing.Color.LightPink;
            this.buttonDelWord.Location = new System.Drawing.Point(370, 243);
            this.buttonDelWord.Name = "buttonDelWord";
            this.buttonDelWord.Size = new System.Drawing.Size(140, 102);
            this.buttonDelWord.TabIndex = 3;
            this.buttonDelWord.Text = "удалить слово (нажмите на него в списке)";
            this.buttonDelWord.UseVisualStyleBackColor = false;
            this.buttonDelWord.Click += new System.EventHandler(this.buttonDelWord_Click);
            // 
            // buttonAddFromFile
            // 
            this.buttonAddFromFile.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonAddFromFile.Location = new System.Drawing.Point(370, 146);
            this.buttonAddFromFile.Name = "buttonAddFromFile";
            this.buttonAddFromFile.Size = new System.Drawing.Size(140, 91);
            this.buttonAddFromFile.TabIndex = 4;
            this.buttonAddFromFile.Text = "загрузить слова из файла";
            this.buttonAddFromFile.UseVisualStyleBackColor = false;
            this.buttonAddFromFile.Click += new System.EventHandler(this.buttonAddFromFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите слово:";
            // 
            // FormFordWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddFromFile);
            this.Controls.Add(this.buttonDelWord);
            this.Controls.Add(this.buttonAddWord);
            this.Controls.Add(this.listBoxWords);
            this.Controls.Add(this.textBoxWord);
            this.Name = "FormFordWords";
            this.Text = "FormFordWords";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.ListBox listBoxWords;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.Button buttonDelWord;
        private System.Windows.Forms.Button buttonAddFromFile;
        private System.Windows.Forms.Label label1;
    }
}
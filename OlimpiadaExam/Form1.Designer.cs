namespace OlimpiadaExam
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
            this.TableResults = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.работаСТаблицамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.олимпиадыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВидыСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СоревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.участникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxOlimpiada = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.comboBoxSports = new System.Windows.Forms.ComboBox();
            this.MedalistsSport = new System.Windows.Forms.Button();
            this.MedalCountCountry = new System.Windows.Forms.Button();
            this.OlympicTeamCountry = new System.Windows.Forms.Button();
            this.MostFrequentHostCountry = new System.Windows.Forms.Button();
            this.AthleteMostGoldMedals = new System.Windows.Forms.Button();
            this.CountryMostGoldMedals = new System.Windows.Forms.Button();
            this.PerformanceStatsCountry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TableResults)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableResults
            // 
            this.TableResults.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.TableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableResults.Location = new System.Drawing.Point(15, 54);
            this.TableResults.Name = "TableResults";
            this.TableResults.RowHeadersWidth = 62;
            this.TableResults.RowTemplate.Height = 28;
            this.TableResults.Size = new System.Drawing.Size(853, 452);
            this.TableResults.TabIndex = 0;
            this.TableResults.UseWaitCursor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.IndianRed;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСТаблицамиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1423, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // работаСТаблицамиToolStripMenuItem
            // 
            this.работаСТаблицамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.олимпиадыToolStripMenuItem,
            this.ВидыСпортаToolStripMenuItem,
            this.СоревнованияToolStripMenuItem,
            this.участникиToolStripMenuItem,
            this.результатыToolStripMenuItem,
            this.всеДанныеToolStripMenuItem});
            this.работаСТаблицамиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.работаСТаблицамиToolStripMenuItem.Name = "работаСТаблицамиToolStripMenuItem";
            this.работаСТаблицамиToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.работаСТаблицамиToolStripMenuItem.Text = "Работа с таблицами";
            // 
            // олимпиадыToolStripMenuItem
            // 
            this.олимпиадыToolStripMenuItem.Name = "олимпиадыToolStripMenuItem";
            this.олимпиадыToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.олимпиадыToolStripMenuItem.Text = "Олимпиады";
            this.олимпиадыToolStripMenuItem.Click += new System.EventHandler(this.олимпиадыToolStripMenuItem_Click);
            // 
            // ВидыСпортаToolStripMenuItem
            // 
            this.ВидыСпортаToolStripMenuItem.Name = "ВидыСпортаToolStripMenuItem";
            this.ВидыСпортаToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ВидыСпортаToolStripMenuItem.Text = "Виды спорта";
            this.ВидыСпортаToolStripMenuItem.Click += new System.EventHandler(this.ВидыСпортаToolStripMenuItem_Click);
            // 
            // СоревнованияToolStripMenuItem
            // 
            this.СоревнованияToolStripMenuItem.Name = "СоревнованияToolStripMenuItem";
            this.СоревнованияToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.СоревнованияToolStripMenuItem.Text = "Соревнования";
            this.СоревнованияToolStripMenuItem.Click += new System.EventHandler(this.СоревнованияToolStripMenuItem_Click);
            // 
            // участникиToolStripMenuItem
            // 
            this.участникиToolStripMenuItem.Name = "участникиToolStripMenuItem";
            this.участникиToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.участникиToolStripMenuItem.Text = "Участники";
            this.участникиToolStripMenuItem.Click += new System.EventHandler(this.участникиToolStripMenuItem_Click);
            // 
            // результатыToolStripMenuItem
            // 
            this.результатыToolStripMenuItem.Name = "результатыToolStripMenuItem";
            this.результатыToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.результатыToolStripMenuItem.Text = "Результаты";
            this.результатыToolStripMenuItem.Click += new System.EventHandler(this.результатыToolStripMenuItem_Click);
            // 
            // всеДанныеToolStripMenuItem
            // 
            this.всеДанныеToolStripMenuItem.Name = "всеДанныеToolStripMenuItem";
            this.всеДанныеToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.всеДанныеToolStripMenuItem.Text = "Все данные";
            this.всеДанныеToolStripMenuItem.Click += new System.EventHandler(this.всеДанныеToolStripMenuItem_Click);
            // 
            // comboBoxOlimpiada
            // 
            this.comboBoxOlimpiada.FormattingEnabled = true;
            this.comboBoxOlimpiada.Location = new System.Drawing.Point(265, 537);
            this.comboBoxOlimpiada.Name = "comboBoxOlimpiada";
            this.comboBoxOlimpiada.Size = new System.Drawing.Size(121, 28);
            this.comboBoxOlimpiada.TabIndex = 3;
            this.comboBoxOlimpiada.UseWaitCursor = true;
            this.comboBoxOlimpiada.SelectedIndexChanged += new System.EventHandler(this.comboBoxOlimpiada_SelectedIndexChanged);
            this.comboBoxOlimpiada.SelectionChangeCommitted += new System.EventHandler(this.comboBoxOlimpiada_SelectedIndexChanged);
            this.comboBoxOlimpiada.SelectedValueChanged += new System.EventHandler(this.comboBoxOlimpiada_SelectedIndexChanged);
            this.comboBoxOlimpiada.SizeChanged += new System.EventHandler(this.comboBoxOlimpiada_SelectedIndexChanged);
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(265, 660);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(121, 28);
            this.comboBoxCountry.TabIndex = 4;
            this.comboBoxCountry.UseWaitCursor = true;
            this.comboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountry_SelectedIndexChanged);
            // 
            // comboBoxSports
            // 
            this.comboBoxSports.FormattingEnabled = true;
            this.comboBoxSports.Location = new System.Drawing.Point(265, 600);
            this.comboBoxSports.Name = "comboBoxSports";
            this.comboBoxSports.Size = new System.Drawing.Size(121, 28);
            this.comboBoxSports.TabIndex = 5;
            this.comboBoxSports.UseWaitCursor = true;
            this.comboBoxSports.SelectedIndexChanged += new System.EventHandler(this.comboBoxSports_SelectedIndexChanged);
            // 
            // MedalistsSport
            // 
            this.MedalistsSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedalistsSport.Location = new System.Drawing.Point(896, 169);
            this.MedalistsSport.Name = "MedalistsSport";
            this.MedalistsSport.Size = new System.Drawing.Size(490, 106);
            this.MedalistsSport.TabIndex = 6;
            this.MedalistsSport.Text = "Таблица медалистов по разным видам спорта по конкретной олимпиаде\r\n";
            this.MedalistsSport.UseVisualStyleBackColor = true;
            this.MedalistsSport.UseWaitCursor = true;
            this.MedalistsSport.Click += new System.EventHandler(this.buttonMed2_Click);
            // 
            // MedalCountCountry
            // 
            this.MedalCountCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedalCountCountry.Location = new System.Drawing.Point(896, 54);
            this.MedalCountCountry.Name = "MedalCountCountry";
            this.MedalCountCountry.Size = new System.Drawing.Size(490, 98);
            this.MedalCountCountry.TabIndex = 7;
            this.MedalCountCountry.Text = "Таблица медального зачета по странам по конкретной олимпиаде\r\n\r\n\r\n";
            this.MedalCountCountry.UseVisualStyleBackColor = true;
            this.MedalCountCountry.UseWaitCursor = true;
            this.MedalCountCountry.Click += new System.EventHandler(this.MedZachBut_Click);
            // 
            // OlympicTeamCountry
            // 
            this.OlympicTeamCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OlympicTeamCountry.Location = new System.Drawing.Point(896, 600);
            this.OlympicTeamCountry.Name = "OlympicTeamCountry";
            this.OlympicTeamCountry.Size = new System.Drawing.Size(490, 98);
            this.OlympicTeamCountry.TabIndex = 8;
            this.OlympicTeamCountry.Text = "Состав олимпиадной команды спортсменов конкретной страны";
            this.OlympicTeamCountry.UseVisualStyleBackColor = true;
            this.OlympicTeamCountry.UseWaitCursor = true;
            this.OlympicTeamCountry.Click += new System.EventHandler(this.buttonSostav_Click);
            // 
            // MostFrequentHostCountry
            // 
            this.MostFrequentHostCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MostFrequentHostCountry.Location = new System.Drawing.Point(896, 502);
            this.MostFrequentHostCountry.Name = "MostFrequentHostCountry";
            this.MostFrequentHostCountry.Size = new System.Drawing.Size(490, 92);
            this.MostFrequentHostCountry.TabIndex = 9;
            this.MostFrequentHostCountry.Text = "Название страны, которая чаще всех была хозяйкой олимпиады";
            this.MostFrequentHostCountry.UseVisualStyleBackColor = true;
            this.MostFrequentHostCountry.UseWaitCursor = true;
            this.MostFrequentHostCountry.Click += new System.EventHandler(this.buttonCh_Click);
            // 
            // AthleteMostGoldMedals
            // 
            this.AthleteMostGoldMedals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AthleteMostGoldMedals.Location = new System.Drawing.Point(896, 394);
            this.AthleteMostGoldMedals.Name = "AthleteMostGoldMedals";
            this.AthleteMostGoldMedals.Size = new System.Drawing.Size(490, 102);
            this.AthleteMostGoldMedals.TabIndex = 10;
            this.AthleteMostGoldMedals.Text = "Спортсмен, который выиграл больше всего золотых медалей в конкретном виде спорта";
            this.AthleteMostGoldMedals.UseVisualStyleBackColor = true;
            this.AthleteMostGoldMedals.UseWaitCursor = true;
            this.AthleteMostGoldMedals.Click += new System.EventHandler(this.button6_Click);
            // 
            // CountryMostGoldMedals
            // 
            this.CountryMostGoldMedals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountryMostGoldMedals.Location = new System.Drawing.Point(896, 281);
            this.CountryMostGoldMedals.Name = "CountryMostGoldMedals";
            this.CountryMostGoldMedals.Size = new System.Drawing.Size(490, 107);
            this.CountryMostGoldMedals.TabIndex = 11;
            this.CountryMostGoldMedals.Text = "Страна, которая собрала больше всего золотых медалей на конкретной олимпиаде";
            this.CountryMostGoldMedals.UseVisualStyleBackColor = true;
            this.CountryMostGoldMedals.UseWaitCursor = true;
            this.CountryMostGoldMedals.Click += new System.EventHandler(this.buttonCMax_Click);
            // 
            // PerformanceStatsCountry
            // 
            this.PerformanceStatsCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PerformanceStatsCountry.Location = new System.Drawing.Point(430, 590);
            this.PerformanceStatsCountry.Name = "PerformanceStatsCountry";
            this.PerformanceStatsCountry.Size = new System.Drawing.Size(460, 108);
            this.PerformanceStatsCountry.TabIndex = 12;
            this.PerformanceStatsCountry.Text = "Статистика выступления конкретной страны на конкретной олимпиаде";
            this.PerformanceStatsCountry.UseVisualStyleBackColor = true;
            this.PerformanceStatsCountry.UseWaitCursor = true;
            this.PerformanceStatsCountry.Click += new System.EventHandler(this.buttonCMed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "страна";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 603);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "спорт";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 537);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "id олимпиады";
            this.label3.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1423, 772);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PerformanceStatsCountry);
            this.Controls.Add(this.CountryMostGoldMedals);
            this.Controls.Add(this.AthleteMostGoldMedals);
            this.Controls.Add(this.MostFrequentHostCountry);
            this.Controls.Add(this.OlympicTeamCountry);
            this.Controls.Add(this.MedalCountCountry);
            this.Controls.Add(this.MedalistsSport);
            this.Controls.Add(this.comboBoxSports);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.comboBoxOlimpiada);
            this.Controls.Add(this.TableResults);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Главная";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.TableResults)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TableResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem работаСТаблицамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem олимпиадыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ВидыСпортаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СоревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem участникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеДанныеToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxOlimpiada;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.ComboBox comboBoxSports;
        private System.Windows.Forms.Button MedalistsSport;
        private System.Windows.Forms.Button MedalCountCountry;
        private System.Windows.Forms.Button OlympicTeamCountry;
        private System.Windows.Forms.Button MostFrequentHostCountry;
        private System.Windows.Forms.Button AthleteMostGoldMedals;
        private System.Windows.Forms.Button CountryMostGoldMedals;
        private System.Windows.Forms.Button PerformanceStatsCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


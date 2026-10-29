namespace OlimpiadaExam
{
    partial class Resul
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
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.comboBoxOlimp = new System.Windows.Forms.ComboBox();
            this.TextBoxPlace = new System.Windows.Forms.TextBox();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.comboBoxMedal = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(500, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(439, 100);
            this.label6.TabIndex = 0;
            this.label6.Text = "Результаты";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 163);
            this.panel1.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Медаль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Место";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "id олимпиады";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "id участника";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "id";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.PeachPuff;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(417, 510);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 60);
            this.button4.TabIndex = 25;
            this.button4.Text = "Назад";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(417, 390);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(138, 56);
            this.Delete.TabIndex = 24;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.SystemColors.Info;
            this.Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update.Location = new System.Drawing.Point(417, 312);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(138, 56);
            this.Update.TabIndex = 23;
            this.Update.Text = "Изменить";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.Info;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(417, 243);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(138, 53);
            this.Add.TabIndex = 22;
            this.Add.TabStop = false;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // comboBoxOlimp
            // 
            this.comboBoxOlimp.FormattingEnabled = true;
            this.comboBoxOlimp.Items.AddRange(new object[] {
            "Summer",
            "Winter"});
            this.comboBoxOlimp.Location = new System.Drawing.Point(193, 329);
            this.comboBoxOlimp.Name = "comboBoxOlimp";
            this.comboBoxOlimp.Size = new System.Drawing.Size(201, 28);
            this.comboBoxOlimp.TabIndex = 19;
            this.comboBoxOlimp.SelectedValueChanged += new System.EventHandler(this.comboBoxPart_SelectedValueChanged);
            // 
            // TextBoxPlace
            // 
            this.TextBoxPlace.Location = new System.Drawing.Point(193, 390);
            this.TextBoxPlace.Name = "TextBoxPlace";
            this.TextBoxPlace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxPlace.Size = new System.Drawing.Size(201, 26);
            this.TextBoxPlace.TabIndex = 18;
            this.TextBoxPlace.TextChanged += new System.EventHandler(this.comboBoxPart_SelectedValueChanged);
            // 
            // comboBoxId
            // 
            this.comboBoxId.FormattingEnabled = true;
            this.comboBoxId.Location = new System.Drawing.Point(193, 219);
            this.comboBoxId.Name = "comboBoxId";
            this.comboBoxId.Size = new System.Drawing.Size(201, 28);
            this.comboBoxId.TabIndex = 17;
            this.comboBoxId.SelectedIndexChanged += new System.EventHandler(this.comboBoxId_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(587, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(848, 396);
            this.dataGridView1.TabIndex = 16;
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(193, 268);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(201, 28);
            this.comboBoxPart.TabIndex = 32;
            this.comboBoxPart.SelectedValueChanged += new System.EventHandler(this.comboBoxPart_SelectedValueChanged);
            // 
            // comboBoxMedal
            // 
            this.comboBoxMedal.FormattingEnabled = true;
            this.comboBoxMedal.Items.AddRange(new object[] {
            "Gold",
            "Silver",
            "Bronze"});
            this.comboBoxMedal.Location = new System.Drawing.Point(193, 443);
            this.comboBoxMedal.Name = "comboBoxMedal";
            this.comboBoxMedal.Size = new System.Drawing.Size(201, 28);
            this.comboBoxMedal.TabIndex = 33;
            // 
            // Resul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 636);
            this.Controls.Add(this.comboBoxMedal);
            this.Controls.Add(this.comboBoxPart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.comboBoxOlimp);
            this.Controls.Add(this.TextBoxPlace);
            this.Controls.Add(this.comboBoxId);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Resul";
            this.Text = "Resul";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox comboBoxOlimp;
        private System.Windows.Forms.TextBox TextBoxPlace;
        private System.Windows.Forms.ComboBox comboBoxId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.ComboBox comboBoxMedal;
    }
}
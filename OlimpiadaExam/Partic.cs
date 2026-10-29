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

namespace OlimpiadaExam
{
    public partial class Partic : Form
    {
        private string selectedImagePath; 
        public Partic()
        {
            InitializeComponent();
            DisplayAllPar();
            Add.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;
            comboBoxId.SelectedIndex = -1;
            ClearDate();


        }
        private void DisplayAllPar()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var parList = db.Participants.ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("Surname", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Country", typeof(string));
                dt.Columns.Add("TypeSport", typeof(string));
                dt.Columns.Add("BirthDate", typeof(DateTime));
                dt.Columns.Add("FotoPath", typeof(string)); 
                dt.Columns.Add("Picture", typeof(Image));

                foreach (var com in parList)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = com.ID;
                    row["FirstName"] = com.FirstName;
                    row["Surname"] = com.Surname;
                    row["LastName"] = com.LastName;
                    row["Country"] = com.Country;
                    row["TypeSport"] = com.TypeSport;
                    row["BirthDate"] = com.BirthDate;
                    row["FotoPath"] = com.FotoPath; 
                    row["Picture"] = com.Picture;

                  
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["FotoPath"].Visible = false; 
                UpCBId();
            }
        }
        
 
        public bool SavePart(Participants Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                db.Participants.Add(Stu);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public void ShowStatus(bool result, string Action)
        {
            CrudMessages.ShowStatus(result, Action);
            ClearFields();
        }

        public void ClearFields()
        {
            TextBoxFN.Text = "";
            TextBoxSN.Text = "";
            textBoxLN.Text = "";
            textBoxCountry.Text = "";
            textBoxSport.Text = "";
            dateTimePickerBD.Text = "";

        }
        private void ClearDate()
        {
            dateTimePickerBD.ResetText();
            dateTimePickerBD.Value = DateTime.Now;
        }
        private void UpCBId()
        {
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxId.DataSource = db.Participants.ToList();
                    comboBoxId.ValueMember = "ID";
                    comboBoxId.DisplayMember = "ID";
                    comboBoxId.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool UpdateRes(Participants Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                Participants _part = db.Participants.Where(x => x.ID == Stu.ID).Select(x => x).FirstOrDefault();
                _part.FirstName = Stu.FirstName;
                _part.Surname = Stu.Surname;
                _part.LastName = Stu.LastName;
                _part.Country = Stu.Country;
                _part.TypeSport = Stu.TypeSport;
                _part.BirthDate = Stu.BirthDate;
                _part.FotoPath = Stu.FotoPath;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Participants stu = new Participants();
            stu.FirstName = TextBoxFN.Text;
            stu.Surname = TextBoxSN.Text;
            stu.LastName = textBoxLN.Text;
            stu.Country = textBoxCountry.Text;
            stu.TypeSport = textBoxSport.Text;
            stu.BirthDate = Convert.ToDateTime(dateTimePickerBD.Text);

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(appPath, "images", Path.GetFileName(selectedImagePath));
                if (!Directory.Exists(Path.Combine(appPath, "images")))
                    Directory.CreateDirectory(Path.Combine(appPath, "images"));
                File.Copy(selectedImagePath, imagePath, true);
                stu.FotoPath = imagePath;
                selectedImagePath = null;
                pictureBoxFoto.Image = null;
            }

            bool result = SavePart(stu);
            ShowStatus(result, "Save");
            ClearDate();
            DisplayAllPar();
 
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);
                var partic = db.Participants.Where(o => o.ID == id).SingleOrDefault();
                if (TextBoxFN.Text.Length != 0) partic.FirstName = TextBoxFN.Text;
                if (TextBoxSN.Text.Length != 0) partic.Surname = TextBoxSN.Text;
                if (textBoxLN.Text.Length != 0) partic.LastName = textBoxLN.Text;
                if (textBoxCountry.Text.Length != 0) partic.Country = textBoxCountry.Text;
                if(textBoxSport.Text.Length != 0) partic.TypeSport=textBoxSport.Text;
                if (dateTimePickerBD.Text.Length != 0 && DateTime.Parse(dateTimePickerBD.Text) != partic.BirthDate && checkBox1.Checked == true)
                {
                    partic.BirthDate = DateTime.Parse(dateTimePickerBD.Text);
                    ClearDate();
                }
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    string imagePath = Path.Combine(appPath, "images", Path.GetFileName(selectedImagePath));
                    if (!Directory.Exists(Path.Combine(appPath, "images")))
                        Directory.CreateDirectory(Path.Combine(appPath, "images"));
                    File.Copy(selectedImagePath, imagePath, true);
                    partic.FotoPath = imagePath;
                    selectedImagePath = null;
                    pictureBoxFoto.Image = null;
                }

                bool result = UpdateRes(partic);
                ShowStatus(result, "Update");
                DisplayAllPar();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);

                var results = db.Results.Where(r => r.IdPart == id).ToList();
                foreach (var result in results)
                {
                    db.Results.Remove(result);
                }

                var comp = db.Participants.Where(o => o.ID == id).SingleOrDefault();
                db.Participants.Remove(comp);
                db.SaveChanges();
                DisplayAllPar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxId.Text.Length == 0)
            {
                Update.Enabled = false;
                Delete.Enabled = false;
            }
            else { Update.Enabled = true; Delete.Enabled = true; }
        }

        private void TextBoxFN_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSport.Text.Length == 0 || textBoxLN.Text.Length == 0|| textBoxCountry.Text.Length == 0||TextBoxFN.Text.Length == 0 || TextBoxSN.Text.Length == 0 || dateTimePickerBD.Text.Length == 0)
                Add.Enabled = false;
            else Add.Enabled = true;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFoto.Image = Image.FromFile(openFileDialog.FileName);
                    selectedImagePath = openFileDialog.FileName; 
                }
            }
        }

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string fotoPath = row.Cells["FotoPath"].Value?.ToString();

            if (!string.IsNullOrEmpty(fotoPath) && File.Exists(fotoPath))
            {
                try
                {
                    Image img = Image.FromFile(fotoPath);
                    
                    img.Dispose();
                    row.Cells["Picture"].Value = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                }
            }
        }
    }

}

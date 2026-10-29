using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OlimpiadaExam
{
    public partial class Ol : Form
    {
        public Ol()
        {
            InitializeComponent();
            DisplayAllOlimp();          
            Add.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;
            comboBoxId.SelectedIndex = -1;
        }
        private void DisplayAllOlimp()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var olympusList = db.Olympus.ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Oyear");
                dt.Columns.Add("Otype");
                dt.Columns.Add("HostCountry");
                dt.Columns.Add("City");
                foreach (var olympus in olympusList)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = olympus.ID;
                    row["Oyear"] = olympus.Oyear;
                    row["Otype"] = olympus.Otype;
                    row["HostCountry"] = olympus.HostCountry;
                    row["City"] = olympus.City;
                    dt.Rows.Add(row);
                }
                dataGridView1.DataSource = dt;
                UpCBId();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Olympus stu = new Olympus();
            try
            {
                Convert.ToInt32(TextBoxYear.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Год имел неверный формат");
                return;
            }
          
            stu.Oyear = Convert.ToInt32(TextBoxYear.Text);
            stu.Otype = comboBoxType.Text;
            stu.City = textBoxCity.Text;
            stu.HostCountry = TextBoxCountry.Text;
          
            bool result = SaveOlimp(stu);
            ShowStatus(result, "Save");
            DisplayAllOlimp();
        }
        public bool SaveOlimp(Olympus Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                db.Olympus.Add(Stu);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
        public void ShowStatus(bool result, string act)
        {
            CrudMessages.ShowStatus(result, act);
            ClearFields();
        }

        public void ClearFields() 
        {
            TextBoxYear.Text = "";
            textBoxCity.Text = "";
            TextBoxCountry.Text = "";
          
        }
        private void UpCBId()
        {
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxId.DataSource = db.Olympus.ToList();
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

        private void Delete_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);

                var competitions = db.Competitions.Where(c => c.IdOlimp == id).ToList();
                foreach (var competition in competitions)
                {
                    db.Competitions.Remove(competition);
                }

                var results = db.Results.Where(r => r.IdOlimp == id).ToList();
                foreach (var result in results)
                {
                    db.Results.Remove(result);
                }

                var olympus = db.Olympus.Where(o => o.ID == id).SingleOrDefault();
                db.Olympus.Remove(olympus);

                db.SaveChanges();

                DisplayAllOlimp();
              
            }
            
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);
                var olympus = db.Olympus.Where(o => o.ID == id).SingleOrDefault();
                if (TextBoxYear.Text.Length != 0)
                {
                    try
                    {
                        Convert.ToInt32(TextBoxYear.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Место имел неверный формат");
                        return;
                    }
                    olympus.Oyear = Convert.ToInt32(TextBoxYear.Text);
                }
                if(comboBoxType.Text.Length != 0) olympus.Otype = comboBoxType.Text;
                if(TextBoxCountry.Text.Length != 0) olympus.HostCountry = TextBoxCountry.Text;
                if(textBoxCity.Text.Length != 0) olympus.City = textBoxCity.Text;

                bool result = UpdateOlimp(olympus);
                ShowStatus(result, "Update");

                DisplayAllOlimp();
            }   
        }
       
        public bool UpdateOlimp(Olympus Stu) 
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                Olympus _ol = db.Olympus.Where(x => x.ID == Stu.ID).Select(x => x).FirstOrDefault();
                _ol.Oyear = Stu.Oyear;
                _ol.Oyear = Stu.Oyear;
                _ol.Otype = Stu.Otype;
                _ol.HostCountry = Stu.HostCountry;
                _ol.City = Stu.City;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        private void TextBoxYear_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCity.Text.Length == 0 || TextBoxCountry.Text.Length == 0 || TextBoxYear.Text.Length == 0 || comboBoxType.Text.Length == 0)
                Add.Enabled = false;
            else
                Add.Enabled = true;
        }

        private void comboBoxId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxId.Text.Length == 0)
            {
                Update.Enabled = false;
                Delete.Enabled = false;
            }
            else { Update.Enabled = true; Delete.Enabled = true; }
                
        }

        
    }
}

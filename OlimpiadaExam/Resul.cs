using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaExam
{
    public partial class Resul : Form
    {
        public Resul()
        {
            
            InitializeComponent();
            DisplayAllRes();
            Add.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;
            comboBoxId.SelectedIndex = -1;
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxOlimp.DataSource = db.Olympus.Distinct().ToList();
                    comboBoxOlimp.ValueMember = "ID";
                    comboBoxOlimp.DisplayMember = "ID";
                    comboBoxOlimp.SelectedIndex = -1;

                    comboBoxPart.DataSource = db.Participants.Distinct().ToList();
                    comboBoxPart.ValueMember = "ID";
                    comboBoxPart.DisplayMember = "ID";
                    comboBoxPart.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayAllRes()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var resList = db.Results.ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("IdPart");
                dt.Columns.Add("IdOlimp");
                dt.Columns.Add("Place");
                dt.Columns.Add("Medal");

                foreach (var com in resList)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = com.ID;
                    row["IdPart"] = com.IdPart;
                    row["IdOlimp"] = com.IdOlimp;
                    row["Place"] = com.Place;
                    row["Medal"] = com.Medal;
                    dt.Rows.Add(row);
                }
                dataGridView1.DataSource = dt;
                UpCBId();
            }
        }
        public bool SaveRes(Results Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                db.Results.Add(Stu);
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
            comboBoxMedal.SelectedIndex = -1;
            TextBoxPlace.Text = "";
            comboBoxOlimp.SelectedIndex = -1;
            comboBoxPart.SelectedIndex = -1;

        }
        private void UpCBId()
        {
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxId.DataSource = db.Results.ToList();
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
        public bool UpdateRes(Results Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                Results _res = db.Results.Where(x => x.ID == Stu.ID).Select(x => x).FirstOrDefault();
                _res.IdOlimp = Stu.IdOlimp;
                _res.IdPart = Stu.IdPart;
                _res.Place = Stu.Place;
                _res.Medal = Stu.Medal;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Results stu = new Results();
            try
            {
                Convert.ToInt32(TextBoxPlace.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Место имел неверный формат");
                return;
            }

            stu.IdOlimp = Convert.ToInt32(comboBoxOlimp.Text);
            stu.IdPart = Convert.ToInt32(comboBoxPart.Text);
            stu.Place = Convert.ToInt32(TextBoxPlace.Text);
            stu.Medal = comboBoxMedal.Text;


            bool result = SaveRes(stu);
            ShowStatus(result, "Save");
            // comboBoxType.SelectedIndex = -1;
            DisplayAllRes();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);


                var comp = db.Results.Where(o => o.ID == id).SingleOrDefault();
                if (comboBoxOlimp.Text.Length != 0) comp.IdOlimp = Convert.ToInt32(comboBoxOlimp.Text);
                if (comboBoxPart.Text.Length != 0) comp.IdPart = Convert.ToInt32(comboBoxPart.Text);
                if (comboBoxMedal.Text.Length != 0) comp.Medal = comboBoxMedal.Text;
                if (TextBoxPlace.Text.Length != 0)
                {
                    try
                    {
                        Convert.ToInt32(TextBoxPlace.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Место имел неверный формат");
                        return;
                    }
                    comp.Place = Convert.ToInt32(TextBoxPlace.Text);
                }


                bool result = UpdateRes(comp);
                ShowStatus(result, "Update");

                DisplayAllRes();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);

                var res = db.Results.Where(o => o.ID == id).SingleOrDefault();
                db.Results.Remove(res);

                db.SaveChanges();
                DisplayAllRes();

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

        private void comboBoxPart_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBoxPart.Text.Length == 0 || comboBoxOlimp.Text.Length == 0|| TextBoxPlace.Text.Length == 0)
                Add.Enabled = false;
            else Add.Enabled = true;
        }
    }
}

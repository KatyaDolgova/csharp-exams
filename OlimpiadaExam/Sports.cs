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
    public partial class Sports : Form
    {
        public Sports()
        {
            InitializeComponent();
            DisplayAllType();
            Add.Enabled = false;
            Update.Enabled = false;
            Delete.Enabled = false;
            comboBoxId.Text = "";
        }
        private void DisplayAllType()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var typeList = db.TypesOfSports.ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Title");

                foreach (var olympus in typeList)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = olympus.ID;
                    row["Title"] = olympus.Title;
                    dt.Rows.Add(row);
                }
                dataGridView1.DataSource = dt;
                UpCBId();
            }
        }
        private void UpCBId()
        {
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxId.DataSource = db.TypesOfSports.ToList();
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

        public bool SaveStudentDetails(TypesOfSports Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                db.TypesOfSports.Add(Stu);
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
            TextBoxTitle.Text = "";
        }


        public bool UpdateOlimp(TypesOfSports Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                TypesOfSports _tp = db.TypesOfSports.Where(x => x.ID == Stu.ID).Select(x => x).FirstOrDefault();
                _tp.Title = Stu.Title;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxTitle.Text.Length == 0)     
                Add.Enabled = false;   
            else Add.Enabled = true;
            if (TextBoxTitle.Text.Length == 0 || comboBoxId.Text.Length == 0)
                Update.Enabled = false;
            else Update.Enabled = true;
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            TypesOfSports stu = new TypesOfSports();

            stu.Title = TextBoxTitle.Text;

            bool result = SaveStudentDetails(stu);
            ShowStatus(result, "Save");
            DisplayAllType();
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);
                var type = db.TypesOfSports.Where(o => o.ID == id).SingleOrDefault();

                type.Title = TextBoxTitle.Text;

                bool result = UpdateOlimp(type);
                ShowStatus(result, "Update");

                DisplayAllType();
            }
        }

        private void Delete_Click_1(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);
                var competitions = db.Competitions.Where(c => c.IdTypesSport == id).ToList();
                foreach (var competition in competitions)
                {
                    var results = db.Results.Where(r => r.IdOlimp == competition.IdOlimp).ToList();
                    foreach (var result in results)
                    {
                        db.Results.Remove(result);
                    }

                    db.Competitions.Remove(competition);
                }

                var type = db.TypesOfSports.Where(o => o.ID == id).SingleOrDefault();
                if (type != null)
                {
                    db.TypesOfSports.Remove(type);
                }
                db.SaveChanges();
                DisplayAllType();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxId_ClientSizeChanged(object sender, EventArgs e)
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


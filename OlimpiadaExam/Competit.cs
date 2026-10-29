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
    public partial class Competit : Form
    {
        public Competit()
        {
            InitializeComponent();
            DisplayAllComp();
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

                    comboBoxType.DataSource = db.TypesOfSports.Distinct().ToList();
                    comboBoxType.ValueMember = "ID";
                    comboBoxType.DisplayMember = "ID";
                    comboBoxType.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayAllComp()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var competList = db.Competitions.ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("IdOlimp");
                dt.Columns.Add("IdTypesSport");
                dt.Columns.Add("NumberPart");
    
                foreach (var com in competList)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = com.ID;
                    row["IdOlimp"] = com.IdOlimp;
                    row["IdTypesSport"] = com.IdTypesSport;
                    row["NumberPart"] = com.NumberPart;
                    dt.Rows.Add(row);
                }
                dataGridView1.DataSource = dt;
                UpCBId();
            }
        }
        public bool SaveComp(Competitions Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                db.Competitions.Add(Stu);
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
            TextBoxNum.Text = "";
            comboBoxOlimp.SelectedIndex = -1;
            comboBoxType.SelectedIndex = -1;

        }
        private void UpCBId()
        {
            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxId.DataSource = db.Competitions.ToList();
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
        public bool UpdateComp(Competitions Stu)
        {
            bool result = false;
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                Competitions _com = db.Competitions.Where(x => x.ID == Stu.ID).Select(x => x).FirstOrDefault();
                _com.IdOlimp = Stu.IdOlimp;
                _com.IdTypesSport = Stu.IdTypesSport;
                _com.NumberPart = Stu.NumberPart;
                db.SaveChanges();
                result = true;
            }
            return result;
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

        private void Add_Click(object sender, EventArgs e)
        {
            Competitions stu = new Competitions();
            try
            {
                Convert.ToInt32(TextBoxNum.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Кол-во участников имел неверный формат");
                return;
            }

            stu.IdOlimp = Convert.ToInt32(comboBoxOlimp.Text);
            stu.IdTypesSport = Convert.ToInt32(comboBoxType.Text);
            stu.NumberPart = Convert.ToInt32(TextBoxNum.Text);
            

            bool result = SaveComp(stu);
            ShowStatus(result, "Save");
            // comboBoxType.SelectedIndex = -1;
            DisplayAllComp();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);


                var comp = db.Competitions.Where(o => o.ID == id).SingleOrDefault();
                if (comboBoxOlimp.Text.Length != 0) comp.IdOlimp = Convert.ToInt32(comboBoxOlimp.Text);
                if (comboBoxType.Text.Length != 0) comp.IdTypesSport = Convert.ToInt32(comboBoxType.Text);
                if (TextBoxNum.Text.Length != 0)
                {
                    try
                    {
                        Convert.ToInt32(TextBoxNum.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Кол-во участников имел неверный формат");
                        return;
                    }
                    comp.NumberPart = Convert.ToInt32(TextBoxNum.Text);
                }
                

                bool result = UpdateComp(comp);
                ShowStatus(result, "Update");

                DisplayAllComp(); 
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
            {
                int id = Convert.ToInt32(comboBoxId.Text);         

                var comp = db.Competitions.Where(o => o.ID == id).SingleOrDefault();
                db.Competitions.Remove(comp);

                db.SaveChanges();

                DisplayAllComp();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxNum_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxOlimp.Text.Length == 0 || comboBoxType.Text.Length == 0|| TextBoxNum.Text.Length == 0)
            {
                Add.Enabled = false;
            }
            else { Add.Enabled = true;  }
            
        }
    }
}

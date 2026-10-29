using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSlova
{
    public partial class StatisticForm : Form
    {
        private List<Statistic> listStatistic = null;
        public StatisticForm(List<Statistic> listStatistic)
        {
            InitializeComponent();
            this.listStatistic = listStatistic;
            dataGridView1.DataSource = listStatistic;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            TopForm tf = new TopForm(listStatistic.Select(s => new TopWords(s.Word, s.NumWordFound)).ToList());
            tf.Show();
        }
    }
}

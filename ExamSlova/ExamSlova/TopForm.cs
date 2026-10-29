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
    public partial class TopForm : Form
    {
        private List<TopWords> topWordsList;

        public TopForm(List<TopWords> topWords) 
        {
            InitializeComponent();
            topWordsList = topWords; 
            dataGridView1.DataSource = CalculateTopWords(topWordsList);
        }

        private List<dynamic> CalculateTopWords(List<TopWords> topWordsList)
        {
            return topWordsList.GroupBy(a => a.Word)
               .Select(a => new
               {
                   word = a.Key,
                   sumWords = a.Sum(ab => ab.Count)
               })
               .OrderByDescending(s => s.sumWords)
               .Take(10)
               .ToList<dynamic>();

        }
    }
}


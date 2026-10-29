using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OlimpiadaExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MedalCountCountry.Enabled = false;
            MedalistsSport.Enabled = false;
            CountryMostGoldMedals.Enabled = false;
            PerformanceStatsCountry.Enabled = false;
            AthleteMostGoldMedals.Enabled = false;
            OlympicTeamCountry.Enabled = false;

            try
            {
                using (ExamOlimpBdEntities db = new ExamOlimpBdEntities())
                {
                    comboBoxCountry.DataSource = db.Olympus.ToList();
                    comboBoxCountry.ValueMember = "HostCountry";
                    comboBoxCountry.DisplayMember = "HostCountry";
                    comboBoxCountry.SelectedIndex = -1;

                    comboBoxSports.DataSource = db.TypesOfSports.ToList();
                    comboBoxSports.ValueMember = "Title";
                    comboBoxSports.DisplayMember = "Title";
                    comboBoxSports.SelectedIndex = -1;

                    comboBoxOlimpiada.DataSource = db.Olympus.ToList();
                    comboBoxOlimpiada.ValueMember = "ID";
                    comboBoxOlimpiada.DisplayMember = "ID";
                    comboBoxOlimpiada.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public class MedalCount
        {
            public string Country { get; set; }
            public int Gold { get; set; }
            public int Silver { get; set; }
            public int Bronze { get; set; }
        }
        public class Medalist
        {
            public string Name { get; set; }
            public string Medal { get; set; }
            public string Sport{ get; set; }
        }
        public class Athlete
        {
            public string FullName { get; set; }
            public DateTime BirthDate { get; set; }
        }
        public class PerformanceStatistics
        {
            public string Medal { get; set; }
            public int Place { get; set; }
        }
        public List<MedalCount> GetMedalCountByCountry(int olympicId)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var results = from r in db.Results
                              where r.IdOlimp == olympicId
                              group r by r.Participants.Country into g
                              select new MedalCount
                              {
                                  Country = g.Key,
                                  Gold = g.Count(m => m.Medal == "Gold"),
                                  Silver = g.Count(m => m.Medal == "Silver"),
                                  Bronze = g.Count(m => m.Medal == "Bronze")
                              };

                return results.ToList();
            }
        }
        public List<Medalist> GetMedalistsBySport(int olympicId)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var participants = from r in db.Results
                                   join p in db.Participants on r.IdPart equals p.ID
                                   where r.IdOlimp == olympicId
                                   orderby p.TypeSport, r.Place
                                   select new Medalist
                                   {
                                       Name = p.FirstName + " " + p.Surname,
                                       Medal = r.Medal,
                                       Sport = p.TypeSport
                                   };

                return participants.ToList();
            }
        }
        public string GetCountryWithMostGoldMedals(int olympicId)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var countryWithMostGold = (from r in db.Results
                                           where r.IdOlimp == olympicId && r.Medal == "Gold"
                                           group r by r.Participants.Country into g
                                           orderby g.Count() descending
                                           select g.Key).FirstOrDefault();

                return countryWithMostGold;
            }
        }

        public string GetAthleteWithMostGoldMedals(string sport)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var athleteWithMostGold = (from r in db.Results
                                           join p in db.Participants on r.IdPart equals p.ID
                                           where p.TypeSport == sport && r.Medal == "Gold"
                                           group p by p.FirstName + " "+ p.Surname + " "+ p.LastName into g
                                           orderby g.Count() descending
                                           select g.Key ).FirstOrDefault();

                return athleteWithMostGold;
            }
        }
        public string GetMostFrequentHostCountry()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var hostCountry = (from o in db.Olympus
                                   group o by o.HostCountry into g
                                   orderby g.Count() descending
                                   select g.Key).FirstOrDefault();

                return hostCountry;
            }
        }

        public List<Athlete> GetOlympicTeamByCountry(string country)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var athletes = from p in db.Participants
                               where p.Country == country
                               select new Athlete
                               {
                                   FullName = p.FirstName + " " + p.Surname + " " + p.LastName,
                                   BirthDate = p.BirthDate
                               };

                return athletes.ToList();
            }
        }
        public List<PerformanceStatistics> GetPerformanceStatsByCountry(int olympicId, string country)
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var stats = from r in db.Results
                            join p in db.Participants on r.IdPart equals p.ID
                            where r.IdOlimp == olympicId && p.Country == country
                            select new PerformanceStatistics
                            {
                                Medal = r.Medal,
                                Place = r.Place
                            };

                return stats.ToList();
            }
        }

        
        private void buttonMed2_Click(object sender, EventArgs e)
        {
            TableResults.DataSource = GetMedalistsBySport(Convert.ToInt32(comboBoxOlimpiada.Text));
            comboBoxOlimpiada.SelectedIndex = -1;
        }

        private void buttonCMax_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetCountryWithMostGoldMedals(Convert.ToInt32(comboBoxOlimpiada.Text)));
            comboBoxOlimpiada.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetAthleteWithMostGoldMedals(comboBoxSports.Text));
            comboBoxSports.SelectedIndex = -1;
        }

        private void MedZachBut_Click(object sender, EventArgs e)
        {
            TableResults.DataSource = GetMedalCountByCountry(Convert.ToInt32(comboBoxOlimpiada.Text));
            comboBoxOlimpiada.SelectedIndex = -1;
        }
        private void buttonCh_Click(object sender, EventArgs e)
        {        
            MessageBox.Show(GetMostFrequentHostCountry());         
        }

        private void buttonSostav_Click(object sender, EventArgs e)
        {
            TableResults.DataSource =GetOlympicTeamByCountry(comboBoxCountry.Text);
            comboBoxCountry.SelectedIndex = -1;
        }

        private void buttonCMed_Click(object sender, EventArgs e)
        {
            TableResults.DataSource = GetPerformanceStatsByCountry(Convert.ToInt32(comboBoxOlimpiada.Text), comboBoxCountry.Text);
            comboBoxOlimpiada.SelectedIndex = -1;
            comboBoxCountry.SelectedIndex = -1;
        }

        private void comboBoxOlimpiada_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (comboBoxOlimpiada.Text.Length == 0)
             {
                MedalCountCountry.Enabled = false;
                MedalistsSport.Enabled = false;
                CountryMostGoldMedals.Enabled = false;
                PerformanceStatsCountry.Enabled = false;
             }
            else
            {
                MedalCountCountry.Enabled = true;
                MedalistsSport.Enabled = true;
                CountryMostGoldMedals.Enabled = true;
                PerformanceStatsCountry.Enabled = true;
            }
        }

        private void comboBoxSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSports.Text.Length == 0)
                AthleteMostGoldMedals.Enabled=false;
            else AthleteMostGoldMedals.Enabled = true;
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCountry.Text.Length == 0)
                OlympicTeamCountry.Enabled=false;
            else OlympicTeamCountry.Enabled = true;
        }

        private void олимпиадыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ol ol = new Ol();
            ol.ShowDialog();
        }

        private void ВидыСпортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sports sp = new Sports();
            sp.ShowDialog();
        }

        private void СоревнованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Competit cp = new Competit();
            cp.ShowDialog();
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resul resul = new Resul();
            resul.ShowDialog();
        }

        private void всеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            All all = new All();
            all.ShowDialog();
        }

        private void участникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Partic partic = new Partic();
            partic.ShowDialog();
        }
    }
}

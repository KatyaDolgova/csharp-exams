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
    

    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
            dataGridView1.DataSource = LoadCombinedData();
        }
        private List<OlympicData> LoadCombinedData()
        {
            using (var db = new ExamOlimpBdEntities())
            {
                var data = from Olympus in db.Olympus
                                   join Competitions in db.Competitions on Olympus.ID equals Competitions.IdOlimp
                                   join TypesOfSports in db.TypesOfSports on Competitions.IdTypesSport equals TypesOfSports.ID
                                   join Results in db.Results on Olympus.ID equals Results.IdOlimp
                                   join Participants in db.Participants on Results.IdPart equals Participants.ID
                                   select new OlympicData
                                   {
                                       OlympicID = Olympus.ID,
                                       Oyear = Olympus.Oyear,
                                       Otype = Olympus.Otype,
                                       HostCountry = Olympus.HostCountry,
                                       City = Olympus.City,
                                       TypeSport = TypesOfSports.Title,
                                       ParticipantName = Participants.FirstName + " " + Participants.Surname + " " + Participants.LastName,
                                       CompetitionNumber = Competitions.NumberPart,
                                       Place = Results.Place,
                                       Medal = Results.Medal
                                   };

                return data.ToList();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public class OlympicData
        {
            public int OlympicID { get; set; }
            public int Oyear { get; set; }
            public string Otype { get; set; }
            public string HostCountry { get; set; }
            public string City { get; set; }
            public string TypeSport { get; set; }
            public string ParticipantName { get; set; }
            public int CompetitionNumber { get; set; }
            public int Place { get; set; }
            public string Medal { get; set; }
        }
    }
}

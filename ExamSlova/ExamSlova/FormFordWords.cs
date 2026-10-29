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

namespace ExamSlova
{
    public partial class FormFordWords : Form
    {
        public event Action<List<string>> WordsUpdated;

        List<string> words = new List<string>();

        public FormFordWords(List<string> word)
        {
            InitializeComponent();
            if (word != null)
            {
                this.words = word;
                foreach (string w in words)
                {
                    listBoxWords.Items.Add(w);
                }
            }
            
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxWord.Text))
            {
                listBoxWords.Items.Add(textBoxWord.Text);
                words.Add(textBoxWord.Text);
                textBoxWord.Text = "";
                WordsUpdated?.Invoke(words); 
            }
        }

        private void buttonDelWord_Click(object sender, EventArgs e)
        {
            if (listBoxWords.SelectedIndex != -1)
            {
                words.RemoveAt(listBoxWords.SelectedIndex);
                listBoxWords.Items.RemoveAt(listBoxWords.SelectedIndex);
                WordsUpdated?.Invoke(words); 
            }
        }

        private async void buttonAddFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "(*.txt)|*.txt";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(of.FileName))
                    {
                        while (sr.Peek() >= 0) 
                        {
                            string word = await sr.ReadLineAsync();

                            if (!string.IsNullOrWhiteSpace(word)) 
                            {
                                listBoxWords.Items.Add(word);
                                words.Add(word);
                            }
                        }
                    }
                    WordsUpdated?.Invoke(words); 
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class Scoreboard : Form
    {
        public List<Score> ScoreList { get; set; } = new List<Score>();
        public Scoreboard()
        {
            InitializeComponent();
            AnalyzeFileScore();
            ShowScore();
            CenterAll();
        }

        private void CenterAll()
        {
            foreach (Control c in this.Controls)
            {
                c.Left = Width / 2 - c.Width / 2;
            }
        }

        private void ShowScore()
        {
            for (int i = 0; i < 10; i++)
            {
                Label label = new Label();
                Controls.Add(label);
                if (i < ScoreList.Count && ScoreList[i] != null)
                {
                    label.Text = $"{ScoreList[i].Name} {ScoreList[i].Points}";
                }
                else
                {
                    label.Text = "EMPTY";
                }
                label.AutoSize = true;
                //label.Left = Width/2 - label.Width/2;
                label.Top = 140 + this.Height / 20 * i;

            }
        }

        private void AnalyzeFileScore()
        {
            string path = @"files/score.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] subs = line.Split(';');
                    Score score = new Score(subs[0], int.Parse(subs[1]));
                    ScoreList.Add(score);
                }
            }

            ScoreList = ScoreList.OrderByDescending(o => o.Points).ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

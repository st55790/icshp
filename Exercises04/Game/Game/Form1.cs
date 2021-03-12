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

namespace Game
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Stats stats = new Stats();
        private int typeOfGame = 0;
        private List<string> wordList= new List<string>();
        private string actualWord = "";

        public Form1()
        {
            InitializeComponent();
            gameListBox.Items.Clear();
            stats.UpdatedStats += UpdateStatsHadnler;

        }

        private void UpdateStatsHadnler(object sender, EventArgs e)
        {
            correctLabel.Text = $"Correct: {stats.Correct}";
            missedLabel.Text = $"Missed: {stats.Missed}";
            accurancyLabel.Text = $"Accuracy: {stats.Accuracy}%";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (typeOfGame == 0)
            {
                gameListBox.Items.Add((Keys)random.Next('A', 'Z'));
                if (gameListBox.Items.Count > 6)
                {
                    timer1.Stop();
                    gameListBox.Items.Clear();
                    gameListBox.Items.Add("GAME OVER!");
                    WriteResults("chargameresults.txt");
                }
            }
            else {
                if (difficultProgresBar.Value + 20 > 800)
                {
                    difficultProgresBar.Value = 800;
                    timer1.Stop();
                    gameListBox.Items.Clear();
                    gameListBox.Items.Add("GAME OVER!");
                    WriteResults("wordgameresults.txt");
                   
                }
                else { 
                    difficultProgresBar.Value += 20;
                }
            }
        }


        private void WriteResults(string v)
        {
            string readText = File.ReadAllText(v);
            string[] results = readText.Split(";");

            if (stats.Accuracy > int.Parse(results[2])) { 
                string txt = $"{stats.Correct};{stats.Missed};{stats.Accuracy}";
                File.WriteAllText(v, txt);
            }
        }

        private void GameListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (typeOfGame == 0)
            {

                if (gameListBox.Items.Contains(e.KeyCode))
                {
                    gameListBox.Items.Remove(e.KeyCode);
                    gameListBox.Refresh();
                    stats.Update(true);
                }
                else
                {
                    stats.Update(false);
                }

                if (timer1.Interval > 400)
                {
                    timer1.Interval -= 60;
                }
                else if (timer1.Interval > 250)
                {
                    timer1.Interval -= 15;
                }
                else if (timer1.Interval > 150)
                {
                    timer1.Interval -= 8;
                }

                difficultProgresBar.Value = 800 - timer1.Interval;
                if (difficultProgresBar.Value > 800 || difficultProgresBar.Value < 0)
                {
                    difficultProgresBar.Value = 0;
                }
            }
            else {
                if (difficultProgresBar.Value != 800) { 
                    if (actualWord[0].Equals((char)e.KeyCode))
                    {
                        actualWord = actualWord.Substring(1);
                        if (actualWord == "") {
                            actualWord = wordList[random.Next(0, wordList.Count)].ToUpper();
                        }
                        gameListBox.Items.Clear();
                        gameListBox.Items.Add(actualWord);
                        stats.Update(true);
                    }
                    else
                    {
                        stats.Update(false);
                    }
                }
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
            timer1.Start();
        }

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string about = "Tato hra slouží pro procvičení psaní na klávesnici. Byla vytvořena jako úkol ke cvičení číslo 4. Hra generuje náhodná písmena" +
                "a našim úkolem je psát písmena v libobolném pořadí. Hra končí pokud je zobrazeno více než 6 písmen.\n";
            string about2 = "\nAplikace obsahuje i rozšíření, kdy běží čas a uživatel píše celé náhodně generovaná slova ze seznamu.";
            MessageBox.Show(about + about2, "About", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            timer1.Start();
        }

        private void Restart() {

            stats.Restart();
            gameListBox.Items.Clear();
            timer1.Interval = 800;
            stats.OnUpdatedStats();
            timer1.Start();
        }

        private void CharGame_Click(object sender, EventArgs e)
        {
            typeOfGame = 0;
            Restart();
        }

        private void WordGame_Click(object sender, EventArgs e)
        {
            ReadWords();
            typeOfGame = 1;
            Restart();
            actualWord = wordList[random.Next(0, wordList.Count)].ToUpper();
            gameListBox.Items.Add(actualWord);
        }

        private void ReadWords() {
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("wordlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                wordList.Add(line);
            }
            
            file.Close();
        }

        private void ResultsMenu_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string readCharResults = File.ReadAllText("chargameresults.txt");
            string readWordResults = File.ReadAllText("wordgameresults.txt");

            string[] resultsChar = readCharResults.Split(";");
            string[] resultsWord = readWordResults.Split(";");

            string results = $"Best char result: Correct: {resultsChar[0]}, Missed: {resultsChar[1]}, Accuracy: {resultsChar[2]}%\n" +
                $"Best char result: Correct: { resultsWord[0]}, Missed: { resultsWord[1]}, Accuracy: { resultsWord[2]}%\n";
            MessageBox.Show(results);
            timer1.Start();
        }
    }
}

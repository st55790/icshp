using ChampionsLeague.Entity;
using System;
using System.IO;
using System.Windows.Forms;

namespace ChampionsLeague
{
    public partial class SaveForm : Form
    {
        Players players;
        public SaveForm(Players players)
        {
            InitializeComponent();
            LoadTeams();
            this.players = players;
        }

        private void LoadTeams()
        {
            foreach (FootballClub fc in (FootballClub[])Enum.GetValues(typeof(FootballClub)))
            {
                if (FootballClubInfo.GetClubName(fc) != "")
                {
                    checkedListBox.Items.Add(FootballClubInfo.GetClubName(fc));
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "ChampiopnsLeagueStrikers.txt";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    for (int i = 0; i < checkedListBox.Items.Count; i++)
                    {
                        for (int j = 0; j < players.CountPlayers; j++)
                        {
                            Player tmpPlayer = players[j];
                            if (FootballClubInfo.GetClubName(tmpPlayer.Club) == checkedListBox.Items[i].ToString() && checkedListBox.GetItemChecked(i))
                            {
                                streamWriter.WriteLine($"{tmpPlayer.Club};{tmpPlayer.Name};{tmpPlayer.Goals}");
                            }
                        }
                    }
                    streamWriter.Close();
                    stream.Close();
                }
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

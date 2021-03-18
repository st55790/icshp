using System;
using System.Windows.Forms;

namespace ChampionsLeague
{
    public partial class BestClubs : Form
    {
        public BestClubs(int goals, FootballClub[] clubs)
        {
            InitializeComponent();
            textBoxGoals.Text = goals.ToString();
            foreach (var item in clubs)
            {
                if (FootballClubInfo.GetClubName(item) != "")
                {
                    listViewBestClubs.Items.Add(FootballClubInfo.GetClubName(item));
                }
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

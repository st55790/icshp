using System;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class ShootinGame : Form
    {
        public ShootinGame()
        {
            InitializeComponent();
        }

        private void EngGameLabel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Opravdu chcete hru ukončit?", "Ukončení", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ScoreboardLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Scoreboard scoreboard = new Scoreboard();
            if (scoreboard.ShowDialog() == DialogResult.OK)
            {

            }
            this.Show();
        }

        private void SingleplayerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Singleplayer single = new Singleplayer();
            if (single.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }

        }

        private void MultiplayerLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This mode is only for subscribers!");
        }
    }
}

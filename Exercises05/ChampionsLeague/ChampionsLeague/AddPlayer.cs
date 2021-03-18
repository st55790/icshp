using ChampionsLeague.Entity;
using System;
using System.Windows.Forms;

namespace ChampionsLeague
{
    public partial class AddPlayer : Form
    {
        public Player NewPlayer { get; set; } = new Player();
        public AddPlayer(Player player)
        {
            InitializeComponent();
            foreach (var item in (FootballClub[])Enum.GetValues(typeof(FootballClub)))
            {
                comboBoxClub.Items.Add(item);
            }
            if (player != null)
            {
                textBoxName.Text = player.Name;
                textBoxGoals.Text = player.Goals.ToString();
                comboBoxClub.SelectedIndex = comboBoxClub.FindStringExact(FootballClubInfo.GetClubName(player.Club));
            }
        }

        private void AddPlayer_Load(object sender, EventArgs e)
        {
            buttonOk.DialogResult = DialogResult.OK;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                NewPlayer.Name = textBoxName.Text;
                NewPlayer.Goals = int.Parse(textBoxGoals.Text);
                NewPlayer.Club = (FootballClub)comboBoxClub.SelectedIndex;
            }
            catch (Exception ex)
            {
                NewPlayer = null;
                MessageBox.Show($"Some was wrong?! \n\n{ex.ToString()}");
            }

                   
        }

        private void buttonStorno_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

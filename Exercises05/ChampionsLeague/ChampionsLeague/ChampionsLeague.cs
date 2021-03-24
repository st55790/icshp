using ChampionsLeague.Entity;
using System;
using System.IO;
using System.Windows.Forms;

namespace ChampionsLeague
{
    public partial class ChampionsLeague : Form
    {

        bool registration = false;
        public Players allPlayers = new Players();
        public ChampionsLeague()
        {
            InitializeComponent();
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            AddPlayer addForm = new AddPlayer(player);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (addForm.NewPlayer != null) { 
                    player = addForm.NewPlayer;
                    allPlayers.Add(player);
                }
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridView.Rows.Clear();
            for (int i = 0; i < allPlayers.CountPlayers; i++)
            {
                if (allPlayers[i] != null)
                {
                    DataGridViewRow newRow = (DataGridViewRow)dataGridView.Rows[0].Clone();
                    newRow.Cells[0].Value = allPlayers[i].Name;
                    newRow.Cells[1].Value = allPlayers[i].Goals.ToString();
                    newRow.Cells[2].Value = FootballClubInfo.GetClubName(allPlayers[i].Club);
                    dataGridView.Rows.Add(newRow);
                }
            }
        }

        private void ButtonRemove_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < allPlayers.CountPlayers; i++)
            {
                if (allPlayers[i].Name == dataGridView.SelectedCells[0].Value.ToString())
                {
                    allPlayers.Remove(i);
                }
                //dataGridView.SelectedCells.ToString();
            }
            RefreshGrid();
        }

        private void ButtonEdit_Click_1(object sender, EventArgs e)
        {
            Player player = null;
            for (int i = 0; i < allPlayers.CountPlayers; i++)
            {
                if (allPlayers[i].Name == dataGridView.SelectedCells[0].Value.ToString())
                {
                    player = allPlayers[i];
                    allPlayers.Remove(i);
                    AddPlayer editForm = new AddPlayer(player);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        if (editForm.NewPlayer != null) { 
                            player = editForm.NewPlayer;                           
                        }
                        allPlayers.Add(player);
                    }
                    RefreshGrid();
                }
            }
        }

        private void ButtonBestClub_Click_1(object sender, EventArgs e)
        {
            int goals;
            FootballClub[] clubs;
            allPlayers.GetBestClubs(out clubs, out goals);
            BestClubs bestClubsForm = new BestClubs(goals, clubs);
            bestClubsForm.ShowDialog();
        }

        private void ButtonRegistration_Click_1(object sender, EventArgs e)
        {
            registration = true;
            if (registration == true)
            {
                allPlayers.CountChange += PrintInfo;
            }
        }

        private void PrintInfo(object sender, CountChangeEventArgs args)
        {
            listBox.Items.Add($"Original count of players {args.OriginalCount}, change on {args.OriginalCount + 1}");
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            registration = false;
            allPlayers.CountChange -= PrintInfo;
        }

        private void ButtonExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveForm saveForm = new SaveForm(allPlayers);
            saveForm.ShowDialog();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string line = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                StreamReader stream = new StreamReader(openFileDialog.FileName);
                while ((line = stream.ReadLine()) != null) {
                    string[] data = line.Split(';');
                    Player player = new Player();
                    player.Name = data[1];
                    player.Club = (FootballClub)Enum.Parse(typeof(FootballClub), data[0]);
                    player.Goals = int.Parse(data[2]);
                    allPlayers.Add(player);
                }
                stream.Close();
            }
            RefreshGrid();
        }
    }
}

using System;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public class Bonus
    {
        private Random randNum = new Random();
        public PictureBox BonusPictureBox { get; set; } = new PictureBox();

        public void MakeBonus(Form form)
        {
            int rand = randNum.Next(0, 100);
            int x = randNum.Next(0, 1150);
            int y = randNum.Next(0, 750);

            BonusPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            BonusPictureBox.Left = x;
            BonusPictureBox.Top = y;

            if (rand <= 5)
            {
                BonusPictureBox.Tag = "slow";
                BonusPictureBox.Image = Properties.Resources.slow;
            }
            else if (rand > 5 && 7 >= rand)
            {
                BonusPictureBox.Tag = "nuke";
                BonusPictureBox.Image = Properties.Resources.nuke;
            }
            else if (rand > 7 && 13 >= rand)
            {
                BonusPictureBox.Tag = "heart";
                BonusPictureBox.Image = Properties.Resources.heart;
            }
            else if (rand > 13 && 20 >= rand)
            {
                BonusPictureBox.Tag = "moneybag";
                BonusPictureBox.Image = Properties.Resources.moneyback;
            }
            else if (rand > 20 && 26 >= rand)
            {
                BonusPictureBox.Tag = "speed";
                BonusPictureBox.Image = Properties.Resources.fulmine3;
            }
            else
            {
                BonusPictureBox.Tag = "coin";
                BonusPictureBox.Image = Properties.Resources.coin;
            }  
        }

    }
}

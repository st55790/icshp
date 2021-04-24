using System;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public class Zombie
    {
        public int speed = 1;
        private Random randNum = new Random();
        public PictureBox ZombiePictureBox { get; set; } = new PictureBox();

        public void MakeZombie(Form form)
        {
            ZombiePictureBox.Tag = "zombie";
            ZombiePictureBox.Image = Properties.Resources.zombiedown;

            if (randNum.Next(0, 2) == 0)
            {
                ZombiePictureBox.Left = randNum.Next(0, 1200);
                if (randNum.Next(0, 2) == 0)
                {
                    ZombiePictureBox.Top = randNum.Next(-100, -70);
                }
                else
                {
                    ZombiePictureBox.Top = randNum.Next(870, 900);
                }
            }
            else
            {
                ZombiePictureBox.Top = randNum.Next(0, 800);
                if (randNum.Next(0, 2) == 0)
                {
                    ZombiePictureBox.Left = randNum.Next(-100, -70);
                }
                else
                {
                    ZombiePictureBox.Left = randNum.Next(1270, 1300);
                }
            }

            ZombiePictureBox.Visible = true;

            form.Controls.Add(ZombiePictureBox);
            ZombiePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class Singleplayer : Form
    {
        private bool left, right, up, down;
        private int zombiesCount = 1;
        private int playerHealth = 100;
        private int playerSpeed = 3;
        private int enemySpeed = 1;
        private int score = 0;
        private string facing = "right";
        private Random randNum = new Random();
        private List<PictureBox> zombies = new List<PictureBox>();
        private List<PictureBox> blocks = new List<PictureBox>();
        private List<PictureBox> bonusList = new List<PictureBox>();
        private bool pause = false;
        private delegate void Gameover();
        private event Gameover gameoverCallBack;

        public Singleplayer()
        {
            InitializeComponent();
            SetPause();
            RestartGame();
            LoadMap();
            gameoverCallBack += CheckIsPlayerAlive;
        }

        private void SetPause()
        {
            pauseLabel.Dock = DockStyle.Fill;
        }

        private void SingleplayerTimer(object sender, EventArgs e)
        {
            CheckLevel();
            SpawnZombies();
            scoreLabel.Text = $"Score: {score}";
            lives.Text = $"{playerHealth} HP";

            //Player movement OK!
            if (!CollisionWithBlock()) { 
                if (up == true && player.Top > 0)
                {
                    player.Top -= playerSpeed;
                }
                if (down == true && player.Top < this.ClientSize.Height - player.Height)
                {
                    player.Top += playerSpeed;
                }
                if (right == true && player.Left < this.ClientSize.Width - player.Width)
                {
                    player.Left += playerSpeed;
                }
                if (left == true && player.Left > 0)
                {
                    player.Left -= playerSpeed;
                }
            }
            if (CollisionWithBlock())
            {
                foreach (Control block in this.Controls)
                {
                    if (block is PictureBox && (string)block.Tag == "block")
                    {
                        if (player.Bounds.IntersectsWith(block.Bounds))
                        {
                            //Player leva, block prava
                            if (player.Left <= block.Left + block.Width && player.Left > block.Left + block.Width/2)//40
                            {
                                player.Left = block.Left + block.Width + 1;
                                
                            }
                            //player prava, block leva
                            else if (player.Left + player.Width >= block.Left && player.Left + player.Width < block.Left + block.Width/2)//10
                            {
                                player.Left = block.Left - player.Width - 1;
                                
                            }
                            //player top, block bot
                            else if (player.Top <= block.Top + block.Height && player.Top > block.Top + block.Height/2)//40
                            {

                                player.Top = block.Top + block.Height + 1;
                                
                            }
                            //player bot, block top
                            else if (player.Top + player.Height >= block.Top && player.Top + player.Height < block.Top + block.Height/2)//10
                            {
                                player.Top = block.Top - player.Height - 1;
                                
                            }
                        }
                    }
                }
            }

            //Collision player with bonus
            foreach (Control bonus in this.Controls)
            {
                if (bonus.Bounds.IntersectsWith(player.Bounds))
                {
                    if (bonus is PictureBox && (string)bonus.Tag == "coin")
                    {
                        score += 500;
                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                    }
                    if (bonus is PictureBox && (string)bonus.Tag == "moneybag")
                    {
                        score += 1000;
                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                    }
                    if (bonus is PictureBox && (string)bonus.Tag == "slow")
                    {
                        playerSpeed = 1;
                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                    }
                    if (bonus is PictureBox && (string)bonus.Tag == "speed")
                    {
                        if (playerSpeed < 5)
                        {
                            playerSpeed++;
                        }
                        else
                        {
                            playerSpeed = 5;
                        }

                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                    }
                    if (bonus is PictureBox && (string)bonus.Tag == "heart")
                    {
                        if (playerHealth <= 80)
                        {
                            playerHealth += 20;
                        }
                        else
                        {
                            playerHealth = 100;
                        }
                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                    }
                    if (bonus is PictureBox && (string)bonus.Tag == "nuke")
                    {
                        //without for loop delete 2-3 zombies
                        for (int i = 0; i < zombiesCount; i++)
                        {
                            foreach (Control zombie in this.Controls)
                            {
                                if (zombie is PictureBox && (string)zombie.Tag == "zombie")
                                {
                                    this.Controls.Remove(zombie);
                                    ((PictureBox)zombie).Dispose();
                                    zombies.Remove((PictureBox)zombie);
                                }
                            }
                        }
                        this.Controls.Remove(bonus);
                        ((PictureBox)bonus).Dispose();
                        bonusList.Remove(((PictureBox)bonus));
                        CheckLevel();
                    }
                }
            }

            //Zombie move + collision with player
            foreach (Control zombie in this.Controls)
            {
                if (zombie is PictureBox && (string)zombie.Tag == "zombie")
                {

                    if (zombie.Left > player.Left)
                    {
                        zombie.Left -= enemySpeed;
                        ((PictureBox)zombie).Image = Properties.Resources.zombieleft;
                    }
                    if (zombie.Left < player.Left)
                    {
                        zombie.Left += enemySpeed;
                        ((PictureBox)zombie).Image = Properties.Resources.zombieright;
                    }
                    if (zombie.Top > player.Top)
                    {
                        zombie.Top -= enemySpeed;
                        ((PictureBox)zombie).Image = Properties.Resources.zombieup;
                    }
                    if (zombie.Top < player.Top)
                    {
                        zombie.Top += enemySpeed;
                        ((PictureBox)zombie).Image = Properties.Resources.zombiedown;
                    }

                    if (zombie.Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth -= 10;

                        this.Controls.Remove(zombie);
                        zombies.Remove((PictureBox)zombie);

                        //CheckIsPlayerAlive();
                        gameoverCallBack?.Invoke();
                    }
                }

                foreach (Control bullet in this.Controls)
                {
                    if (bullet is PictureBox && (string)bullet.Tag == "bullet" && zombie is PictureBox && (string)zombie.Tag == "zombie")
                    {

                        if (zombie.Bounds.IntersectsWith(bullet.Bounds))
                        {
                            this.Controls.Remove(bullet);
                            ((PictureBox)bullet).Dispose();
                            this.Controls.Remove(zombie);
                            ((PictureBox)zombie).Dispose();
                            zombies.Remove((PictureBox)zombie);
                            score += 100;
                        }
                    }
                }

            }

            //Collision zombie with block OK! 
            foreach (Control block in this.Controls)
            {
                if (block is PictureBox && (string)block.Tag == "block")
                {
                    foreach (Control bullet in this.Controls)
                    {
                        if (bullet is PictureBox && (string)bullet.Tag == "bullet" && block is PictureBox && (string)block.Tag == "block")
                        {

                            if (block.Bounds.IntersectsWith(bullet.Bounds))
                            {
                                this.Controls.Remove(bullet);
                                ((PictureBox)bullet).Dispose();
                            }
                        }
                    }

                    foreach (Control zombie in this.Controls)
                    {
                        if (zombie is PictureBox && (string)zombie.Tag == "zombie" && block is PictureBox && (string)block.Tag == "block")
                        {

                            if (block.Bounds.IntersectsWith(zombie.Bounds))
                            {
                                //Leva zombie + prava blok
                                if (zombie.Left <= block.Left + block.Width && zombie.Left > block.Left + block.Width/2)
                                {
                                    zombie.Left = block.Left + block.Width;
                                }
                                //Prava zombie + leva blok
                                else if (zombie.Left + zombie.Width >= block.Left && zombie.Left + zombie.Width < block.Left + block.Width/2)
                                {
                                    zombie.Left = block.Left - zombie.Width;
                                }
                                //Top zombie + spodek blok
                                else if (zombie.Top <= block.Top + block.Height && zombie.Top > block.Top + block.Height/2)
                                {
                                    zombie.Top = block.Top + block.Height;
                                }
                                //Spodek zombie + top blok
                                else if (zombie.Top + zombie.Height >= block.Top && zombie.Top + zombie.Height < block.Top + block.Height/2)
                                {
                                    zombie.Top = block.Top - zombie.Height;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool CollisionWithBlock()
        {
            foreach (Control block in this.Controls)
            {
                if (block is PictureBox && (string)block.Tag == "block")
                {
                    if (player.Bounds.IntersectsWith(block.Bounds))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        private void SpawnZombies()
        {
            if (zombies.Count < zombiesCount)
            {
                Zombie zombie = new Zombie();
                zombie.MakeZombie(this);

                zombies.Add(zombie.ZombiePictureBox);
                this.Controls.Add(zombie.ZombiePictureBox);
                player.BringToFront();
            }
        }

        //Checking if player is alive + show form for enter name to score OK! 
        private void CheckIsPlayerAlive()
        {
            if (playerHealth <= 0)
            {
                singleplayerTimer.Stop();
                bonusTimer.Stop();
                scoreTimer.Stop();
                MessageBox.Show("End game");

                EnterName enterForm = new EnterName(score);
                if (enterForm.ShowDialog() == DialogResult.OK)
                {
                    enterForm.Dispose();
                }
                this.Close();
            }
        }

        //Movement player + shooting + pause OK!
        private void Singleplayer_KeyDown(object sender, KeyEventArgs e)
        {
            //Movement
            if (e.KeyCode == Keys.Up)
            {
                up = true;
                facing = "up";
                player.Size = new Size(30, 50);
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = true;
                facing = "down";
                player.Size = new Size(30, 50);
                player.Image = Properties.Resources.down;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                facing = "left";
                player.Size = new Size(50, 30);
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                facing = "right";
                player.Size = new Size(50, 30);
                player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.NumPad0)
            {
                Shoot(facing);
            }

            //Pause
            if (e.KeyCode == Keys.P)
            {
                if (pause == false)
                {
                    pause = true;

                    this.BackColor = Color.OliveDrab;
                    bonusTimer.Stop();
                    singleplayerTimer.Stop();
                    scoreTimer.Stop();

                    pauseLabel.Visible = true;
                    player.Visible = false;
                }
                else
                {
                    this.BackColor = Color.YellowGreen;
                    pause = false;
                    bonusTimer.Start();
                    singleplayerTimer.Start();
                    scoreTimer.Start();

                    pauseLabel.Visible = false;
                    player.Visible = true;
                }
            }
        }

        //Stop movement OK!
        private void Singleplayer_KeyUp(object sender, KeyEventArgs e)
        {
            //Movement
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        //Shooting player OK!
        private void Shoot(string direct)
        {
            //This is the function thats makes the new bullets in this game
            Bullet shoot = new Bullet();
            shoot.direction = direct;

            if (direct == "right")
            {
                shoot.bulletTop = (int)(player.Top + (player.Height / 1.32));
                shoot.bulletLeft = (int)(player.Left + player.Width + (player.Width / 10));
            }
            if (direct == "left")
            {
                shoot.bulletTop = (int)(player.Top + (player.Height / 6));
                shoot.bulletLeft = (int)(player.Left - (player.Width / 7));
            }
            if (direct == "up")
            {
                shoot.bulletTop = (int)(player.Top - (player.Height / 8)); 
                shoot.bulletLeft = (int)(player.Left + (player.Width / 1.32)); 
            }
            if (direct == "down")
            {
                shoot.bulletTop = (int)(player.Top + player.Height + (player.Height / 10));
                shoot.bulletLeft = (int)(player.Left + (player.Width / 6));
            }

            shoot.MakeBullet(this);
        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.right;
            player.Size = new Size(50, 30);

            foreach (PictureBox pc in zombies)
            {
                this.Controls.Remove(pc);
            }

            zombies.Clear();

            left = false;
            right = false;
            up = false;
            down = false;

        }

        //Change zombies count by score
        private void CheckLevel()
        {
            if (score < 1000)
            {
                zombiesCount = 2;
            }
            else if (score < 2000)
            {
                zombiesCount = 4;
            }
            else if (score < 5000)
            {
                zombiesCount = 6;
            }
            else if (score < 10000)
            {
                zombiesCount = 8;
                enemySpeed = 2;
            }
            else if (score < 15000)
            {
                zombiesCount = 10;
            }
            else
            {
                zombiesCount = 12;
                enemySpeed = 3;
            }
        }

        //Just add point to score OK! 
        private void BonusTimer(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            do
            {
                bonus.MakeBonus(this);
            } while (CheckCollision(bonus.BonusPictureBox));

            bonusList.Add(bonus.BonusPictureBox);
            this.Controls.Add(bonus.BonusPictureBox);
            player.BringToFront();

            if (bonusList.Count > 10) {
                PictureBox pictureBox = bonusList.First();

                this.Controls.Remove(pictureBox);
                (pictureBox).Dispose();
                bonusList.Remove(pictureBox);
            }
        }

        //Read data from file and create obstacles map OK!
        private void LoadMap()
        {
            try
            {
                string text = "";
                using (var sr = new StreamReader("files/terrain.txt"))
                {
                    text = sr.ReadToEnd();
                    sr.Close();
                }
                GenerateMap(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Generate each blocks OK!
        private void GenerateMap(string text)
        {
            int counter = 0;
            int x = 0;
            int y = 0;
            for (int i = 0; i <= 15; i++)
            {
                for (int j = 0; j <= 25; j++)
                {
                    if (text[counter].Equals('1'))
                    {
                        MakeBlock(x, y);
                    }
                    counter++;
                    x += 50;
                }
                x = 0;
                y += 50;
            }
        }

        //Add point to score per second
        private void ScoreTimer(object sender, EventArgs e)
        {
            score++;
        }

        //Create block OK!
        private void MakeBlock(int x, int y)
        {
            PictureBox block = new PictureBox();
            block.Tag = "block";
            block.Image = Properties.Resources.stone;
            block.Left = x;
            block.Top = y;
            block.SizeMode = PictureBoxSizeMode.AutoSize;
            blocks.Add(block);
            this.Controls.Add(block);
            player.BringToFront();
        }

        //Check collision for new bonus OK! 
        private bool CheckCollision(PictureBox bonus)
        {
            foreach (var item in zombies)
            {
                if (bonus.Bounds.IntersectsWith(item.Bounds))
                {
                    return true;
                }
            }

            foreach (var item in blocks)
            {
                if (bonus.Bounds.IntersectsWith(item.Bounds))
                {
                    return true;
                }
            }

            foreach (var item in bonusList)
            {
                if (bonus.Bounds.IntersectsWith(item.Bounds))
                {
                    return true;
                }
            }

            if (bonus.Bounds.IntersectsWith(player.Bounds))
            {
                return true;
            }

            return false;
        }
    }

}
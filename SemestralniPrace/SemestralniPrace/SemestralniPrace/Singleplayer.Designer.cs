namespace SemestralniPrace
{
    partial class Singleplayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.PictureBox();
            this.singleplayerTimer = new System.Windows.Forms.Timer(this.components);
            this.bonusTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreTimer = new System.Windows.Forms.Timer(this.components);
            this.lives = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Location = new System.Drawing.Point(563, 394);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(80, 50);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // singleplayerTimer
            // 
            this.singleplayerTimer.Enabled = true;
            this.singleplayerTimer.Interval = 1;
            this.singleplayerTimer.Tick += new System.EventHandler(this.SingleplayerTimer);
            // 
            // bonusTimer
            // 
            this.bonusTimer.Enabled = true;
            this.bonusTimer.Interval = 3000;
            this.bonusTimer.Tick += new System.EventHandler(this.BonusTimer);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(38, 15);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "label1";
            // 
            // scoreTimer
            // 
            this.scoreTimer.Enabled = true;
            this.scoreTimer.Interval = 1000;
            this.scoreTimer.Tick += new System.EventHandler(this.ScoreTimer);
            // 
            // lives
            // 
            this.lives.AutoSize = true;
            this.lives.Location = new System.Drawing.Point(1150, 9);
            this.lives.Name = "lives";
            this.lives.Size = new System.Drawing.Size(44, 15);
            this.lives.TabIndex = 1;
            this.lives.Text = "100 HP";
            // 
            // pauseLabel
            // 
            this.pauseLabel.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pauseLabel.Location = new System.Drawing.Point(428, 9);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(347, 128);
            this.pauseLabel.TabIndex = 2;
            this.pauseLabel.Text = "PAUSE";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pauseLabel.Visible = false;
            // 
            // Singleplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.lives);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.player);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Singleplayer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Singleplayer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Singleplayer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Singleplayer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer singleplayerTimer;
        private System.Windows.Forms.Timer bonusTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer scoreTimer;
        private System.Windows.Forms.Label lives;
        private System.Windows.Forms.Label pauseLabel;
    }
}
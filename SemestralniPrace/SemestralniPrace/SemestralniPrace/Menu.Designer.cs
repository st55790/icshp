namespace SemestralniPrace
{
    partial class ShootinGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.singleplayerLabel = new System.Windows.Forms.Label();
            this.multiplayerLabel = new System.Windows.Forms.Label();
            this.scoreboardLabel = new System.Windows.Forms.Label();
            this.engGameLabel = new System.Windows.Forms.Label();
            this.screenMenu = new System.Windows.Forms.Panel();
            this.screenMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameNameLabel.Location = new System.Drawing.Point(139, 58);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(521, 46);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "My super shooting game";
            // 
            // singleplayerLabel
            // 
            this.singleplayerLabel.AutoSize = true;
            this.singleplayerLabel.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.singleplayerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.singleplayerLabel.Location = new System.Drawing.Point(310, 157);
            this.singleplayerLabel.Name = "singleplayerLabel";
            this.singleplayerLabel.Size = new System.Drawing.Size(168, 28);
            this.singleplayerLabel.TabIndex = 1;
            this.singleplayerLabel.Text = "Singleplayer";
            this.singleplayerLabel.Click += new System.EventHandler(this.SingleplayerLabel_Click);
            // 
            // multiplayerLabel
            // 
            this.multiplayerLabel.AutoSize = true;
            this.multiplayerLabel.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.multiplayerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.multiplayerLabel.Location = new System.Drawing.Point(312, 213);
            this.multiplayerLabel.Name = "multiplayerLabel";
            this.multiplayerLabel.Size = new System.Drawing.Size(163, 28);
            this.multiplayerLabel.TabIndex = 2;
            this.multiplayerLabel.Text = "Multiplayer";
            this.multiplayerLabel.Click += new System.EventHandler(this.MultiplayerLabel_Click);
            // 
            // scoreboardLabel
            // 
            this.scoreboardLabel.AutoSize = true;
            this.scoreboardLabel.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreboardLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scoreboardLabel.Location = new System.Drawing.Point(316, 268);
            this.scoreboardLabel.Name = "scoreboardLabel";
            this.scoreboardLabel.Size = new System.Drawing.Size(155, 28);
            this.scoreboardLabel.TabIndex = 3;
            this.scoreboardLabel.Text = "Scoreboard";
            this.scoreboardLabel.Click += new System.EventHandler(this.ScoreboardLabel_Click);
            // 
            // engGameLabel
            // 
            this.engGameLabel.AutoSize = true;
            this.engGameLabel.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.engGameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.engGameLabel.Location = new System.Drawing.Point(337, 317);
            this.engGameLabel.Name = "engGameLabel";
            this.engGameLabel.Size = new System.Drawing.Size(114, 27);
            this.engGameLabel.TabIndex = 3;
            this.engGameLabel.Text = "End game";
            this.engGameLabel.Click += new System.EventHandler(this.EngGameLabel_Click);
            // 
            // screenMenu
            // 
            this.screenMenu.BackColor = System.Drawing.Color.SandyBrown;
            this.screenMenu.Controls.Add(this.gameNameLabel);
            this.screenMenu.Controls.Add(this.engGameLabel);
            this.screenMenu.Controls.Add(this.singleplayerLabel);
            this.screenMenu.Controls.Add(this.scoreboardLabel);
            this.screenMenu.Controls.Add(this.multiplayerLabel);
            this.screenMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenMenu.Location = new System.Drawing.Point(0, 0);
            this.screenMenu.Name = "screenMenu";
            this.screenMenu.Size = new System.Drawing.Size(800, 450);
            this.screenMenu.TabIndex = 4;
            // 
            // ShootinGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.screenMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShootinGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu super shooting game";
            this.screenMenu.ResumeLayout(false);
            this.screenMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label gameNameLabel;
        private System.Windows.Forms.Label singleplayerLabel;
        private System.Windows.Forms.Label multiplayerLabel;
        private System.Windows.Forms.Label scoreboardLabel;
        private System.Windows.Forms.Label engGameLabel;
        private System.Windows.Forms.Panel screenMenu;
    }
}


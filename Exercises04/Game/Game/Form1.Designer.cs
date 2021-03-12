namespace Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameListBox = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.charGame = new System.Windows.Forms.ToolStripMenuItem();
            this.wordGame = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.correctLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.missedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.accurancyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.diffucultLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.difficultProgresBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameListBox
            // 
            this.gameListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 131.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameListBox.FormattingEnabled = true;
            this.gameListBox.ItemHeight = 232;
            this.gameListBox.Items.AddRange(new object[] {
            "GAME OVER!"});
            this.gameListBox.Location = new System.Drawing.Point(0, 24);
            this.gameListBox.MultiColumn = true;
            this.gameListBox.Name = "gameListBox";
            this.gameListBox.Size = new System.Drawing.Size(1299, 251);
            this.gameListBox.TabIndex = 0;
            this.gameListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameListBox_KeyDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.aboutMenu,
            this.resultsMenu,
            this.exitMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1299, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // newGame
            // 
            this.newGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.charGame,
            this.wordGame});
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(76, 20);
            this.newGame.Text = "New game";
            // 
            // charGame
            // 
            this.charGame.Name = "charGame";
            this.charGame.Size = new System.Drawing.Size(136, 22);
            this.charGame.Text = "Char game";
            this.charGame.Click += new System.EventHandler(this.CharGame_Click);
            // 
            // wordGame
            // 
            this.wordGame.Name = "wordGame";
            this.wordGame.Size = new System.Drawing.Size(136, 22);
            this.wordGame.Text = "Word game";
            this.wordGame.Click += new System.EventHandler(this.WordGame_Click);
            // 
            // aboutMenu
            // 
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(52, 20);
            this.aboutMenu.Text = "About";
            this.aboutMenu.Click += new System.EventHandler(this.AboutMenu_Click);
            // 
            // resultsMenu
            // 
            this.resultsMenu.Name = "resultsMenu";
            this.resultsMenu.Size = new System.Drawing.Size(78, 20);
            this.resultsMenu.Text = "Best results";
            this.resultsMenu.Click += new System.EventHandler(this.ResultsMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(38, 20);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correctLabel,
            this.missedLabel,
            this.accurancyLabel,
            this.diffucultLabel,
            this.difficultProgresBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 253);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1299, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // correctLabel
            // 
            this.correctLabel.Name = "correctLabel";
            this.correctLabel.Size = new System.Drawing.Size(49, 17);
            this.correctLabel.Text = "Correct:";
            // 
            // missedLabel
            // 
            this.missedLabel.Name = "missedLabel";
            this.missedLabel.Size = new System.Drawing.Size(47, 17);
            this.missedLabel.Text = "Missed:";
            // 
            // accurancyLabel
            // 
            this.accurancyLabel.Name = "accurancyLabel";
            this.accurancyLabel.Size = new System.Drawing.Size(64, 17);
            this.accurancyLabel.Text = "Acurrancy:";
            // 
            // diffucultLabel
            // 
            this.diffucultLabel.Name = "diffucultLabel";
            this.diffucultLabel.Size = new System.Drawing.Size(1022, 17);
            this.diffucultLabel.Spring = true;
            this.diffucultLabel.Text = "Diffuculty";
            this.diffucultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // difficultProgresBar
            // 
            this.difficultProgresBar.Maximum = 800;
            this.difficultProgresBar.Name = "difficultProgresBar";
            this.difficultProgresBar.Size = new System.Drawing.Size(100, 16);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 275);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gameListBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gameListBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ToolStripMenuItem charGame;
        private System.Windows.Forms.ToolStripMenuItem wordGame;
        private System.Windows.Forms.ToolStripMenuItem resultsMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel correctLabel;
        private System.Windows.Forms.ToolStripStatusLabel missedLabel;
        private System.Windows.Forms.ToolStripStatusLabel accurancyLabel;
        private System.Windows.Forms.ToolStripStatusLabel diffucultLabel;
        private System.Windows.Forms.ToolStripProgressBar difficultProgresBar;
        private System.Windows.Forms.Timer timer1;
    }
}


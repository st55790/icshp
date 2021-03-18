namespace ChampionsLeague
{
    partial class BestClubs
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
            this.listViewBestClubs = new System.Windows.Forms.ListView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGoals = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewBestClubs
            // 
            this.listViewBestClubs.HideSelection = false;
            this.listViewBestClubs.Location = new System.Drawing.Point(12, 101);
            this.listViewBestClubs.Name = "listViewBestClubs";
            this.listViewBestClubs.Size = new System.Drawing.Size(335, 156);
            this.listViewBestClubs.TabIndex = 0;
            this.listViewBestClubs.UseCompatibleStateImageBehavior = false;
            this.listViewBestClubs.View = System.Windows.Forms.View.List;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(272, 263);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clubs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of goals";
            // 
            // textBoxGoals
            // 
            this.textBoxGoals.Location = new System.Drawing.Point(13, 32);
            this.textBoxGoals.Name = "textBoxGoals";
            this.textBoxGoals.ReadOnly = true;
            this.textBoxGoals.Size = new System.Drawing.Size(138, 23);
            this.textBoxGoals.TabIndex = 4;
            // 
            // BestClubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 293);
            this.Controls.Add(this.textBoxGoals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.listViewBestClubs);
            this.Name = "BestClubs";
            this.Text = "BestClubs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBestClubs;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGoals;
    }
}
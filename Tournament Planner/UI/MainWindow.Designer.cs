namespace Tournament_Planner.UI
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlCurrentStepContainer = new System.Windows.Forms.Panel();
            this.btnGroupGames = new System.Windows.Forms.Button();
            this.txtTournamentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHello = new System.Windows.Forms.Label();
            this.btnGoToPLayOff = new System.Windows.Forms.Button();
            this.pnlCurrentStepContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(829, 534);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(191, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCurrentStepContainer
            // 
            this.pnlCurrentStepContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCurrentStepContainer.Controls.Add(this.btnGoToPLayOff);
            this.pnlCurrentStepContainer.Controls.Add(this.btnGroupGames);
            this.pnlCurrentStepContainer.Controls.Add(this.txtTournamentName);
            this.pnlCurrentStepContainer.Controls.Add(this.label1);
            this.pnlCurrentStepContainer.Controls.Add(this.lblHello);
            this.pnlCurrentStepContainer.Location = new System.Drawing.Point(13, 13);
            this.pnlCurrentStepContainer.Name = "pnlCurrentStepContainer";
            this.pnlCurrentStepContainer.Size = new System.Drawing.Size(1007, 515);
            this.pnlCurrentStepContainer.TabIndex = 0;
            // 
            // btnGroupGames
            // 
            this.btnGroupGames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroupGames.Location = new System.Drawing.Point(3, 489);
            this.btnGroupGames.Name = "btnGroupGames";
            this.btnGroupGames.Size = new System.Drawing.Size(145, 23);
            this.btnGroupGames.TabIndex = 3;
            this.btnGroupGames.Text = "Go to group games...";
            this.btnGroupGames.UseVisualStyleBackColor = true;
            this.btnGroupGames.Click += new System.EventHandler(this.btnGroupGames_Click);
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTournamentName.Location = new System.Drawing.Point(408, 317);
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(190, 20);
            this.txtTournamentName.TabIndex = 2;
            this.txtTournamentName.Text = "Unnamed tournament";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(405, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your tournament name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHello
            // 
            this.lblHello.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHello.Location = new System.Drawing.Point(405, 251);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(196, 13);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "Welcome to Tournament Planner v0.0.1";
            // 
            // btnGoToPLayOff
            // 
            this.btnGoToPLayOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoToPLayOff.Location = new System.Drawing.Point(154, 489);
            this.btnGoToPLayOff.Name = "btnGoToPLayOff";
            this.btnGoToPLayOff.Size = new System.Drawing.Size(145, 23);
            this.btnGoToPLayOff.TabIndex = 3;
            this.btnGoToPLayOff.Text = "Go to play off...";
            this.btnGoToPLayOff.UseVisualStyleBackColor = true;
            this.btnGoToPLayOff.Click += new System.EventHandler(this.btnGoToPLayOff_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 569);
            this.Controls.Add(this.pnlCurrentStepContainer);
            this.Controls.Add(this.btnNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Tournament Planner";
            this.pnlCurrentStepContainer.ResumeLayout(false);
            this.pnlCurrentStepContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlCurrentStepContainer;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.TextBox txtTournamentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGroupGames;
        private System.Windows.Forms.Button btnGoToPLayOff;
    }
}


namespace Tournament_Planner.UI
{
    partial class ScheduleAndResultsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tblMatches = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayerVsPlayer = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.pnlGames = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMatches)).BeginInit();
            this.pnlResult.SuspendLayout();
            this.pnlGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tblMatches);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlResult);
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Size = new System.Drawing.Size(886, 591);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.TabIndex = 0;
            // 
            // tblMatches
            // 
            this.tblMatches.AllowUserToAddRows = false;
            this.tblMatches.AllowUserToDeleteRows = false;
            this.tblMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMatches.Location = new System.Drawing.Point(0, 0);
            this.tblMatches.Name = "tblMatches";
            this.tblMatches.ReadOnly = true;
            this.tblMatches.RowHeadersVisible = false;
            this.tblMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblMatches.Size = new System.Drawing.Size(439, 591);
            this.tblMatches.TabIndex = 0;
            this.tblMatches.SelectionChanged += new System.EventHandler(this.tblMatches_SelectionChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(2, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(438, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start match";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(4, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(430, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Finish match";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(3, 21);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(43, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(53, 20);
            this.maskedTextBox2.Mask = "00:00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(43, 20);
            this.maskedTextBox2.TabIndex = 1;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(101, 20);
            this.maskedTextBox3.Mask = "00:00";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(43, 20);
            this.maskedTextBox3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Game 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Game 3";
            // 
            // lblPlayerVsPlayer
            // 
            this.lblPlayerVsPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerVsPlayer.Location = new System.Drawing.Point(0, 36);
            this.lblPlayerVsPlayer.Name = "lblPlayerVsPlayer";
            this.lblPlayerVsPlayer.Size = new System.Drawing.Size(436, 23);
            this.lblPlayerVsPlayer.TabIndex = 3;
            this.lblPlayerVsPlayer.Text = "Player vs Player";
            this.lblPlayerVsPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGroup.Location = new System.Drawing.Point(5, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(431, 36);
            this.lblGroup.TabIndex = 4;
            this.lblGroup.Text = "Group X";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlResult
            // 
            this.pnlResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.pnlGames);
            this.pnlResult.Controls.Add(this.lblGroup);
            this.pnlResult.Controls.Add(this.button1);
            this.pnlResult.Controls.Add(this.lblPlayerVsPlayer);
            this.pnlResult.Location = new System.Drawing.Point(2, 33);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(438, 135);
            this.pnlResult.TabIndex = 5;
            // 
            // pnlGames
            // 
            this.pnlGames.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlGames.Controls.Add(this.label3);
            this.pnlGames.Controls.Add(this.label1);
            this.pnlGames.Controls.Add(this.maskedTextBox3);
            this.pnlGames.Controls.Add(this.maskedTextBox1);
            this.pnlGames.Controls.Add(this.label2);
            this.pnlGames.Controls.Add(this.maskedTextBox2);
            this.pnlGames.Location = new System.Drawing.Point(152, 62);
            this.pnlGames.MaximumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.MinimumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.Name = "pnlGames";
            this.pnlGames.Size = new System.Drawing.Size(142, 41);
            this.pnlGames.TabIndex = 6;
            // 
            // ScheduleAndResultsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ScheduleAndResultsControl";
            this.Size = new System.Drawing.Size(886, 591);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblMatches)).EndInit();
            this.pnlResult.ResumeLayout(false);
            this.pnlGames.ResumeLayout(false);
            this.pnlGames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView tblMatches;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPlayerVsPlayer;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Panel pnlGames;
    }
}

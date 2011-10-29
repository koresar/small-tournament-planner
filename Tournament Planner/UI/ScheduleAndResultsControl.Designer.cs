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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tblMatches = new System.Windows.Forms.DataGridView();
            this.groupControl = new Tournament_Planner.UI.GroupControl();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.pnlGames = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGame3 = new System.Windows.Forms.MaskedTextBox();
            this.txtGame1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGame2 = new System.Windows.Forms.MaskedTextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblPlayerVsPlayer = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMatches)).BeginInit();
            this.pnlResult.SuspendLayout();
            this.pnlGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoad);
            this.splitContainer1.Panel2.Controls.Add(this.groupControl);
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
            // 
            // groupControl
            // 
            this.groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl.Location = new System.Drawing.Point(6, 175);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(430, 161);
            this.groupControl.TabIndex = 1;
            // 
            // pnlResult
            // 
            this.pnlResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.pnlGames);
            this.pnlResult.Controls.Add(this.lblGroup);
            this.pnlResult.Controls.Add(this.btnFinish);
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
            this.pnlGames.Controls.Add(this.txtGame3);
            this.pnlGames.Controls.Add(this.txtGame1);
            this.pnlGames.Controls.Add(this.label2);
            this.pnlGames.Controls.Add(this.txtGame2);
            this.pnlGames.Location = new System.Drawing.Point(152, 62);
            this.pnlGames.MaximumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.MinimumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.Name = "pnlGames";
            this.pnlGames.Size = new System.Drawing.Size(142, 41);
            this.pnlGames.TabIndex = 6;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game 1";
            // 
            // txtGame3
            // 
            this.txtGame3.Location = new System.Drawing.Point(101, 20);
            this.txtGame3.Mask = "00:00";
            this.txtGame3.Name = "txtGame3";
            this.txtGame3.Size = new System.Drawing.Size(43, 20);
            this.txtGame3.TabIndex = 2;
            // 
            // txtGame1
            // 
            this.txtGame1.Location = new System.Drawing.Point(3, 21);
            this.txtGame1.Mask = "00:00";
            this.txtGame1.Name = "txtGame1";
            this.txtGame1.Size = new System.Drawing.Size(43, 20);
            this.txtGame1.TabIndex = 0;
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
            // txtGame2
            // 
            this.txtGame2.Location = new System.Drawing.Point(53, 20);
            this.txtGame2.Mask = "00:00";
            this.txtGame2.Name = "txtGame2";
            this.txtGame2.Size = new System.Drawing.Size(43, 20);
            this.txtGame2.TabIndex = 1;
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGroup.Location = new System.Drawing.Point(5, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(428, 36);
            this.lblGroup.TabIndex = 4;
            this.lblGroup.Text = "Group X";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(3, 109);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(430, 21);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Finish match";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblPlayerVsPlayer
            // 
            this.lblPlayerVsPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerVsPlayer.Location = new System.Drawing.Point(4, 36);
            this.lblPlayerVsPlayer.Name = "lblPlayerVsPlayer";
            this.lblPlayerVsPlayer.Size = new System.Drawing.Size(429, 23);
            this.lblPlayerVsPlayer.TabIndex = 3;
            this.lblPlayerVsPlayer.Text = "Player vs Player";
            this.lblPlayerVsPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(6, 565);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(429, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load schedule...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(6, 536);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(429, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save schedule snapshot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView tblMatches;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtGame3;
        private System.Windows.Forms.MaskedTextBox txtGame2;
        private System.Windows.Forms.MaskedTextBox txtGame1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblPlayerVsPlayer;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Panel pnlGames;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private GroupControl groupControl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
    }
}

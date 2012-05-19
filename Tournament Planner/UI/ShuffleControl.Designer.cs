namespace Tournament_Planner.UI
{
    partial class ShuffleControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblPlayers = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoShuffle = new System.Windows.Forms.Button();
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbPlayersInGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfGames = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlayers)).BeginInit();
            this.pnlGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPlayers
            // 
            this.tblPlayers.AllowUserToAddRows = false;
            this.tblPlayers.AllowUserToDeleteRows = false;
            this.tblPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName});
            this.tblPlayers.Location = new System.Drawing.Point(4, 4);
            this.tblPlayers.MultiSelect = false;
            this.tblPlayers.Name = "tblPlayers";
            this.tblPlayers.ReadOnly = true;
            this.tblPlayers.RowHeadersVisible = false;
            this.tblPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblPlayers.Size = new System.Drawing.Size(189, 492);
            this.tblPlayers.TabIndex = 0;
            // 
            // fullName
            // 
            this.fullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fullName.HeaderText = "Player full name";
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            this.fullName.Width = 106;
            // 
            // btnDoShuffle
            // 
            this.btnDoShuffle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDoShuffle.Location = new System.Drawing.Point(199, 207);
            this.btnDoShuffle.Name = "btnDoShuffle";
            this.btnDoShuffle.Size = new System.Drawing.Size(100, 39);
            this.btnDoShuffle.TabIndex = 1;
            this.btnDoShuffle.Text = "Shuffle";
            this.btnDoShuffle.UseVisualStyleBackColor = true;
            this.btnDoShuffle.Click += new System.EventHandler(this.btnDoShuffle_Click);
            // 
            // pnlGroups
            // 
            this.pnlGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroups.Controls.Add(this.flowLayoutPanel);
            this.pnlGroups.Location = new System.Drawing.Point(306, 4);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(409, 492);
            this.pnlGroups.TabIndex = 2;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(407, 490);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // cmbPlayersInGroup
            // 
            this.cmbPlayersInGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayersInGroup.FormattingEnabled = true;
            this.cmbPlayersInGroup.Location = new System.Drawing.Point(199, 46);
            this.cmbPlayersInGroup.Name = "cmbPlayersInGroup";
            this.cmbPlayersInGroup.Size = new System.Drawing.Size(101, 21);
            this.cmbPlayersInGroup.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(200, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desired number of players in a group";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Location = new System.Drawing.Point(200, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of games:";
            // 
            // lblNumberOfGames
            // 
            this.lblNumberOfGames.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumberOfGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfGames.Location = new System.Drawing.Point(200, 285);
            this.lblNumberOfGames.Name = "lblNumberOfGames";
            this.lblNumberOfGames.Size = new System.Drawing.Size(100, 29);
            this.lblNumberOfGames.TabIndex = 5;
            this.lblNumberOfGames.Text = "#";
            this.lblNumberOfGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShuffleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumberOfGames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPlayersInGroup);
            this.Controls.Add(this.pnlGroups);
            this.Controls.Add(this.btnDoShuffle);
            this.Controls.Add(this.tblPlayers);
            this.Name = "ShuffleControl";
            this.Size = new System.Drawing.Size(718, 499);
            ((System.ComponentModel.ISupportInitialize)(this.tblPlayers)).EndInit();
            this.pnlGroups.ResumeLayout(false);
            this.pnlGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblPlayers;
        private System.Windows.Forms.Button btnDoShuffle;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.Panel pnlGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ComboBox cmbPlayersInGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfGames;

    }
}

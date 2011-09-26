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
            this.tblPlayers = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoShuffle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tblPlayers
            // 
            this.tblPlayers.AllowUserToAddRows = false;
            this.tblPlayers.AllowUserToDeleteRows = false;
            this.tblPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
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
            this.fullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullName.HeaderText = "Player full name";
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            // 
            // btnDoShuffle
            // 
            this.btnDoShuffle.Location = new System.Drawing.Point(199, 4);
            this.btnDoShuffle.Name = "btnDoShuffle";
            this.btnDoShuffle.Size = new System.Drawing.Size(100, 39);
            this.btnDoShuffle.TabIndex = 1;
            this.btnDoShuffle.Text = "Shuffle";
            this.btnDoShuffle.UseVisualStyleBackColor = true;
            this.btnDoShuffle.Click += new System.EventHandler(this.btnDoShuffle_Click);
            // 
            // ShuffleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDoShuffle);
            this.Controls.Add(this.tblPlayers);
            this.Name = "ShuffleControl";
            this.Size = new System.Drawing.Size(718, 499);
            this.Load += new System.EventHandler(this.ShuffleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.Button btnDoShuffle;

    }
}

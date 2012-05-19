namespace Tournament_Planner.UI
{
    partial class PlayOffControl
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManualPlayers = new System.Windows.Forms.Button();
            this.editMatchControl = new Tournament_Planner.UI.EditMatchControl();
            this.groupControl = new Tournament_Planner.UI.GroupControl();
            this.lstManualPlayers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(419, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(475, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save schedule snapshot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(419, 509);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(475, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load schedule...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Play these matches OR";
            // 
            // btnManualPlayers
            // 
            this.btnManualPlayers.Location = new System.Drawing.Point(7, 292);
            this.btnManualPlayers.Name = "btnManualPlayers";
            this.btnManualPlayers.Size = new System.Drawing.Size(142, 23);
            this.btnManualPlayers.TabIndex = 10;
            this.btnManualPlayers.Text = "Enter players manually";
            this.btnManualPlayers.UseVisualStyleBackColor = true;
            this.btnManualPlayers.Click += new System.EventHandler(this.btnManualPlayers_Click);
            // 
            // editMatchControl
            // 
            this.editMatchControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editMatchControl.Location = new System.Drawing.Point(419, 4);
            this.editMatchControl.Name = "editMatchControl";
            this.editMatchControl.Size = new System.Drawing.Size(475, 170);
            this.editMatchControl.TabIndex = 2;
            // 
            // groupControl
            // 
            this.groupControl.Location = new System.Drawing.Point(4, 4);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(409, 264);
            this.groupControl.TabIndex = 1;
            // 
            // lstManualPlayers
            // 
            this.lstManualPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstManualPlayers.FormattingEnabled = true;
            this.lstManualPlayers.Location = new System.Drawing.Point(7, 322);
            this.lstManualPlayers.Name = "lstManualPlayers";
            this.lstManualPlayers.Size = new System.Drawing.Size(406, 199);
            this.lstManualPlayers.TabIndex = 11;
            this.lstManualPlayers.Visible = false;
            // 
            // PlayOffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstManualPlayers);
            this.Controls.Add(this.btnManualPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.editMatchControl);
            this.Controls.Add(this.groupControl);
            this.Name = "PlayOffControl";
            this.Size = new System.Drawing.Size(897, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupControl groupControl;
        private EditMatchControl editMatchControl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManualPlayers;
        private System.Windows.Forms.ListBox lstManualPlayers;

    }
}

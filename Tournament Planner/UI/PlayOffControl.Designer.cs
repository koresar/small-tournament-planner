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
            this.groupControl = new Tournament_Planner.UI.GroupControl();
            this.editMatchControl = new Tournament_Planner.UI.EditMatchControl();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Location = new System.Drawing.Point(4, 4);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(409, 528);
            this.groupControl.TabIndex = 1;
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
            // PlayOffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editMatchControl);
            this.Controls.Add(this.groupControl);
            this.Name = "PlayOffControl";
            this.Size = new System.Drawing.Size(897, 538);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl groupControl;
        private EditMatchControl editMatchControl;

    }
}

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
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlCurrentStepContainer = new System.Windows.Forms.Panel();
            this.lblHello = new System.Windows.Forms.Label();
            this.pnlCurrentStepContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(829, 534);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(191, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCurrentStepContainer
            // 
            this.pnlCurrentStepContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCurrentStepContainer.Controls.Add(this.lblHello);
            this.pnlCurrentStepContainer.Location = new System.Drawing.Point(13, 13);
            this.pnlCurrentStepContainer.Name = "pnlCurrentStepContainer";
            this.pnlCurrentStepContainer.Size = new System.Drawing.Size(1007, 515);
            this.pnlCurrentStepContainer.TabIndex = 1;
            // 
            // lblHello
            // 
            this.lblHello.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblHello.AutoSize = true;
            this.lblHello.Location = new System.Drawing.Point(405, 251);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(196, 13);
            this.lblHello.TabIndex = 0;
            this.lblHello.Text = "Welcome to Tournament Planner v0.0.1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 569);
            this.Controls.Add(this.pnlCurrentStepContainer);
            this.Controls.Add(this.btnNext);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Tournament Planner";
            this.pnlCurrentStepContainer.ResumeLayout(false);
            this.pnlCurrentStepContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlCurrentStepContainer;
        private System.Windows.Forms.Label lblHello;
    }
}


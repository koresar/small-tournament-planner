namespace Tournament_Planner.UI
{
    partial class EditMatchControl
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGame3 = new System.Windows.Forms.MaskedTextBox();
            this.txtGame1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblPlayerVsPlayer = new System.Windows.Forms.Label();
            this.txtGame2 = new System.Windows.Forms.MaskedTextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.pnlGames = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlResult.SuspendLayout();
            this.pnlGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(367, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start match";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
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
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGroup.Location = new System.Drawing.Point(5, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(357, 36);
            this.lblGroup.TabIndex = 4;
            this.lblGroup.Text = "Group X";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerVsPlayer
            // 
            this.lblPlayerVsPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerVsPlayer.Location = new System.Drawing.Point(4, 36);
            this.lblPlayerVsPlayer.Name = "lblPlayerVsPlayer";
            this.lblPlayerVsPlayer.Size = new System.Drawing.Size(358, 23);
            this.lblPlayerVsPlayer.TabIndex = 3;
            this.lblPlayerVsPlayer.Text = "Player vs Player";
            this.lblPlayerVsPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGame2
            // 
            this.txtGame2.Location = new System.Drawing.Point(53, 20);
            this.txtGame2.Mask = "00:00";
            this.txtGame2.Name = "txtGame2";
            this.txtGame2.Size = new System.Drawing.Size(43, 20);
            this.txtGame2.TabIndex = 1;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(3, 109);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(359, 21);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Finish match";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.pnlResult.Location = new System.Drawing.Point(3, 32);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(367, 135);
            this.pnlResult.TabIndex = 7;
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
            this.pnlGames.Location = new System.Drawing.Point(116, 62);
            this.pnlGames.MaximumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.MinimumSize = new System.Drawing.Size(142, 41);
            this.pnlGames.Name = "pnlGames";
            this.pnlGames.Size = new System.Drawing.Size(142, 41);
            this.pnlGames.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditMatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlResult);
            this.Name = "EditMatchControl";
            this.Size = new System.Drawing.Size(373, 170);
            this.pnlResult.ResumeLayout(false);
            this.pnlGames.ResumeLayout(false);
            this.pnlGames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtGame3;
        private System.Windows.Forms.MaskedTextBox txtGame1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblPlayerVsPlayer;
        private System.Windows.Forms.MaskedTextBox txtGame2;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Panel pnlGames;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

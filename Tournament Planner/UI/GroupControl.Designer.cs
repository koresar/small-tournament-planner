namespace Tournament_Planner.UI
{
    partial class GroupControl
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
            this.tblData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            this.SuspendLayout();
            // 
            // tblData
            // 
            this.tblData.AllowUserToAddRows = false;
            this.tblData.AllowUserToDeleteRows = false;
            this.tblData.AllowUserToResizeColumns = false;
            this.tblData.AllowUserToResizeRows = false;
            this.tblData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblData.ColumnHeadersVisible = false;
            this.tblData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblData.Location = new System.Drawing.Point(0, 0);
            this.tblData.MultiSelect = false;
            this.tblData.Name = "tblData";
            this.tblData.ReadOnly = true;
            this.tblData.RowHeadersVisible = false;
            this.tblData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tblData.Size = new System.Drawing.Size(303, 154);
            this.tblData.TabIndex = 0;
            // 
            // GroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblData);
            this.Name = "GroupControl";
            this.Size = new System.Drawing.Size(303, 154);
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblData;
    }
}

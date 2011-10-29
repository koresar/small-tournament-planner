using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public partial class PlayOffControl : UserControl
    {
        public PlayOffControl()
        {
            this.InitializeComponent();
        }

        public event Action LoadClicked;

        public event Action SaveClicked;

        public EditMatchControl GetMatchControl()
        {
            return this.editMatchControl;
        }

        public GroupControl GetGroupControl()
        {
            return this.groupControl;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (this.LoadClicked != null)
            {
                this.LoadClicked();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SaveClicked != null)
            {
                this.SaveClicked();
            }
        }
    }
}

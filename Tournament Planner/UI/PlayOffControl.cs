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

        public EditMatchControl GetMatchControl()
        {
            return this.editMatchControl;
        }

        public GroupControl GetGroupControl()
        {
            return this.groupControl;
        }
    }
}

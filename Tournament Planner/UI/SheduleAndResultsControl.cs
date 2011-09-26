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
    public partial class SheduleAndResultsControl : UserControl
    {
        public SheduleAndResultsControl()
        {
            this.InitializeComponent();
        }

        public void SetDataSources(BL.TournamentData tournamentData)
        {
            var bs = new BindingSource();
            bs.DataSource = tournamentData.Schedule;
            this.dataGridView1.DataSource = bs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public partial class ScheduleAndResultsControl : UserControl
    {
        public ScheduleAndResultsControl()
        {
            this.InitializeComponent();
        }

        public event Action<Match> MatchSelected;

        public void SetDataSources(BL.TournamentData tournamentData)
        {
            var bs = new BindingSource();
            bs.DataSource = tournamentData.Schedule;
            this.tblMatches.DataSource = bs;
            this.tblMatches.AutoSizeAllCells();
        }

        public void AllowStart(bool p)
        {

        }

        public void AllowResultEntering(bool p)
        {

        }

        private void tblMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (this.MatchSelected != null)
            {
                var match = this.tblMatches.SelectedRows.Count == 1 ? (Match)this.tblMatches.SelectedRows[0].DataBoundItem : null;
                if (match != null)
                {
                    this.MatchSelected(match);
                }
            }
        }
    }
}

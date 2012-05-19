using System;
using System.ComponentModel;
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
            this.tblMatches.SelectionChanged += this.tblMatches_SelectionChanged;
            new ColorizeTableByColumnValue(this.tblMatches, "Progress");
        }

        public event Action<Match> MatchSelected;

        public event Action LoadClicked;

        public event Action SaveClicked;

        public GroupControl GetGroupControl()
        {
            return this.groupControl;
        }

        public EditMatchControl GetMatchControl()
        {
            return this.editMatchControl;
        }

        public void SetDataSources(BL.Tournament tournamentData)
        {
            if (tournamentData == null)
            {
                this.tblMatches.DataSource = null;
                return;
            }

            var previousSelectedMatch = this.tblMatches.SelectedRows.Count == 1 ? (Match)this.tblMatches.SelectedRows[0].DataBoundItem : null;

            var bs = new BindingSource();
            bs.DataSource = tournamentData.Matches;
            this.tblMatches.DataSource = bs;
            this.tblMatches.AutoSizeAllCells();

            if (previousSelectedMatch != null)
            {
                this.SelectMatch(previousSelectedMatch);
            }
        }

        public void SelectMatch(Match match)
        {
            var currentSelection = this.tblMatches.SelectedRows.Count == 1 ? (Match)this.tblMatches.SelectedRows[0].DataBoundItem : null;
            if (currentSelection == match)
            {
                return;
            }

            this.tblMatches.SelectionChanged -= new System.EventHandler(this.tblMatches_SelectionChanged);
            this.tblMatches.ClearSelection();
            this.tblMatches.SelectionChanged += new System.EventHandler(this.tblMatches_SelectionChanged);

            var row = this.tblMatches.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == match);
            if (row != null)
            {
                row.Selected = true;
            }
        }

        private void tblMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (this.MatchSelected != null)
            {
                var match = this.tblMatches.SelectedRows.Count == 1 ? (Match)this.tblMatches.SelectedRows[0].DataBoundItem : null;
                this.MatchSelected(match);
            }
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

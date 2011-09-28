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
        private List<MaskedTextBox> gameResultsControls;

        public ScheduleAndResultsControl()
        {
            this.InitializeComponent();
            this.gameResultsControls = new List<MaskedTextBox>() { this.txtGame1, this.txtGame2, this.txtGame3 };
        }

        public event Action<Match> MatchSelected;

        public event Action StartMatch;

        public event Action FinishMatch;

        public void SetDataSources(BL.TournamentData tournamentData)
        {
            var previousSelectedMatch = this.tblMatches.SelectedRows.Count == 1 ? (Match)this.tblMatches.SelectedRows[0].DataBoundItem : null;

            var bs = new BindingSource();
            bs.DataSource = tournamentData.Schedule;
            this.tblMatches.DataSource = bs;
            this.tblMatches.AutoSizeAllCells();

            if (previousSelectedMatch != null)
            {
                var row = this.tblMatches.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == previousSelectedMatch);
                if (row != null)
                {
                    this.tblMatches.ClearSelection();
                    row.Selected = true;
                }
            }
        }

        public void AllowStart(bool allow)
        {
            this.btnStart.Visible = allow;
        }

        public void AllowResultEntering(bool allow)
        {
            this.pnlResult.Visible = allow;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.StartMatch != null)
            {
                this.StartMatch();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (this.FinishMatch != null)
            {
                this.FinishMatch();
            }
        }

        public IEnumerable<Game> GetGameData()
        {
            return this.gameResultsControls.Select(c => this.GetGameScores(c));
        }

        private Game GetGameScores(MaskedTextBox maskedTextBox)
        {
            var scoreText = maskedTextBox.Text;
            var semicolonPosition = scoreText.IndexOf(':');
            int score1;
            int score2;
            if (int.TryParse(scoreText.Substring(0, semicolonPosition), out score1) &&
                int.TryParse(scoreText.Substring(semicolonPosition + 1, scoreText.Length - semicolonPosition - 1), out score2))
            {
                return new Game(score1, score2);
            }

            return null;
        }

        public void SetGameDataError(string errorMessage)
        {
            this.errorProvider.SetError(this.pnlGames, errorMessage);
        }

        public void PopulateMatchData(Match match)
        {
            this.errorProvider.Clear();

            this.gameResultsControls.ForEach(c => c.Clear());
            if (match.Games != null)
            {
                int counter = 0;
                foreach (var g in match.Games)
                {
                    this.gameResultsControls[counter].Text = g.ToString();
                    counter++;
                }
            }

            this.lblGroup.Text = string.Empty;
            if (match.Group != null)
            {
                this.lblGroup.Text = string.Format("Group {0}", match.Group.Name);
            }

            this.lblPlayerVsPlayer.Text = string.Format("{0} vs {1}", match.Player1.FullName, match.Player2.FullName);
        }
    }
}

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

        public event Action StartMatch;

        public event Action FinishMatch;

        public void SetDataSources(BL.TournamentData tournamentData)
        {
            var bs = new BindingSource();
            bs.DataSource = tournamentData.Schedule;
            this.tblMatches.DataSource = bs;
            this.tblMatches.AutoSizeAllCells();
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
            yield return this.GetGameScores(this.txtGame1);
            yield return this.GetGameScores(this.txtGame2);
            yield return this.GetGameScores(this.txtGame3);
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
    }
}

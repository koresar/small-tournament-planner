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
    public partial class EditMatchControl : UserControl
    {
        private List<MaskedTextBox> gameResultsControls;

        public EditMatchControl()
        {
            this.InitializeComponent();
            this.gameResultsControls = new List<MaskedTextBox>() { this.txtGame1, this.txtGame2, this.txtGame3 };
        }

        public event Action StartMatch;

        public event Action FinishMatch;

        public void AllowStart(bool allow)
        {
            this.btnStart.Visible = allow;
        }

        public void AllowResultEntering(bool allow)
        {
            this.pnlResult.Visible = allow;
        }

        public IEnumerable<Game> GetGameData()
        {
            return this.gameResultsControls.Select(c => this.GetGameScores(c)).Where(g => g != null);
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
            this.lblGroup.Text = string.Empty;
            this.lblPlayerVsPlayer.Text = string.Empty;

            if (match != null)
            {
                if (match.Games != null)
                {
                    int counter = 0;
                    foreach (var g in match.Games)
                    {
                        this.gameResultsControls[counter].Text = g.ToString();
                        counter++;
                    }
                }

                if (match.Group != null)
                {
                    this.lblGroup.Text = string.Format("Group {0}", match.Group.Name);
                }

                this.lblPlayerVsPlayer.Text = string.Format("{0} vs {1}", match.Player1.FullName, match.Player2.FullName);
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
    }
}

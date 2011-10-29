using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class EditMatchController
    {
        private EditMatchControl control;
        private Match selectedMatch;
        private Tournament tournament;

        public EditMatchController(Tournament tournament, EditMatchControl editMatchControl)
        {
            this.tournament = tournament;
            this.control = editMatchControl;
            this.control.StartMatch += this.control_StartMatch;
            this.control.FinishMatch += this.control_FinishMatch;
        }

        public event Action StartMatch;

        public event Action FinishMatch;

        public void AllowStart(bool allow)
        {
            this.control.AllowStart(allow);
        }

        public void AllowResultEntering(bool allow)
        {
            this.control.AllowResultEntering(allow);
        }

        public void PopulateMatchData(Match match)
        {
            this.selectedMatch = match;
            this.control.PopulateMatchData(match);
        }

        private void control_FinishMatch()
        {
            if (!this.ValidateGames())
            {
                return;
            }

            this.selectedMatch.Games.Clear();
            this.selectedMatch.Games.AddRange(this.control.GetGameData());
            this.tournament.Matches.SetMatchState(this.selectedMatch, MatchProgress.Finished);

            if (this.FinishMatch != null)
            {
                this.FinishMatch();
            }
        }

        private bool ValidateGames()
        {
            var games = this.control.GetGameData().Where(g => g != null).ToList();
            if (games.Count < 2)
            {
                this.control.SetGameDataError("Please, enter at least two first game results.");
                return false;
            }

            if ((games[0].Score1 == games[0].Score2) || (games[1].Score1 == games[1].Score2) ||
                (games.Count == 3 && games[2].Score1 == games[2].Score2))
            {
                this.control.SetGameDataError("It is impossible to have win-win in a game.");
                return false;
            }

            int gamesWon1 = games.Count(g => g.Score1 > g.Score2);
            int gamesWon2 = games.Count(g => g.Score1 < g.Score2);
            if (gamesWon1 == gamesWon2)
            {
                this.control.SetGameDataError("It is impossible to have win-win in a match. Enter third game result.");
                return false;
            }

            return true;
        }

        private void control_StartMatch()
        {
            this.tournament.Matches.SetMatchState(this.selectedMatch, MatchProgress.InProgress);

            if (this.StartMatch != null)
            {
                this.StartMatch();
            }
        }

        public void SelectMatch(Match match)
        {
            if (match == null)
            {
                this.AllowStart(false);
                this.AllowResultEntering(false);
                this.PopulateMatchData(null);
            }
            else
            {
                this.AllowStart(match.Progress == MatchProgress.PossibleToStart);
                this.AllowResultEntering(match.Progress == MatchProgress.InProgress || match.Progress == MatchProgress.Finished);
                this.PopulateMatchData(match);
            }
        }
    }
}

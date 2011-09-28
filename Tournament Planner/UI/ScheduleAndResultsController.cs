using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class ScheduleAndResultsController : StepController
    {
        private ScheduleAndResultsControl editingControl;
        private Match selectedMatch;

        public ScheduleAndResultsController(TournamentData tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new ScheduleAndResultsControl();
            this.Control = this.editingControl;
            this.editingControl.MatchSelected += this.editingControl_MatchSelected;
            this.editingControl.StartMatch += this.editingControl_StartMatch;
            this.editingControl.FinishMatch += this.editingControl_FinishMatch;
        }

        private void editingControl_StartMatch()
        {
            this.TournamentData.Schedule.SetMatchState(this.selectedMatch, MatchProgress.InProgress);
            this.editingControl.SetDataSources(this.TournamentData);
            this.RefreshCurrentMatchData();
        }

        private void editingControl_FinishMatch()
        {
            var games = this.editingControl.GetGameData().Where(g => g != null).ToList();
            if (games.Count < 2)
            {
                this.editingControl.SetGameDataError("Please, enter at least two first game results.");
                return;
            }

            if ((games[0].Score1 == games[0].Score2) || (games[1].Score1 == games[1].Score2) ||
                (games.Count == 3 && games[2].Score1 == games[2].Score2))
            {
                this.editingControl.SetGameDataError("It is impossible to have win-win in a game.");
                return;
            }

            int gamesWon1 = games.Count(g => g.Score1 > g.Score2);
            int gamesWon2 = games.Count(g => g.Score1 < g.Score2);
            if (gamesWon1 == gamesWon2)
            {
                this.editingControl.SetGameDataError("It is impossible to have win-win in a match. Enter third game result.");
                return;
            }

            this.selectedMatch.Games.Clear();
            this.selectedMatch.Games.AddRange(games);
            this.TournamentData.Schedule.SetMatchState(this.selectedMatch, MatchProgress.Finished);
            this.editingControl.SetDataSources(this.TournamentData);
            this.RefreshCurrentMatchData();
        }

        private void editingControl_MatchSelected(Match match)
        {
            this.selectedMatch = match;
            this.RefreshCurrentMatchData();
        }

        private void RefreshCurrentMatchData()
        {
            this.editingControl.AllowStart(this.selectedMatch.Progress == MatchProgress.PossibleToStart);
            this.editingControl.AllowResultEntering(this.selectedMatch.Progress == MatchProgress.InProgress || this.selectedMatch.Progress == MatchProgress.Finished);
            this.editingControl.PopulateMatchData(this.selectedMatch);
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildSchedule();

            this.editingControl.SetDataSources(this.TournamentData);
        }
    }
}

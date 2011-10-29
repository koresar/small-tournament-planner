using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;
using System.Windows.Forms;
using System.IO;

namespace Tournament_Planner.UI
{
    public class ScheduleAndResultsController : StepController
    {
        private ScheduleAndResultsControl editingControl;
        private Match selectedMatch;
        private GroupController groupController;

        public ScheduleAndResultsController(Tournament tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new ScheduleAndResultsControl();
            this.Control = this.editingControl;

            this.editingControl.MatchSelected += this.MatchInListSelected;
            this.editingControl.StartMatch += this.editingControl_StartMatch;
            this.editingControl.FinishMatch += this.editingControl_FinishMatch;
            this.editingControl.SaveClicked += this.editingControl_SaveClicked;
            this.editingControl.LoadClicked += this.editingControl_LoadClicked;

            this.groupController = new GroupController(this.editingControl.GetGroupControl());
            this.groupController.MatchSelected += this.MatchInGroupGridSelected;
        }

        private bool clickFromGroup = false;

        public override bool IsAllowProceed()
        {
            return false;
        }

        private void MatchInGroupGridSelected(Match match)
        {
            if (match != null)
            {
                if (this.selectedMatch == match)
                {
                    return;
                }

                clickFromGroup = true;
                this.RefreshCurrentMatchData();
                this.editingControl.SelectMatch(match);
                clickFromGroup = false;
            }
        }

        private void editingControl_LoadClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Schedule snapshot file (*.stpss)|*.stpss";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new TournametDataSaveLoad(this.TournamentData).LoadPlayersList(dialog.FileName);
            }
        }

        private void editingControl_SaveClicked()
        {
            this.SaveScheuleSnapshot();
        }

        private void SaveScheuleSnapshot()
        {
            new TournametDataSaveLoad(this.TournamentData).SavePlayersList(this.GenerateSpanshotFileName());
        }

        private string GenerateSpanshotFileName()
        {
            var now = DateTime.Now;
            var fileName = string.Format("{0} {1} {2}.stpss", this.TournamentData.Name, now.ToString("yyyy-MM-dd"), now.ToString("HH-mm-ss"));
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(dir, fileName);
        }

        private void editingControl_StartMatch()
        {
            this.TournamentData.Matches.SetMatchState(this.selectedMatch, MatchProgress.InProgress);
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
            this.TournamentData.Matches.SetMatchState(this.selectedMatch, MatchProgress.Finished);
            this.editingControl.SetDataSources(this.TournamentData);
            this.RefreshCurrentMatchData();
        }

        private void MatchInListSelected(Match match)
        {
            this.selectedMatch = match;
            if (!clickFromGroup)
            {
                this.groupController.ForceSelectMatch(match);
            }

            this.RefreshCurrentMatchData();
        }

        private void RefreshCurrentMatchData()
        {
            if (this.selectedMatch == null)
            {
                this.editingControl.AllowStart(false);
                this.editingControl.AllowResultEntering(false);
                this.editingControl.PopulateMatchData(null);
                this.groupController.SetDataSource(null);
            }
            else
            {
                this.editingControl.AllowStart(this.selectedMatch.Progress == MatchProgress.PossibleToStart);
                this.editingControl.AllowResultEntering(this.selectedMatch.Progress == MatchProgress.InProgress || this.selectedMatch.Progress == MatchProgress.Finished);
                this.editingControl.PopulateMatchData(this.selectedMatch);
                this.groupController.SetDataSource(this.selectedMatch.Group);
                this.groupController.TrySelectMatch(this.selectedMatch);
            }
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildSchedule();

            this.editingControl.SetDataSources(this.TournamentData);
        }
    }
}

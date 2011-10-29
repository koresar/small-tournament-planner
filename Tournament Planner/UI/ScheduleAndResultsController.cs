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
        private EditMatchController editMatchController;

        public ScheduleAndResultsController(Tournament tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new ScheduleAndResultsControl();
            this.Control = this.editingControl;

            this.editingControl.MatchSelected += this.MatchInListSelected;
            this.editingControl.SaveClicked += this.editingControl_SaveClicked;
            this.editingControl.LoadClicked += this.editingControl_LoadClicked;

            this.groupController = new GroupController(this.editingControl.GetGroupControl());
            this.groupController.MatchSelected += this.MatchInGroupGridSelected;

            this.editMatchController = new EditMatchController(this.TournamentData, this.editingControl.GetMatchControl());
            this.editMatchController.StartMatch += this.editingControl_StartMatch;
            this.editMatchController.FinishMatch += this.editingControl_FinishMatch;
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
                this.UnbindAll();
                new TournametDataSaveLoad(this.TournamentData).LoadPlayersList(dialog.FileName);
                this.editingControl.SetDataSources(this.TournamentData);
                this.RefreshCurrentMatchData();
            }
        }

        private void UnbindAll()
        {
            this.groupController.SetDataSource(null);
            this.editingControl.SetDataSources(null);
        }

        private void editingControl_SaveClicked()
        {
            this.SaveScheduleSnapshot();
        }

        private void SaveScheduleSnapshot()
        {
            new TournametDataSaveLoad(this.TournamentData).SavePlayersList(this.GenerateSnapshotFileName());
        }

        private string GenerateSnapshotFileName()
        {
            var now = DateTime.Now;
            var fileName = string.Format("{0} {1} {2}.stpss", this.TournamentData.Name, now.ToString("yyyy-MM-dd"), now.ToString("HH-mm-ss"));
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(dir, fileName);
        }

        private void editingControl_StartMatch()
        {
            this.editingControl.SetDataSources(this.TournamentData);
            this.RefreshCurrentMatchData();
        }

        private void editingControl_FinishMatch()
        {
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
            this.editMatchController.SelectMatch(this.selectedMatch);

            if (this.selectedMatch == null)
            {
                this.groupController.SetDataSource(null);
            }
            else
            {
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

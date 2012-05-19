using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;
using System.IO;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public class PlayOffController : StepController
    {
        private PlayOffControl editingControl;
        private GroupController groupController;
        private EditMatchController editMatchController;

        public PlayOffController(Tournament tournamentData)
            : base(tournamentData)
        {
            this.ProceedError = "Finish all matches before proceed to play off.";

            this.editingControl = new PlayOffControl();
            this.Control = this.editingControl;
            this.editingControl.SaveClicked += this.editingControl_SaveClicked;
            this.editingControl.LoadClicked += this.editingControl_LoadClicked;
            this.editingControl.ManuallyEnterPlayersClicked += this.EditingControlOnManuallyEnterPlayersClicked;

            this.groupController = new GroupController(this.editingControl.GetGroupControl());
            this.groupController.MatchSelected += this.MatchInGroupGridSelected;

            this.editMatchController = new EditMatchController(this.TournamentData, this.editingControl.GetMatchControl());
            this.editMatchController.StartMatch += this.editingControl_StartMatch;
            this.editMatchController.FinishMatch += this.editingControl_FinishMatch;

            if (this.TournamentData.PlayOffGroup == null)
            {
                this.editMatchController.AllowResultEntering(false);
                this.editMatchController.AllowStart(false);
            }
        }

        public override bool IsAllowProceed()
        {
            return
                this.TournamentData.PlayOffGroup == null ||
                this.TournamentData.PlayOffMatches.All(m => m.Progress == MatchProgress.Finished) ||
                this.TournamentData.IsFinalPlayersAcceptable();
        }

        public void MatchInGroupGridSelected(Match match)
        {
            this.editMatchController.SelectMatch(match);
        }

        public void editingControl_StartMatch(Match match)
        {
            this.RefreshGroup();
            this.groupController.TrySelectMatch(match);
        }

        public void editingControl_FinishMatch(Match match)
        {
            this.RefreshGroup();
            this.groupController.TrySelectMatch(match);
        }

        public void RefreshGroup()
        {
            this.groupController.SetDataSource(this.TournamentData.PlayOffGroup);
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildPlayOffMatches();

            this.RefreshGroup();
        }

        private void editingControl_LoadClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Schedule snapshot file (*.stpss)|*.stpss";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.groupController.SetDataSource(null);
                new TournametDataSaveLoad(this.TournamentData).LoadPlayersList(dialog.FileName);
                this.RefreshGroup();
            }
        }

        private void editingControl_SaveClicked()
        {
            this.SaveScheduleSnapshot();
        }

        private void EditingControlOnManuallyEnterPlayersClicked()
        {
            if (this.TournamentData.NeedThatMorePlayersForFinal > 0)
            {
                var form = new SelectPlayersWindow(this.TournamentData.GetPossiblePlayoffPlayers(), this.TournamentData.NeedThatMorePlayersForFinal);
                if (form.ShowDialog() == DialogResult.OK && form.SelectedPlayers.Count() == this.TournamentData.NeedThatMorePlayersForFinal)
                {
                    this.editingControl.GetManualPlayersControl().DataSource = form.SelectedPlayers.ToList();
                    this.TournamentData.FinalPlayers.AddRange(form.SelectedPlayers);
                    this.ShowManualPlayers();
                    this.HideGaming();
                }
            }
        }

        private void ShowManualPlayers()
        {
            this.editingControl.GetManualPlayersControl().Visible = true;
        }

        private void HideGaming()
        {
            this.editingControl.GetGroupControl().Visible = this.editingControl.GetMatchControl().Visible = false;
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
    }
}

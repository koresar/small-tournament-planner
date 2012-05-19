using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public class FinalController : StepController
    {
        private FinalMatchesControl editingControl;

        public FinalController(Tournament tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new FinalMatchesControl();
            this.editingControl.DeletePlayerClicked += this.editingControl_DeletePlayerClicked;
            this.editingControl.AddPlayerClicked += this.editingControl_AddPlayerClicked;
            this.editingControl.SaveClicked += this.editingControl_SaveClicked;
            this.editingControl.LoadClicked += this.editingControl_LoadClicked;
            this.Control = this.editingControl;
        }

        private void editingControl_LoadClicked()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Schedule snapshot file (*.stpss)|*.stpss";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.editingControl.GetPlayersTable().DataSource = null;
                new TournametDataSaveLoad(this.TournamentData).LoadPlayersList(dialog.FileName);
                this.RefresPlayersTable();
            }
        }

        private void RefresPlayersTable()
        {
            var bsPlayers = new BindingSource();
            bsPlayers.DataSource = this.TournamentData.FinalPlayers;
            this.editingControl.GetPlayersTable().DataSource = bsPlayers;
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

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildFinalRounds();
            this.RefresPlayersTable();
        }

        private void editingControl_DeletePlayerClicked(Player player)
        {
            this.TournamentData.FinalPlayers.Remove(player);
        }

        private void editingControl_AddPlayerClicked()
        {
            var form = new SelectPlayersWindow(this.TournamentData.Players.Except(this.TournamentData.FinalPlayers));
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.TournamentData.FinalPlayers.AddRange(form.SelectedPlayers);
            }
        }
    }
}

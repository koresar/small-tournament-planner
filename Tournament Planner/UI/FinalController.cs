using System;
using System.Collections.Generic;
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
            this.Control = this.editingControl;
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildFinalRounds();
            var bsPlayers = new BindingSource();
            bsPlayers.DataSource = this.TournamentData.FinalPlayers;
            this.editingControl.GetPlayersTable().DataSource = bsPlayers;
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

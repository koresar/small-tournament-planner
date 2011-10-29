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
            this.Control = this.editingControl;
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildFinalRounds();
            var bsPlayers = new BindingSource();
            bsPlayers.DataSource = this.TournamentData.FinalPlayers;
            this.editingControl.GetPlayersTable().DataSource = bsPlayers;
        }
    }
}

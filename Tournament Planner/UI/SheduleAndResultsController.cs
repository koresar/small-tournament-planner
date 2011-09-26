using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class SheduleAndResultsController : StepController
    {
        private SheduleAndResultsControl editingControl;

        public SheduleAndResultsController(TournamentData tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new SheduleAndResultsControl();
            this.Control = this.editingControl;
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildSchedule();

            this.editingControl.SetDataSources(this.TournamentData);
        }
    }
}

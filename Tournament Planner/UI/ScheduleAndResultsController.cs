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

        public ScheduleAndResultsController(TournamentData tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new ScheduleAndResultsControl();
            this.Control = this.editingControl;
            this.editingControl.MatchSelected += this.editingControl_MatchSelected;
        }

        private void editingControl_MatchSelected(Match match)
        {
            this.editingControl.AllowStart(match.Progress == MatchProgress.PossibleToStart);
            this.editingControl.AllowResultEntering(match.Progress == MatchProgress.InProgress);
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildSchedule();

            this.editingControl.SetDataSources(this.TournamentData);
        }
    }
}

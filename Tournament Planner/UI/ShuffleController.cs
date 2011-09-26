using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class ShuffleController : StepController
    {
        public ShuffleController(TournamentData tournamentData) : base(tournamentData)
        {
            var control = new ShuffleControl();
            this.Control = control;

            control.SetDataSources(this.TournamentData);
        }
    }
}

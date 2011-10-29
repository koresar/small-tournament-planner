using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class FinalController : StepController
    {
        private FinalMatchesControl editControl;

        public FinalController(Tournament tournamentData)
            : base(tournamentData)
        {

        }
    }
}

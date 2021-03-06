﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class StepController
    {
        public StepController(Tournament tournamentData)
        {
            this.TournamentData = tournamentData;
        }

        public Control Control { get; protected set; }

        public virtual bool IsAllowProceed()
        {
            return true;
        }

        protected Tournament TournamentData { get; private set; }

        public string ProceedError { get; protected set; }

        public virtual void OnEnteringStep()
        {
        }
    }
}

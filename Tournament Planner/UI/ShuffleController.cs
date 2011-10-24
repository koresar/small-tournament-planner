using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class ShuffleController : StepController
    {
        private ShuffleControl editingControl;

        public ShuffleController(Tournament tournamentData) : base(tournamentData)
        {
            this.editingControl = new ShuffleControl();
            this.Control = this.editingControl;

            this.editingControl.DoShuffleClicked += this.editingControl_DoShuffleClicked;
        }

        private void editingControl_DoShuffleClicked()
        {
            this.Shuffle();
        }

        public void Shuffle()
        {
            this.TournamentData.Groups.Clear();
            foreach (var group in this.TournamentData.SplitPeopleOnRandomGroups())
            {
                this.TournamentData.Groups.Add(group);
            }

            this.editingControl.DrawGroups(this.TournamentData.Groups);
        }

        public override void OnEnteringStep()
        {
            this.editingControl.SetDataSources(this.TournamentData);
            base.OnEnteringStep();
            this.Shuffle();
        }
    }
}

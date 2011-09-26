using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class ShuffleController : StepController
    {
        private List<Group> groups;
        private ShuffleControl editingControl;

        public ShuffleController(TournamentData tournamentData) : base(tournamentData)
        {
            this.editingControl = new ShuffleControl();
            this.Control = this.editingControl;

            this.editingControl.SetDataSources(this.TournamentData);
            this.editingControl.DoShuffleClicked += this.editingControl_DoShuffleClicked;
        }

        private void editingControl_DoShuffleClicked()
        {
            this.groups = this.TournamentData.SplitPeopleOnRandomGroups().ToList();
            this.editingControl.DrawGroups(this.groups);
        }
    }
}

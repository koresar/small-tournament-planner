using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL;

namespace Tournament_Planner.UI
{
    public class PlayOffController : StepController
    {
        private PlayOffControl editingControl;
        private GroupController groupController;
        private EditMatchController editMatchController;

        public PlayOffController(Tournament tournamentData)
            : base(tournamentData)
        {
            this.editingControl = new PlayOffControl();
            this.Control = this.editingControl;

            this.groupController = new GroupController(this.editingControl.GetGroupControl());
            this.groupController.MatchSelected += this.MatchInGroupGridSelected;

            this.editMatchController = new EditMatchController(this.TournamentData, this.editingControl.GetMatchControl());
            this.editMatchController.StartMatch += this.editingControl_StartMatch;
            this.editMatchController.FinishMatch += this.editingControl_FinishMatch;
        }

        public void MatchInGroupGridSelected(Match match)
        {
            this.editMatchController.SelectMatch(match);
        }

        public void editingControl_StartMatch(Match match)
        {
            this.RefreshGroup();
            this.groupController.TrySelectMatch(match);
        }

        public void editingControl_FinishMatch(Match match)
        {
            this.RefreshGroup();
            this.groupController.TrySelectMatch(match);
        }

        public void RefreshGroup()
        {
            this.groupController.SetDataSource(this.TournamentData.PlayOffGroup);
        }

        public override void OnEnteringStep()
        {
            this.TournamentData.BuildPlayOffMatches();

            this.RefreshGroup();
        }
    }
}

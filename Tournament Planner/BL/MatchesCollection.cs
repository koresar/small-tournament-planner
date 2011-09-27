using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class MatchesCollection : BindingList<Match>
    {
        public MatchesCollection() : base()
        {
        }

        public MatchesCollection(IList<Match> matches)
            : base(matches)
        {

        }

        public void SetMatchState(Match match, MatchProgress matchProgress)
        {
            match.Progress = matchProgress;

            if (matchProgress == MatchProgress.InProgress)
            {
                // Set some matches as impossible to start due to players became busy.
                foreach (var m in this.Where(x => x.Progress == MatchProgress.PossibleToStart && x != match))
                {
                    if (match.IsAnyPlayerSame(m))
                    {
                        match.Progress = MatchProgress.ImpossbileToStart;
                    }
                }
            }
            else if (matchProgress == MatchProgress.Finished)
            {
                // Set some matches as possible to start due to players ended the game and free to play next match.
                foreach (var m in this.Where(x => x.Progress == MatchProgress.ImpossbileToStart && x != match))
                {
                    if (match.IsAnyPlayerSame(m))
                    {
                        match.Progress = MatchProgress.PossibleToStart;
                    }
                }
            }
        }

        public bool IsPlayerBusy(Player player)
        {
            return this.Any(m => m.Progress == MatchProgress.InProgress && (m.Player1 == player || m.Player2 == player));
        }
    }
}

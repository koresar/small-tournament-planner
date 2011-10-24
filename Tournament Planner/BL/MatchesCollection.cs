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
                // Set some matches as impossible to begin due to players became busy.
                foreach (var m in this.Where(x => x.Progress == MatchProgress.PossibleToStart && x != match))
                {
                    if (match.IsAnyPlayerSame(m))
                    {
                        m.Progress = MatchProgress.ImpossbileToStart;
                    }
                }
            }
            else if (matchProgress == MatchProgress.Finished)
            {
                // Set some matches as possible to begin due to players ended the game and free to play a next match.
                foreach (var m in this.Where(x => x.Progress == MatchProgress.ImpossbileToStart && x != match))
                {
                    if (match.IsAnyPlayerSame(m))
                    {
                        m.Progress = MatchProgress.PossibleToStart;
                    }
                }
            }
        }

        public bool IsPlayerBusy(Player player)
        {
            return this.Any(m => m.Progress == MatchProgress.InProgress && m.IsPlayerPlaysHere(player));
        }

        public IEnumerable<Match> GetPlayerMatches(Player player)
        {
            return this.Where(m => m.IsPlayerPlaysHere(player));
        }
    }
}

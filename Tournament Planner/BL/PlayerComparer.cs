using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tournament_Planner.BL
{
    public class PlayerComparer : IComparer<Player>
    {
        private Group group;

        public PlayerComparer(Group group)
        {
            this.group = group;
        }

        public int Compare(Player p1, Player p2)
        {
            // Who won more matches?
            int p1Score = this.group.GetPlayerScore(p1);
            int p2Score = this.group.GetPlayerScore(p2);
            if (p1Score < p2Score) return 1;
            if (p1Score > p2Score) return -1;

            var playersMatch = this.group.GetMatch(p1, p2);

            // In the match between them, who missed less goals?
            int p1Misses = playersMatch.GetPlayerTotalMisses(p1);
            int p2Misses = playersMatch.GetPlayerTotalMisses(p2);
            if (p1Misses > p2Misses) return 1;
            if (p1Misses < p2Misses) return -1;

            // In the match between them, who scored more goals?
            int p1Goals = playersMatch.GetPlayerTotalGoals(p1);
            int p2Goals = playersMatch.GetPlayerTotalGoals(p2);
            if (p1Goals < p2Goals) return 1;
            if (p1Goals > p2Goals) return -1;

            // In the group in common, who missed less goals?
            int p1GroupMisses = this.group.GetPlayerMatches(p1).Select(m => m.GetPlayerTotalMisses(p1)).Sum();
            int p2GroupMisses = this.group.GetPlayerMatches(p2).Select(m => m.GetPlayerTotalMisses(p2)).Sum();
            if (p1GroupMisses > p2GroupMisses) return 1;
            if (p1GroupMisses < p2GroupMisses) return -1;

            // In the group in common, who scored more goals?
            int p1GroupGoals = this.group.GetPlayerMatches(p1).Select(m => m.GetPlayerTotalGoals(p1)).Sum();
            int p2GroupGoals = this.group.GetPlayerMatches(p2).Select(m => m.GetPlayerTotalGoals(p2)).Sum();
            if (p1GroupGoals < p2GroupGoals) return 1;
            if (p1GroupGoals > p2GroupGoals) return -1;

            throw new NotImplementedException("Can't decide which player is better.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Group : BindingList<Player>
    {
        private MatchesCollection groupMatches;

        public Group() : base()
        {
        }

        public Group(IList<Player> players, string name)
            : base(players)
        {
            this.Name = name;
            foreach (var player in players)
            {
                player.StartGroup = this;
            }
        }

        public string Name { get; private set; }

        public MatchesCollection GetGroupMatches()
        {
            if (this.groupMatches == null)
            {
                this.groupMatches = new MatchesCollection(this.BuildSchedule().ToList());
            }

            return this.groupMatches;
        }

        public IEnumerable<Match> GetPlayerMatches(Player player)
        {
            return this.GetGroupMatches().Where(m => m.Player1 == player || m.Player2 == player);
        }

        private IEnumerable<Match> BuildSchedule()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    var player1 = this[i];
                    var player2 = this[j];
                    if (player1 != player2)
                    {
                        yield return new Match(player1, player2) { Group = this };
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

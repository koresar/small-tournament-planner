using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Group : BindingList<Player>
    {
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

        public IEnumerable<Match> BuildSchedule()
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

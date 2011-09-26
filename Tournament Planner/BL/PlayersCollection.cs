using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Tournament_Planner.BL
{
    public class PlayersCollection : BindingList<Player>
    {
        public PlayersCollection() : base()
        {
        }

        public PlayersCollection(IList<Player> players)
            : base(players)
        {

        }

        public bool IsNumberOfPlayersAcceptable()
        {
            return this.Count % 4 == 0 || this.Count % 3 == 0;
        }

        public int GetSuggestedNumberOfPlayersInGroup()
        {
            if (!this.IsNumberOfPlayersAcceptable())
            {
                throw new InvalidOperationException("Impossible to split onto groups that number of players.");
            }

            return this.Count % 4 == 0 ? 4 : 3;
        }
    }
}

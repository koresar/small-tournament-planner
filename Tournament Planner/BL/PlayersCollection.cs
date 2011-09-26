using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class PlayersCollection : BindingList<Player>
    {
        public PlayersCollection() : base()
        {
        }

        public PlayersCollection(IList<Player> companies) : base(companies)
        {

        }

        public bool IsNumberOfPlayersAcceptable()
        {
            return this.Count % 4 == 0 || this.Count % 3 == 0;
        }
    }
}

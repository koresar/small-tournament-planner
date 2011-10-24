using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class PlayersCollection : BindingList<Player>, IXmlSerializable<List<PlayerData>>
    {
        public PlayersCollection() : base()
        {
        }

        public PlayersCollection(IList<Player> players)
            : base(players)
        {
        }

        public PlayersCollection(List<PlayerData> list)
            : this(list.Select(p => new Player(p)).ToList())
        {
        }

        public IEnumerable<Player> Present
        {
            get { return this.Where(p => p.Present); }
        }

        public bool IsNumberOfPlayersAcceptable()
        {
            var numberOfPresentPlayer = this.Present.Count();
            return numberOfPresentPlayer > 0 && (numberOfPresentPlayer % 4 == 0 || numberOfPresentPlayer % 3 == 0);
        }

        public int GetSuggestedNumberOfPlayersInGroup()
        {
            if (!this.IsNumberOfPlayersAcceptable())
            {
                throw new InvalidOperationException("Impossible to split onto groups that number of players.");
            }

            var numberOfPresentPlayer = this.Present.Count();
            return numberOfPresentPlayer % 4 == 0 ? 4 : 3;
        }

        public List<PlayerData> GetXmlData()
        {
            return this.Select(p => p.GetXmlData()).ToList();
        }
    }
}

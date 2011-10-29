using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class PlayersCollection : Repository<Player, PlayerData>
    {
        public const int MaximumNumberOfPlayersInGroup = 5;
        public const int MinimumNumberOfPlayersInGroup = 3;

        public PlayersCollection()
            : base()
        {
        }

        public IEnumerable<Player> Present
        {
            get { return this.Where(p => p.Present); }
        }

        public bool IsNumberOfPlayersAcceptable()
        {
            return this.SilentlyGetSuggestedNumberOfPlayersInGroup() != 0;
        }

        public int GetSuggestedNumberOfPlayersInGroup()
        {
            if (!this.IsNumberOfPlayersAcceptable())
            {
                throw new InvalidOperationException("Impossible to split onto groups that number of players.");
            }

            return this.SilentlyGetSuggestedNumberOfPlayersInGroup();
        }

        public IEnumerable<int> GetPossibleNumberOfPlayersInGroup()
        {
            var numberOfPresentPlayer = this.Present.Count();
            for (int i = MaximumNumberOfPlayersInGroup; i >= MinimumNumberOfPlayersInGroup; i--)
            {
                if (numberOfPresentPlayer % i == 0)
                {
                    yield return i;
                }
            }
        }

        private int SilentlyGetSuggestedNumberOfPlayersInGroup()
        {
            var numberOfPresentPlayer = this.Present.Count();
            if (numberOfPresentPlayer == 0)
            {
                return 0;
            }

            for (int i = MaximumNumberOfPlayersInGroup; i >= MinimumNumberOfPlayersInGroup; i--)
            {
                if (numberOfPresentPlayer % i == 0)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}

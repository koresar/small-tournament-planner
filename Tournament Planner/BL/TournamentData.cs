using System;
using System.Linq;
using System.Collections.Generic;

namespace Tournament_Planner.BL
{
    public class TournamentData
    {
        public PlayersCollection Players { get; private set; }

        public CompaniesCollection Companies { get; private set; }

        public TournamentData()
        {
            this.Players = new PlayersCollection();
            this.Companies = new CompaniesCollection();
        }

        public IEnumerable<Group> SplitPeopleOnRandomGroups()
        {
            var rnd = new Random();
            var randomOrderedPlayers = this.Players.OrderBy(p => rnd.Next()).ToList();
            int numberOfPlayersInGroup = this.Players.GetSuggestedNumberOfPlayersInGroup();
            for (int i = 0; i < randomOrderedPlayers.Count / numberOfPlayersInGroup; i++)
            {
                yield return new Group(randomOrderedPlayers.GetRange(i * numberOfPlayersInGroup, numberOfPlayersInGroup));
            }
        }
    }
}

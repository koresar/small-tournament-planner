using System;
using System.Linq;
using System.Collections.Generic;

namespace Tournament_Planner.BL
{
    public class TournamentData
    {
        private char[] GroupNames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public PlayersCollection Players { get; private set; }

        public CompaniesCollection Companies { get; private set; }

        public List<Group> Groups { get; private set; }

        public MatchesCollection Schedule { get; private set; }

        public TournamentData()
        {
            this.Players = new PlayersCollection();
            this.Companies = new CompaniesCollection();
            this.Schedule = new MatchesCollection();
            this.Groups = new List<Group>();
        }

        public IEnumerable<Group> SplitPeopleOnRandomGroups()
        {
            var rnd = new Random((int)DateTime.Now.Ticks);
            var randomOrderedPlayers = this.Players.OrderBy(p => rnd.Next()).ToList();
            int numberOfPlayersInGroup = this.Players.GetSuggestedNumberOfPlayersInGroup();
            for (int i = 0; i < randomOrderedPlayers.Count / numberOfPlayersInGroup; i++)
            {
                yield return new Group(randomOrderedPlayers.GetRange(i * numberOfPlayersInGroup, numberOfPlayersInGroup), this.GroupNames[i].ToString());
            }
        }

        public void BuildSchedule()
        {
            if (this.Groups == null || this.Groups.Count == 0)
            {
                throw new InvalidOperationException("No groups found. Nothing to schedule.");
            }

            this.Schedule.Clear();
            foreach (Group group in this.Groups)
            {
                foreach (Match match in group.BuildSchedule())
                {
                    this.Schedule.Add(match);
                }
            }
        }
    }
}

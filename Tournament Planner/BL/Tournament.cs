using System;
using System.Linq;
using System.Collections.Generic;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Tournament : IXmlSerializable<TournamentData>
    {
        private char[] GroupNames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private TournamentData data;
        private PlayersCollection players;
        private CompaniesCollection companies;

        public Tournament()
        {
            this.data = new TournamentData();
            this.Schedule = new MatchesCollection();
            this.Groups = new List<Group>();
        }

        public PlayersCollection Players
        {
            get { return this.players ?? (this.players = new PlayersCollection(this.data.Players)); }
        }

        public CompaniesCollection Companies
        {
            get { return this.companies ?? (this.companies = new CompaniesCollection(this.data.Companies)); }
        }

        public List<Group> Groups { get; private set; }

        public MatchesCollection Schedule { get; private set; }

        public TournamentData GetXmlData()
        {
            this.data.Companies = this.Companies.GetXmlData();
            this.data.Players = this.Players.GetXmlData();
            return this.data;
        }

        public void SetXmlData(TournamentData newData)
        {
            this.Players.Clear();
            foreach (var player in newData.Players)
            {
                this.Players.Add(new Player(player));
            }

            this.Companies.Clear();
            foreach (var company in newData.Companies.Distinct())
            {
                this.Companies.Add(new Company(company));
            }
        }

        public IEnumerable<Group> SplitPeopleOnRandomGroups()
        {
            var rnd = new Random((int)DateTime.Now.Ticks);
            var randomOrderedPlayers = this.Players.Present.OrderBy(p => rnd.Next()).ToList();
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
                foreach (Match match in group.GetGroupMatches())
                {
                    this.Schedule.Add(match);
                }
            }
        }
    }
}

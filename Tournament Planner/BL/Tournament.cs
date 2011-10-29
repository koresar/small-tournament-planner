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
            this.companies = new CompaniesCollection(this.data.Companies);
            this.players = new PlayersCollection(this.data.Players, this.companies);
        }

        public PlayersCollection Players
        {
            get { return this.players; }
        }

        public CompaniesCollection Companies
        {
            get { return this.companies; }
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
            this.Companies.Clear();
            foreach (var company in newData.Companies)
            {
                this.Companies.Add(new Company(company));
            }

            this.Players.Clear();
            foreach (var player in newData.Players)
            {
                this.Players.Add(new Player(player, this.companies));
            }

            this.Schedule = new MatchesCollection();
            this.Groups = new List<Group>();
        }

        public IEnumerable<Group> SplitPeopleOnRandomGroups(int preferredNumberOfPlayersInGroup)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);

            var values = Enum.GetValues(typeof(Skill)).Cast<byte>().ToList();

            var randomSortedBySkill = 
                this.Players. // Take players
                Present. // Select only those who are present today
                OrderBy(p => rnd.Next()). // Shuffle them all in order to not be splitted using the order of entrance screen
                OrderByDescending(p => p.Skill). // Sort by skill. Most skillful goes first.
                ToList();

            int numberOfPlayersInGroup = preferredNumberOfPlayersInGroup;
            int numberOfGroups = randomSortedBySkill.Count / numberOfPlayersInGroup;

            for (int i = 0; i < numberOfGroups; i++)
            {
                yield return new Group(randomSortedBySkill.Where((p, position) => position % numberOfGroups == i).ToList(), this.GroupNames[i].ToString());
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

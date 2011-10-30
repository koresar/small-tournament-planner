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

        public Tournament()
        {
            this.data = new TournamentData();
            this.Companies = new CompaniesCollection();
            this.Players = new PlayersCollection();
            this.Groups = new GroupsCollection();
            this.Matches = new MatchesCollection();
            this.PlayOffMatches = new MatchesCollection();
            this.FinalPlayers = new PlayersCollection();
            this.FinalRounds = new GroupsCollection();
            this.FinalMatches = new MatchesCollection(); 
        }

        public event Action Reloaded;

        public string Name
        {
            get { return this.data.Name; }
            set { this.data.Name = value; }
        }

        public CompaniesCollection Companies { get; private set; }

        public PlayersCollection Players { get; private set; }

        public GroupsCollection Groups { get; private set; }

        public MatchesCollection Matches { get; private set; }

        public Group PlayOffGroup { get; private set; }

        public MatchesCollection PlayOffMatches { get; private set; }

        public int NeedThatMorePlayersForFinal
        {
            get { return this.data.NeedThatMorePlayersForFinal; }
            set { this.data.NeedThatMorePlayersForFinal = value; }
        }

        public PlayersCollection FinalPlayers { get; private set; }

        public GroupsCollection FinalRounds { get; private set; }

        public MatchesCollection FinalMatches { get; private set; }

        public TournamentData GetXmlData()
        {
            this.data.Companies = this.Companies.GetXmlData();
            this.data.Players = this.Players.GetXmlData();
            this.data.Groups = this.Groups.GetXmlData();
            this.data.Matches = this.Matches.GetXmlData();
            this.data.PlayOffGroup = this.PlayOffGroup == null ? null : this.PlayOffGroup.GetXmlData();
            this.data.PlayOffMatches = this.PlayOffMatches.GetXmlData();
            this.data.FinalPlayers = this.FinalPlayers.GetXmlData();
            this.data.FinalRounds = this.FinalRounds.GetXmlData();
            this.data.FinalMatches = this.FinalMatches.GetXmlData();
            return this.data;
        }

        public void SetXmlData(TournamentData newData)
        {
            this.Name = newData.Name;

            this.Companies.Clear();
            this.Players.Clear();
            this.Groups.Clear();
            this.Matches.Clear();
            this.PlayOffGroup = null;
            this.PlayOffMatches.Clear();
            this.FinalPlayers.Clear();
            this.FinalRounds.Clear();
            this.FinalMatches.Clear();
            
            this.Companies.AddRange(newData.Companies.Select(c => new Company(c)));
            this.Players.AddRange(newData.Players.Select(p => new Player(p, this)));
            this.Groups.AddRange(newData.Groups.Select(g => new Group(g, this)));
            this.Matches.AddRange(newData.Matches.Select(m => new Match(m, this)));
            this.PlayOffGroup = newData.PlayOffGroup != null ? new PlayOffGroup(newData.PlayOffGroup, this) : null;
            this.PlayOffMatches.AddRange(newData.PlayOffMatches.Select(m => new Match(m, this) { Group = this.PlayOffGroup }));
            this.FinalPlayers.AddRange(newData.FinalPlayers.Select(p => new Player(p, this)));
            this.FinalRounds.AddRange(newData.FinalRounds.Select(m => new Group(m, this)));
            this.FinalMatches.AddRange(newData.FinalMatches.Select(m => new Match(m, this)));

            this.OnReloaded();
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

            if (this.Matches.Count == 0)
            {
                foreach (Group group in this.Groups)
                {
                    this.Matches.AddRange(group.GenerateNewGroupMatches());
                }
            }
        }

        public void BuildPlayOffMatches()
        {
            this.FinalPlayers.Clear();
            // Find those who 100% won.
            var notInPlayOff =
                this.Groups.
                SelectMany(g => g.GetWinners(2)). // Take two best players from each group.
                ToList();
            this.FinalPlayers.AddRange(notInPlayOff);

            if (this.IsPowerOfTwo(this.FinalPlayers.Count))
            {
                return;
            }

            // Find how many players will be in final.
            int necessaryPlayersInTotal = notInPlayOff.Count + 1;
            while (!this.IsPowerOfTwo(necessaryPlayersInTotal))
                necessaryPlayersInTotal++;

            // This is how many more players we need to have for final.
            this.NeedThatMorePlayersForFinal = necessaryPlayersInTotal - notInPlayOff.Count;

            // Let's find them.
            var playOffPlayers = 
                this.Groups.
                SelectMany(g => g.GetWinners(3)). // Select best three players of group.
                Except(notInPlayOff). // Remove those are 100% finalists.
                ToList();

            this.PlayOffGroup = new PlayOffGroup(playOffPlayers, "Play Off");
            this.PlayOffMatches = this.PlayOffGroup.GenerateNewGroupMatches();
        }

        public void BuildFinalRounds()
        {
            if (this.PlayOffGroup != null && !this.IsPowerOfTwo(this.FinalPlayers.Count))
            {
                this.FinalPlayers.AddRange(this.PlayOffGroup.GetWinners(this.NeedThatMorePlayersForFinal)); // Concat with play off winners.
            }

            //var rnd = new Random((int)DateTime.Now.Ticks);
                //this.FinalPlayers.OrderBy(p => rnd.Next()). // Shuffle them all
                //OrderByDescending(p => p.Skill). // Sort by skill. Most skillful goes first.
                //ToList());
        }

        protected virtual void OnReloaded()
        {
            if (this.Reloaded != null)
            {
                this.Reloaded();
            }
        }

        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
    }
}

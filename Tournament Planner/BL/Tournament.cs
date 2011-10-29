﻿using System;
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
        }

        /// <summary>
        /// TODO: implement entrance of it.
        /// </summary>
        public string Name { get; set; }

        public CompaniesCollection Companies { get; private set; }

        public PlayersCollection Players { get; private set; }

        public GroupsCollection Groups { get; private set; }

        public MatchesCollection Matches { get; private set; }

        public TournamentData GetXmlData()
        {
            this.data.Companies = this.Companies.GetXmlData();
            this.data.Players = this.Players.GetXmlData();
            this.data.Groups = this.Groups.GetXmlData();
            this.data.Matches = this.Matches.GetXmlData();
            return this.data;
        }

        public void SetXmlData(TournamentData newData)
        {
            this.Companies.Clear();
            this.Companies.AddRange(newData.Companies.Select(c => new Company(c)));

            this.Players.Clear();
            this.Players.AddRange(newData.Players.Select(p => new Player(p, this.Companies)));

            this.Groups.Clear();
            this.Groups.AddRange(newData.Groups.Select(g => new Group(g, this.Players)));

            this.Matches.Clear();
            this.Matches.AddRange(newData.Matches.Select(m => new Match(m, this.Players, this.Groups)));
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

            this.Matches.Clear();
            foreach (Group group in this.Groups)
            {
                this.Matches.AddRange(group.GetGroupMatches());
            }
        }
    }
}

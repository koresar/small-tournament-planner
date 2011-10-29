using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Group : IdItem<GroupData>, IIdReferenceItem
    {
        private PlayersCollection players = new PlayersCollection();
        private Tournament tournament;
        private MatchesCollection groupMatches;

        public Group(GroupData data, Tournament tournament)
            : base(data)
        {
            this.players.AddRange(this.Data.Players.Select(playerId => tournament.Players.GetById(playerId)));
            this.tournament = tournament;
        }

        public Group(IList<Player> players, string name) : base()
        {
            this.Name = name;
            this.players.AddRange(players);

            //foreach (var player in players)
            //{
            //    player.StartGroup = this;
            //}
        }

        public BindingList<Player> Players
        {
            get { return this.players; }
        }

        public string Name 
        {
            get { return this.Data.Name; }
            private set { this.Data.Name = value; } 
        }

        public MatchesCollection Matches
        {
            get
            {
                if (this.groupMatches == null)
                {
                    this.groupMatches = new MatchesCollection();
                    this.groupMatches.AddRange(this.tournament.Matches.Where(m => m.Group.Id == this.Id));
                }

                return this.groupMatches;
            }
        }

        public MatchesCollection GenerateNewGroupMatches()
        {
            this.groupMatches = new MatchesCollection();
            for (int i = 0; i < this.players.Count; i++)
            {
                for (int j = i + 1; j < this.players.Count; j++)
                {
                    var player1 = this.players[i];
                    var player2 = this.players[j];
                    if (player1 != player2)
                    {
                        this.groupMatches.Add(new Match(player1, player2) { Group = this });
                    }
                }
            }

            return this.groupMatches;
        }

        public IEnumerable<Match> GetPlayerMatches(Player player)
        {
            return this.Matches.Where(m => m.Player1 == player || m.Player2 == player);
        }

        public Match GetMatch(Player player1, Player player2)
        {
            return this.Matches.Where(m => m.IsPlayerPlaysHere(player1) && m.IsPlayerPlaysHere(player2)).FirstOrDefault();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int GetPlayerScore(Player player)
        {
            return this.Matches.GetPlayerMatches(player).Select(m => m.GetPlayerScore(player)).Sum();
        }

        public IEnumerable<Player> GetWinners(int numberOfWinners)
        {
            return this.Players.OrderBy(p => p, new PlayerComparer(this)).Take(numberOfWinners);
        }

        public override GroupData GetXmlData()
        {
            this.Data.Players = this.players.Select(p => p.Id).ToList();
            return base.GetXmlData();
        }
    }
}

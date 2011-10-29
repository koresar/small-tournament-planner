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
        private MatchesCollection groupMatches;
        private PlayersCollection players = new PlayersCollection();

        public Group(GroupData data, IRepository<Player> playersRepo) : base(data)
        {
            this.players.AddRange(this.Data.Players.Select(playerId => playersRepo.GetById(playerId)));
        }

        public Group(IList<Player> players, string name)  : base()
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

        public MatchesCollection GetGroupMatches()
        {
            if (this.groupMatches == null)
            {
                this.groupMatches = new MatchesCollection();
                this.groupMatches.AddRange(this.BuildSchedule());
            }

            return this.groupMatches;
        }

        public IEnumerable<Match> GetPlayerMatches(Player player)
        {
            return this.GetGroupMatches().Where(m => m.Player1 == player || m.Player2 == player);
        }

        private IEnumerable<Match> BuildSchedule()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                for (int j = i + 1; j < this.players.Count; j++)
                {
                    var player1 = this.players[i];
                    var player2 = this.players[j];
                    if (player1 != player2)
                    {
                        yield return new Match(player1, player2) { Group = this };
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int GetPlayerScore(Player player)
        {
            return this.groupMatches.GetPlayerMatches(player).Select(m => m.GetPlayerScore(player)).Sum();
        }

        public override GroupData GetXmlData()
        {
            this.Data.Players = this.players.Select(p => p.Id).ToList();
            return base.GetXmlData();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Match : IdItem<MatchData>
    {
        public Match(MatchData data, Tournament tournament)
            : base(data)
        {
            this.Player1 = tournament.Players.GetById(data.Player1Id);
            this.Player2 = tournament.Players.GetById(data.Player2Id);
            this.Group = tournament.Groups.GetById(data.GroupId);
            this.Games = data.Games.Select(g => new Game(g)).ToList();
        }

        public Match(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.Games = new List<Game>();
        }

        [DisplayName("Group")]
        public string GroupName
        {
            get
            {
                return this.Group.Name;
            }
        }

        [DisplayName("Progress")]
        public MatchProgress Progress
        {
            get { return this.Data.Progress; }
            set { this.Data.Progress = value; }
        }

        [DisplayName("Player 1")]
        public Player Player1 { get; private set; }

        [DisplayName("Player 2")]
        public Player Player2 { get; private set; }

        [DisplayName("Result")]
        public string StringResult
        {
            get 
            {
                return this.GetStringResult(this.Player1);
            }
        }

        [DisplayName("Group")]
        public Group Group { get; set; }

        [Browsable(false)]
        public List<Game> Games { get; private set; }

        [Browsable(false)]
        public Player Winner
        {
            get 
            {
                int gamesWon1 = this.Games.Count(g => g.Score1 > g.Score2);
                int gamesWon2 = this.Games.Count(g => g.Score1 < g.Score2);

                return gamesWon1 > gamesWon2 ? this.Player1 : this.Player2;
            }
        }

        public string GetStringResult(Player firstScorePlayer)
        {
            if (!this.IsPlayerPlaysHere(firstScorePlayer))
            {
                throw new ArgumentException("This player does not plays in the match!");
            }
            
            if (this.Games.Count == 0)
            {
                return string.Empty;
            }

            bool inverse = this.Player2 == firstScorePlayer;
            bool threeGame = this.Games.Count == 3;

            int gamesWon1 = this.Games.Count(g => g.Score1 > g.Score2);
            int gamesWon2 = this.Games.Count(g => g.Score1 < g.Score2);
            var template = (!inverse ? "{0}:{1}" : "{1}:{0}") + (threeGame ? " ({2} {3} {4})" : " ({2} {3})");
            return string.Format(
                template, 
                gamesWon1, 
                gamesWon2, 
                this.Games[0].GetStringResult(inverse), 
                this.Games[1].GetStringResult(inverse),
                threeGame ? this.Games[2].GetStringResult(inverse) : string.Empty);
        }

        public bool IsAnyPlayerSame(Match m)
        {
            return this.IsPlayerPlaysHere(m.Player1) || this.IsPlayerPlaysHere(m.Player2);
        }

        public bool IsPlayerPlaysHere(Player p)
        {
            return this.Player1 == p || this.Player2 == p;
        }

        public override string ToString()
        {
            return string.Format("{0} vs {1}", this.Player1, this.Player2);
        }

        public int GetPlayerScore(Player player)
        {
            if (!this.IsPlayerPlaysHere(player))
            {
                throw new ArgumentException("This player does not plays in the match!");
            }

            if (this.Progress != MatchProgress.Finished)
            {
                return 0;
            }

            return player == this.Winner ? 3 : 0;
        }

        public int GetPlayerTotalMisses(Player player)
        {
            if (!this.IsPlayerPlaysHere(player))
            {
                throw new ArgumentException("This player does not take part in the match!");
            }

            if (this.Progress != MatchProgress.Finished)
            {
                return 0;
            }

            return this.Games.Select(g => player == this.Player1 ? g.Score2 : g.Score1).Sum();
        }

        public int GetPlayerTotalGoals(Player player)
        {
            if (!this.IsPlayerPlaysHere(player))
            {
                throw new ArgumentException("This player does not take part in the match!");
            }

            if (this.Progress != MatchProgress.Finished)
            {
                return 0;
            }

            return this.Games.Select(g => player == this.Player1 ? g.Score1 : g.Score2).Sum();
        }

        public override MatchData GetXmlData()
        {
            this.Data.GroupId = this.Group.Id;
            this.Data.Games = this.Games.Select(g => g.GetXmlData()).ToList();
            this.Data.Player1Id = this.Player1.Id;
            this.Data.Player2Id = this.Player2.Id;
            return base.GetXmlData();
        }
    }
}

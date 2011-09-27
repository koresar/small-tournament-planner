using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Match
    {
        public Match(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.Games = new List<Game>();
        }

        [DisplayName("Progress")]
        public MatchProgress Progress { get; set; }

        [DisplayName("Player 1")]
        public Player Player1 { get; private set; }

        [DisplayName("Player 2")]
        public Player Player2 { get; private set; }

        [DisplayName("Result")]
        public string StringResult
        {
            get 
            {
                if (this.Games.Count == 0)
                {
                    return string.Empty;
                }

                int gamesWon1 = this.Games.Count(g => g.Score1 > g.Score2);
                int gamesWon2 = this.Games.Count(g => g.Score1 < g.Score2);
                var template = 
                    this.Games.Count == 3 ? "{0}:{1} ({2} {3} {4})" : 
                    this.Games.Count == 2 ? "{0}:{1} ({2} {3})" :
                    "INTERNAL ERROR!";
                return string.Format(template, gamesWon1, gamesWon2, this.Games[0], this.Games[1], this.Games.ElementAtOrDefault(2));
            }
        }

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

        public bool IsAnyPlayerSame(Match m)
        {
            return
                this.Player1 == m.Player1 || this.Player1 == m.Player2 ||
                this.Player2 == m.Player1 || this.Player2 == m.Player2;
        }

        public override string ToString()
        {
            return string.Format("{0} vs {1}", this.Player1, this.Player2);
        }
    }
}

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
        }

        [DisplayName("Progress")]
        public MatchProgress Progress { get; set; }

        [DisplayName("Player 1")]
        public Player Player1 { get; private set; }

        [DisplayName("Player 2")]
        public Player Player2 { get; private set; }
    }
}

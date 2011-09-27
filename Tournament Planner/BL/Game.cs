using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tournament_Planner.BL
{
    public class Game
    {
        public Game(int score1, int score2)
        {
            this.Score1 = score1;
            this.Score2 = score2;
        }

        public int Score1 { get; private set; }

        public int Score2 { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.Score1, this.Score2);
        }
    }
}

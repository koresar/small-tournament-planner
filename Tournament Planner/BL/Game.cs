using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Game
    {
        private GameData data;

        public Game(GameData data)
        {
            this.data = data;
        }

        public Game(int score1, int score2) : this(new GameData())
        {
            this.Score1 = score1;
            this.Score2 = score2;
        }

        public int Score1 { get { return this.data.Score1; } private set { this.data.Score1 = value; } }

        public int Score2 { get { return this.data.Score2; } private set { this.data.Score2 = value; } }

        public string GetStringResult(bool inverse = false)
        {
            return string.Format(!inverse ? "{0}-{1}" : "{1}-{0}", this.Score1, this.Score2);            
        }

        public override string ToString()
        {
            return this.GetStringResult();
        }
    }
}

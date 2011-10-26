using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class GameData
    {
        [XmlElement("Score1")]
        public int Score1 { get; set; }

        [XmlElement("Score2")]
        public int Score2 { get; set; }
    }
}

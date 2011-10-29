using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class MatchData : IIdReferenceItem
    {
        public MatchData()
        {
            this.Games = new List<GameData>();
        }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Player1Id")]
        public int Player1Id { get; set; }

        [XmlElement("Player2Id")]
        public int Player2Id { get; set; }

        [XmlElement("GroupId")]
        public int GroupId { get; set; }

        [XmlElement("Progress")]
        public MatchProgress Progress { get; set; }

        [XmlArray("Games")]
        [XmlArrayItem("Game")]
        public List<GameData> Games { get; set; }
    }
}

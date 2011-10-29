using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class TournamentData
    {
        public TournamentData()
        {
            this.Companies = new List<CompanyData>();
            this.Players = new List<PlayerData>();
            this.Groups = new List<GroupData>();
            this.Matches = new List<MatchData>();
        }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlArray("Companies")]
        [XmlArrayItem("Company")]
        public List<CompanyData> Companies { get; set; }

        [XmlArray("Players")]
        [XmlArrayItem("Player")]
        public List<PlayerData> Players { get; set; }

        [XmlArray("Groups")]
        [XmlArrayItem("Group")]
        public List<GroupData> Groups { get; set; }

        [XmlArray("Matches")]
        [XmlArrayItem("Match")]
        public List<MatchData> Matches { get; set; }

        [XmlElement("PlayOffGroup")]
        public GroupData PlayOffGroup { get; set; }

        [XmlArray("PlayOffMatches")]
        [XmlArrayItem("Match")]
        public List<MatchData> PlayOffMatches { get; set; }

        [XmlArray("FinalPlayers")]
        [XmlArrayItem("Player")]
        public List<PlayerData> FinalPlayers { get; set; }

        [XmlArray("FinalRounds")]
        [XmlArrayItem("Group")]
        public List<GroupData> FinalRounds { get; set; }

        [XmlArray("FinalMatches")]
        [XmlArrayItem("Match")]
        public List<MatchData> FinalMatches { get; set; }
    }
}

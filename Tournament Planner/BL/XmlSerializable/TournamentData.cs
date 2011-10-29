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
        }

        [XmlArray("Companies")]
        [XmlArrayItem("Company")]
        public List<CompanyData> Companies { get; set; }

        [XmlArray("Players")]
        [XmlArrayItem("Player")]
        public List<PlayerData> Players { get; set; }

        [XmlArray("Groups")]
        [XmlArrayItem("Group")]
        public List<GroupData> Groups { get; set; }
    }
}

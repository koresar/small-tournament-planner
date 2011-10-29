using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class GroupData : IIdReferenceItem
    {
        public GroupData()
        {
            this.Players = new List<int>();
        }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlArray("Players")]
        [XmlArrayItem("Id")]
        public List<int> Players { get; set; }
    }
}

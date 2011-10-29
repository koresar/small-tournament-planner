using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class PlayerData
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("SecondName")]
        public string SecondName { get; set; }

        [XmlElement("Gender")]
        public Gender Gender { get; set; }

        [XmlElement("CompanyId")]
        public int CompanyId { get; set; }

        [XmlElement("Skill")]
        public Skill Skill { get; set; }

        [XmlElement("Present")]
        public bool Present { get; set; }
    }
}

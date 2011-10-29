using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public class CompanyData
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
    }
}

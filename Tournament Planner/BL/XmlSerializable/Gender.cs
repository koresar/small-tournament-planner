using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public enum Gender
    {
        [XmlEnum("Male")]
        Male,

        [XmlEnum("Female")]
        Female,
    }
}

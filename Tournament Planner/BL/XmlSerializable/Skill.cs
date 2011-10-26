using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    /// <summary>
    /// Player average skill. The higher the number - the higher the skill.
    /// </summary>
    public enum Skill : byte
    {
        [XmlEnum("Unknown")]
        Unknown,

        [XmlEnum("Beginner")]
        Beginner,

        [XmlEnum("Average")]
        Average,

        [XmlEnum("Good")]
        Good,
    }
}

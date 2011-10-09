﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tournament_Planner.BL.XmlSerializable
{
    public enum Skill
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tournament_Planner.BL.XmlSerializable
{
    public interface IXmlSerializable<TData>
    {
        TData GetXmlData();
    }
}

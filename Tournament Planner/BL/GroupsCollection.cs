using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class GroupsCollection : Repository<Group, GroupData>
    {
        public GroupsCollection(List<GroupData> list, IRepository<Player> playersRepo)
            : base(list.Select(p => new Group(p, playersRepo)).ToList())
        {
        }
    }
}

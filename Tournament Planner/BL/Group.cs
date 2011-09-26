using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Group : BindingList<Player>
    {
        public Group() : base()
        {
        }

        public Group(IList<Player> players)
            : base(players)
        {

        }
    }
}

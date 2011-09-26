using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class MatchesCollection : BindingList<Match>
    {
        public MatchesCollection() : base()
        {
        }

        public MatchesCollection(IList<Match> matches)
            : base(matches)
        {

        }
    }
}

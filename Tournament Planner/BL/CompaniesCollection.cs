using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class CompaniesCollection : BindingList<Company>
    {
        public CompaniesCollection() : base()
        {
        }

        public CompaniesCollection(IList<Company> companies) : base(companies)
        {

        }
    }
}

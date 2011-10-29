using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class CompaniesCollection : Repository<Company, CompanyData>
    {
        public CompaniesCollection() : base()
        {
        }

        public CompaniesCollection(List<CompanyData> list)
            : base(list.Select(c => new Company(c)).ToList())
        {
        }

        public Company GetByName(string name)
        {
            return this.FirstOrDefault(c => c.Name == name);
        }
    }
}

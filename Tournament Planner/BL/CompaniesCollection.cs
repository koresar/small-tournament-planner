using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class CompaniesCollection : BindingList<Company>, IXmlSerializable<List<CompanyData>>
    {
        public CompaniesCollection() : base()
        {
        }

        public CompaniesCollection(IList<Company> companies) : base(companies)
        {
        }

        public CompaniesCollection(List<CompanyData> list)
            : this(list.Select(c => new Company(c)).ToList())
        {
        }

        public List<CompanyData> GetXmlData()
        {
            return this.Select(c => c.GetXmlData()).ToList();
        }

        public Company GetByName(string name)
        {
            return this.First(c => c.Name == name);
        }
    }
}

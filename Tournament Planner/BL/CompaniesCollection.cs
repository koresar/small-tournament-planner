using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class CompaniesCollection : BindingList<Company>, IXmlSerializable<List<CompanyData>>, IRepository<Company>
    {
        private int lastId = 0;

        public CompaniesCollection() : base()
        {
        }

        public CompaniesCollection(List<CompanyData> list)
            : base(list.Select(c => new Company(c)).ToList())
        {
        }

        public List<CompanyData> GetXmlData()
        {
            return this.Select(c => c.GetXmlData()).ToList();
        }

        public Company GetByName(string name)
        {
            return this.FirstOrDefault(c => c.Name == name);
        }

        public Company GetById(int id)
        {
            return this.FirstOrDefault(c => c.Id == id);
        }

        new public void Add(Company c)
        {
            this.CheckNew(c);

            base.Add(c);
        }

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (e.NewObject is Company)
            {
                this.CheckNew(e.NewObject as Company);
            }

            base.OnAddingNew(e);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                this.CheckId(this[e.NewIndex]);
            }
        }

        private void CheckNew(Company c)
        {
            if (this.GetByName(c.Name) != null)
            {
                throw new InvalidOperationException("Such company already present in collection: " + c.Name);
            }
            else if (this.GetById(c.Id) != null)
            {
                throw new InvalidOperationException("Such company ID already present in collection: " + c.Id + " (" + c.Name + ")");
            }

            this.CheckId(c);
        }

        private void CheckId(Company c)
        {
            if (c.Id == 0)
            {
                this.lastId++;
                c.Id = this.lastId;
            }
        }
    }
}

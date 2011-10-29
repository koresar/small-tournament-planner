using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Repository<T, TData> : BindingList<T>, IRepository<T>, IXmlSerializable<List<TData>> where T : IIdReferenceItem, IXmlSerializable<TData>
    {
        private int lastId = 0;

        public Repository() : base()
	    {
	    }

        public Repository(IList<T> list) : base(list)
        {
        }

        public T GetById(int id)
        {
            return this.FirstOrDefault(i => i.Id == id);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                this.CheckId(this[e.NewIndex]);
            }
        }

        private void CheckId(IIdReferenceItem p)
        {
            if (this.lastId == 0 && this.Count > 0)
            {
                this.lastId = this.Select(i => i.Id).Max();
            }

            if (p.Id == 0)
            {
                this.lastId++;
                p.Id = this.lastId;
            }
        }

        public List<TData> GetXmlData()
        {
            return this.Select(i => i.GetXmlData()).ToList();
        }
    }
}

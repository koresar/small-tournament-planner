using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL.XmlSerializable;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class IdItem<TData> : IXmlSerializable<TData>, IIdReferenceItem where TData : class, IIdReferenceItem, new()
    {
        public IdItem ()
	    {
            this.Data = new TData();
	    }

        public IdItem(TData data)
        {
            this.Data = data;
        }

        [Browsable(false)]
        protected TData Data { get; private set; }

        [Browsable(false)]
        public int Id
        {
            get { return this.Data.Id; }
            set { this.Data.Id = value; }
        }

        public virtual TData GetXmlData()
        {
            return this.Data;
        }

        public override bool Equals(object obj)
        {
            var item = obj as IdItem<TData>;
            return
                item != null &&
                item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}

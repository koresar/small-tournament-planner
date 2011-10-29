using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tournament_Planner.BL.XmlSerializable;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class IdItem<T> : IXmlSerializable<T>, IIdReferenceItem where T : class, IIdReferenceItem, new()
    {
        public IdItem ()
	    {
            this.Data = new T();
	    }

        public IdItem(T data)
        {
            this.Data = data;
        }

        [Browsable(false)]
        protected T Data { get; private set; }

        [Browsable(false)]
        public int Id
        {
            get { return this.Data.Id; }
            set { this.Data.Id = value; }
        }

        public virtual T GetXmlData()
        {
            return this.Data;
        }

        public override bool Equals(object obj)
        {
            var item = obj as IdItem<T>;
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

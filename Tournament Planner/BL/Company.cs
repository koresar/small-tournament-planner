using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Company
    {
        public Company()
        {

        }

        public Company(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name should not be null");
            }

            this.Name = name;
        }

        [DisplayName("Company name")]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Company && (obj as Company).Name == this.Name;
        }

        public override int GetHashCode()
        {
            return this.Name == null ? 0 : this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

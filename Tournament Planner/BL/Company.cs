using System;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Company : IdItem<CompanyData>
    {
        public const string DefaultCompanyName = "Enter company name";

        /// <summary>
        /// This constructor is necessary for UI binding.
        /// </summary>
        public Company() : base()
        {
            this.Name = DefaultCompanyName;
        }

        public Company(CompanyData data) : base(data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                throw new ArgumentException("Company name should not be empty.");
            }
        }

        [DisplayName("Company name")]
        public string Name
        {
            get { return this.Data.Name; }
            set { this.Data.Name = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

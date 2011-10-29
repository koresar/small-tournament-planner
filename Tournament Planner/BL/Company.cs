using System;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Company : IXmlSerializable<CompanyData>
    {
        public const string DefaultCompanyName = "Enter company name";
        private CompanyData data;

        /// <summary>
        /// This constructor is necessary for UI binding.
        /// </summary>
        public Company()
        {
            this.data = new CompanyData() { Name = DefaultCompanyName };
        }

        public Company(CompanyData data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                throw new ArgumentException("Company name should not be empty.");
            }

            this.data = data;
        }

        [Browsable(false)]
        public int Id
        {
            get { return this.data.Id; }
            set { this.data.Id = value; }
        }

        [DisplayName("Company name")]
        public string Name
        {
            get { return this.data.Name; }
            set { this.data.Name = value; }
        }

        public CompanyData GetXmlData()
        {
            return this.data;
        }

        public override bool Equals(object obj)
        {
            return obj is Company && (obj as Company).Name == this.Name;
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(this.Name) ? 0 : this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

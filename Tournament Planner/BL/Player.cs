using System;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Player : IdItem<PlayerData>
    {
        private const string forbiddenCharacters = ",";
        private const string csvSeparator = ",";
        private Company company;

        public Player(PlayerData data, IRepository<Company> companiesRepo) : base(data)
        {
            if (string.IsNullOrEmpty(data.FirstName) || string.IsNullOrEmpty(data.SecondName) || data.CompanyId == 0)
            {
                throw new ArgumentException("Arguments should not be empty.");
            }

            this.company = companiesRepo.GetById(this.Data.CompanyId);
        }

        [DisplayName("First name")]
        public string FirstName
        {
            get { return this.Data.FirstName; }
            set { this.Data.FirstName = value.Replace(forbiddenCharacters, string.Empty); }
        }

        [DisplayName("Second name")]
        public string SecondName
        {
            get { return this.Data.SecondName; }
            set { this.Data.SecondName = value.Replace(forbiddenCharacters, string.Empty); }
        }

        [DisplayName("Gender")]
        public Gender Gender
        {
            get { return this.Data.Gender; }
            set { this.Data.Gender = value; }
        }

        [DisplayName("Company")]
        public Company Company
        {
            get { return this.company; }
            set
            {
                this.Data.CompanyId = value.Id;
                this.company = value;
            }
        }

        [DisplayName("Skill")]
        public Skill Skill { get { return this.Data.Skill; } set { this.Data.Skill = value; } }

        //[DisplayName("Group")]
        //public Group StartGroup { get; set; }

        [DisplayName("Present")]
        public bool Present { get { return this.Data.Present; } set { this.Data.Present = value; } }

        [Browsable(false)]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.SecondName); }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}), {3}", this.FirstName, this.SecondName, this.Gender, this.Company);
        }
    }
}

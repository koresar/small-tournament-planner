using System;
using System.ComponentModel;
using Tournament_Planner.BL.XmlSerializable;

namespace Tournament_Planner.BL
{
    public class Player : IXmlSerializable<PlayerData>
    {
        private const string forbiddenCharacters = ",";
        private const string csvSeparator = ",";
        private PlayerData data;
        private Company company;

        public Player(PlayerData data, IRepository<Company> companiesRepo)
        {
            if (string.IsNullOrEmpty(data.FirstName) || string.IsNullOrEmpty(data.SecondName) || data.CompanyId == 0)
            {
                throw new ArgumentException("Arguments should not be empty.");
            }

            this.data = data;
            this.company = companiesRepo.GetById(this.data.CompanyId);
        }

        [DisplayName("First name")]
        public string FirstName
        {
            get { return this.data.FirstName; }
            set { this.data.FirstName = value.Replace(forbiddenCharacters, string.Empty); }
        }

        [DisplayName("Second name")]
        public string SecondName
        {
            get { return this.data.SecondName; }
            set { this.data.SecondName = value.Replace(forbiddenCharacters, string.Empty); }
        }

        [DisplayName("Gender")]
        public Gender Gender
        {
            get { return this.data.Gender; }
            set { this.data.Gender = value; }
        }

        [DisplayName("Company")]
        public Company Company
        {
            get { return this.company; }
            set
            {
                this.data.CompanyId = value.Id;
                this.company = value;
            }
        }

        [DisplayName("Skill")]
        public Skill Skill { get { return this.data.Skill; } set { this.data.Skill = value; } }

        [DisplayName("Group")]
        public Group StartGroup { get; set; }

        [DisplayName("Present")]
        public bool Present { get { return this.data.Present; } set { this.data.Present = value; } }

        [Browsable(false)]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.SecondName); }
        }

        public PlayerData GetXmlData()
        {
            return this.data;
        }

        public override bool Equals(object obj)
        {
            var p2 = obj as Player;
            return (p2 != null) && 
                ((object.ReferenceEquals(this, p2)) ||
                (p2.FirstName == this.FirstName && p2.SecondName == this.SecondName && p2.Gender == this.Gender && p2.Company.Equals(this.Company)));
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}), {3}", this.FirstName, this.SecondName, this.Gender, this.Company);
        }
    }
}

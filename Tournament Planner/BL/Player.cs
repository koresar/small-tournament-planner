using System;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public enum Skill
    {
        Beginner,
        Average,
        Good,
    }

    public class Player
    {
        private const string forbiddenCharacters = ",";
        private const string csvSeparator = ",";
        private string firstName;
        private string secondName;

        public Player(string firstName, string secondName, Gender gender, Company company, Skill skill)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) || company == null)
            {
                throw new ArgumentException("Arguments should not be empty.");
            }

            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Gender = gender;
            this.Company = company;
            this.Skill = skill;
        }

        [DisplayName("First name")]
        public string FirstName { get { return this.firstName; } set { this.firstName = value.Replace(forbiddenCharacters, string.Empty); } }

        [DisplayName("Second name")]
        public string SecondName { get { return this.secondName; } set { this.secondName = value.Replace(forbiddenCharacters, string.Empty); } }

        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [DisplayName("Company")]
        public Company Company { get; set; }

        [DisplayName("Group")]
        public Group StartGroup { get; set; }

        [DisplayName("Skill")]
        public Skill Skill { get; set; }

        [Browsable(false)]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.SecondName); }
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

        public string ToCsvString()
        {
            return string.Format(
                "{1}{0}{2}{0}{3}{0}{4}{0}{5}", 
                csvSeparator,
                this.FirstName,
                this.SecondName,
                this.Gender == BL.Gender.Male ? "M" : "F",
                this.Company.Name,
                (int)this.Skill);
        }

        public static Player FromCsvString(string line)
        {
            string[] items = line.Split(csvSeparator.ToCharArray());

            return new Player(
                items[0], 
                items[1], 
                items[2] == "M" ? Gender.Male : Gender.Female, 
                new Company(items[3]),
                (Skill)int.Parse(items[4]));
        }
    }
}

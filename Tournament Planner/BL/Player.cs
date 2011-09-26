using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tournament_Planner.BL
{
    public class Player
    {
        public Player(string firstName, string secondName, Gender gender, Company company)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) || company == null)
            {
                throw new ArgumentException("Arguments should not be empty.");
            }

            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Gender = gender;
            this.Company = company;
        }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Second name")]
        public string SecondName { get; set; }

        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [DisplayName("Company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            var p2 = obj as Player;
            return p2 != null && p2.FirstName == this.FirstName && p2.SecondName == this.SecondName && p2.Gender == this.Gender && p2.Company.Equals(this.Company);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}), {3}", this.FirstName, this.SecondName, this.Gender, this.Company);
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.SecondName); }
        }
    }
}

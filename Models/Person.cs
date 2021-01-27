using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person : Entity
    {
        public Person()
        {
        }

        public Person(string firstName, string lastName, DateTime birthDate, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int SomeInt { get; set; }
        public string Address { get; set; }
        public DateTime NamedayDate { get; set; }

        public bool ShouldSerializeFirstName()
        {
            return Gender != Gender.Male;
        }

        public override string ToString()
        {
            //return Id + " " + FirstName + " " + LastName + " " + Gender + " " + BirthDate.ToShortDateString();
            //return string.Format("{0, -3} {1, -10} {2, -15} {3, -7} {4, -10}", Id, FirstName, LastName, Gender, BirthDate.ToShortDateString());
            return $"{Id, -3} {FirstName, -10} {LastName, -15} {Gender, -7} {BirthDate.ToShortDateString(), -10}";
        }

    }
}

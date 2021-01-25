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

    }
}

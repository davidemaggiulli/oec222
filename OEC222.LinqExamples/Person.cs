using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.LinqExamples
{
    internal class Person
    {
        public Person(string firstName, string lastName, DateOnly birthDate, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public DateOnly BirthDate { get; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public Gender Gender { get; }
    }
}

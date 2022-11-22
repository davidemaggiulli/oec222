using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    internal class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }

        public DateOnly BirthDate { get; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public int Height { get; }

        public int Weight { get; }
        
        public Gender Gender { get; }

        public decimal Ral { get; set; }

        public string Office { get; set; }

        public Employee(string firstName, string lastName, DateOnly birthDate, int height, int weight, Gender gender, decimal ral = 1000, string office = null)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
            Gender = gender;
            Ral = ral;
            Office = office;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.LinqExamples
{
    internal class Employee : Person
    {
        
        public int Height { get; }

        public int Weight { get; }
        
        public decimal Ral { get; set; }

        public string Office { get; set; }

        public Employee(string firstName, string lastName, DateOnly birthDate, int height, int weight, Gender gender, decimal ral = 1000, string office = null) : base(firstName,lastName,birthDate,gender)
        {
            Height = height;
            Weight = weight;
            Ral = ral;
            Office = office;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\t{Ral:C2}\t{BirthDate:d}\t{Height}cm\t{Weight}Kg";
        }
    }
}

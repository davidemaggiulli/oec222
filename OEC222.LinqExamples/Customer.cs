using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.LinqExamples
{
    internal class Customer : Person
    {
        public Customer(string firstName, string lastName, DateOnly birthDate, Gender gender) : base(firstName, lastName, birthDate, gender)
        {
        }
        public Customer(string firstName, string lastName, DateOnly birthDate, Gender gender, string address) : this(firstName,lastName,birthDate,gender)
        {
            Address = address;
        }
        public string Address { get; set; }
    }
}

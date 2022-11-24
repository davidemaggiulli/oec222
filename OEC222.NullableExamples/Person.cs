using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.NullableExamples
{
    internal class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int? Age { get;  }

        public int Height { get; }

        public Person(string firstName, string lastName,int height, int? age = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
        }
    }
}

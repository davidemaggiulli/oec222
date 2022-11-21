using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Day1
{
    public class Person
    {
        public string Name;  //Campo pubblico

        public string Surname; //Campo pubblico


        private DateOnly BirthDate;
        public void SetBirthDate(DateOnly d)
        {
            BirthDate = d;
        }

        public DateOnly GetBirthDate()
        {
            return BirthDate;
        }

        private string email;

        public string Email   //Proprietà pubblica su campo di appoggio privato
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
       
    }
}

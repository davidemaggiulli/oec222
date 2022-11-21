using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OEC222.Day1
{
    
    public class Employee
    {
        #region Stato Interno
        public string Name { get;}
        public string Surname { get;}
        public DateOnly BirthDate { get;  }
        public string BirthPlace { get;  }
        public string Address { get; set; }

        [field: NonSerialized]
        public decimal RAL { get; private set; }

        private string Pippo { get; set; }
       

        //private decimal _ral;
        //public decimal getRAL()
        //{
        //    return _ral;
        //}
        //private void setRAL(decimal ral)
        //{
        //    _ral = ral;
        //}
        public string Email { get; }

        #endregion

        public Employee(string name, string surname, DateOnly birthDate, string birthPlace, string email) : this(name,surname,birthDate,birthPlace, email,1000,null)
        {

        }

        public Employee(string name, string surname, DateOnly birthDate, string birthPlace, string email, decimal ral, string address)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            RAL = 1000;
            if (!new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email).Success)
            {
                Email = null;
            }
            else
            {
                Email = email;
            }
            Address = address;
            if (ral <= 200)
                RAL = 200;
            else
                RAL = ral;
        }

        
        internal void UpgradeEmployee()
        {
            RAL *= 1.1m;
        }

        private void ResetRAL()
        {
            RAL = 200.0m;
        }

        

    }
}

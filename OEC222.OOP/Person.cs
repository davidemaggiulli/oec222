using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email is empty");
                }
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match math = regex.Match(value);
                if (!math.Success)
                {
                    throw new ArgumentException("Email not valid");
                }

                email = value;
            }
        }

        public int Age   //Proprietà in sola lettura e CALCOLATA
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }

        public string BirthPlace { get; set; }   //Proprietà automatica a lettura e scrittura

        public decimal RAL { get; private set; }  //Proprietà automatica a letture pubblica e scrittura privata


        public void UpgradeEmployee()
        {
            RAL = RAL * 1.1m;
        }

        public Person()   //Costruttore vuoto ( o di default)
        {
            RAL = 1000;
        }

    }
}

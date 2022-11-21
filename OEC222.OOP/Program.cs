using System.Globalization;

namespace OEC222.Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello, World!");

            Person p = new Person();

            p.Name = "Davide";
            p.Surname = "Maggiulli";

            //p.BirthDate = new DateOnly(1987, 6, 27);
            p.SetBirthDate(new DateOnly(1987,6,27));

            p.Email = "davide.maggiulli@gmail.com";
            p.BirthPlace = "Lecce";
            p.UpgradeEmployee();

            Console.WriteLine("Nome: " + p.Name + " Cognome: " + p.Surname + " Data di nascita: " + p.GetBirthDate());
            Console.WriteLine(p.BirthPlace);
            Console.WriteLine(p.RAL);


            Employee emp = new Employee("Davide", "Maggiulli", new DateOnly(1987, 6, 27), "Lecce", "pippo@pippo.it");

            Employee emp1 = new Employee("Pippo", "Pluto", new DateOnly(2000, 1, 1), "Milano", "pippo@pluto.it", 500, "Corso Garibaldi 1");
            

            emp.UpgradeEmployee();
            emp1.UpgradeEmployee();


            
            double pi = Math.PI;
            Console.WriteLine(pi.ToString("F2"));
            Console.WriteLine(pi.ToString("F8"));
            Console.WriteLine(pi.ToString("F6"));

            double num = 100212121.121323;
            Console.WriteLine(num.ToString("E10"));

            Console.WriteLine(num.ToString("C2"));
            Console.WriteLine(num.ToString("C4"));
            Console.WriteLine(num.ToString("C6"));
            Console.WriteLine(num.ToString("C10"));

            var engCulture = new CultureInfo("en-UK");
            Console.WriteLine(num.ToString("C6",engCulture));

            var usCulture = new CultureInfo("en-US");
            Console.WriteLine(num.ToString("C6", usCulture));
            Console.WriteLine(num.ToString("C", usCulture));

            int num2 = 123456;
            Console.WriteLine(num2.ToString("D2"));
            Console.WriteLine(num2.ToString("D5"));
            Console.WriteLine(num2.ToString("D10"));
            //Console.WriteLine(num.ToString("D10"));

            //G Generale: sceglie tra notazione F e E quella più compatta
            Console.WriteLine(num.ToString("G4"));
            Console.WriteLine(num2.ToString("G4"));
            Console.WriteLine(10.ToString("G4"));

            Console.WriteLine(num.ToString("N4"));
            Console.WriteLine(num2.ToString("N4"));

            double perc = 0.454542;
            Console.WriteLine(perc.ToString("P2"));
            Console.WriteLine(perc.ToString("P4"));
            Console.WriteLine(perc.ToString("P10"));


            byte b = 123;
            Console.WriteLine(b.ToString("X"));
            Console.WriteLine(b.ToString("X2"));
            Console.WriteLine(b.ToString("X4"));
            Console.WriteLine(b.ToString("X20"));

            Console.WriteLine(pi.ToString("R"));

            Console.ReadLine();

        }
    }
}
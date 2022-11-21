namespace OEC222.Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            

            Console.ReadLine();

        }
    }
}
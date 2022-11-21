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

            Console.WriteLine("Nome: " + p.Name + " Cognome: " + p.Surname + " Data di nascita: " + p.GetBirthDate());

            Console.ReadLine();

        }
    }
}
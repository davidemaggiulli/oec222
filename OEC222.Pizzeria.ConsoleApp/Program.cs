using OEC222.Pizzeria.Core.EF;

namespace OEC222.Pizzeria.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** Pizzeria **");
            
            using PizzeriaDbContext db = new PizzeriaDbContext();
            var pizzas = db.Pizzas;

        }
    }
}
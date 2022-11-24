using OEC222.Pizzeria.Core.EF;
using OEC222.Pizzeria.Core.EF.Repositories;
using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;

namespace OEC222.Pizzeria.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("** Pizzeria **");
            
            using PizzeriaDbContext db = new PizzeriaDbContext();

            IPizzaRepository pizzaRepo = new EFPizzaRepository(db);

            var pizzas = await pizzaRepo.FetchAsync();

            //await pizzaRepo.AddItemAsync(new Core.Models.Pizza
            //{
            //    Code = "MRG",
            //    Name = "Margherita",
            //    Price = 6,
            //    Compositions = new List<Composition>()
            //    {
            //        new Composition
            //        {
            //            Ingredient = new Ingredient
            //            {
            //                Code = "MRZ",
            //                Name = "Mozzarella",
            //                Cost = 1.5m,
            //                Stock = 100
            //            },
            //            Quantity = 1
            //        },
            //        new Composition
            //        {
            //            Ingredient = new Ingredient
            //            {
            //                Code = "PMD",
            //                Name = "Pomodoro",
            //                Stock = 100,
            //                Cost = 1
            //            },
            //            Quantity = 2
            //        }
            //    }
            //});

        }
    }
}
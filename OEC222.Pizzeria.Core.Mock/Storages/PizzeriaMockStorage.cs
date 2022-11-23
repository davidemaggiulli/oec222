using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OEC222.Pizzeria.Core.Mock.Storages
{
    public static class PizzeriaMockStorage
    {
        public static IList<Pizza> Pizzas { get; set; }
        public static IList<Ingredient> Ingredients { get; set; }
        public static IList<Composition> Compositions { get; set; }

        public static void Initialize()
        {
            Pizzas = new List<Pizza>();
            Pizza margheritaP = new Pizza
            {
                Code = "MRG",
                Name = "Margherita",
                Price = 6m,
                Compositions = new List<Composition>()
            };
            Pizza funghiP = new Pizza
            {
                Code = "FNG",
                Name = "Funghi",
                Price = 7m,
                Compositions = new List<Composition>()
            };
            Pizza salsicciaFriarielliP = new Pizza
            {
                Code = "SFR",
                Name = "Salsiccia e Friarielli",
                Price = 8m,
                Compositions = new List<Composition>()
            };

            Ingredient mozzarella = new Ingredient
            {
                Code = "MZR",
                Name = "Mozzarella",
                Cost = 2m,
                Stock = 100f
            };
            Ingredient pomodoro = new Ingredient
            {
                Code = "PMD",
                Name = "Pomodoro",
                Cost = 1m,
                Stock = 100f
            };
            Ingredient funghi = new Ingredient
            {
                Code = "FNG",
                Name = "Funghi",
                Cost = 1.5m,
                Stock = 100f
            };
            Ingredient salsiccia = new Ingredient
            {
                Code = "SSC",
                Name = "Salsiccia",
                Cost = 2m,
                Stock = 100f
            };
            Ingredient friarielli = new Ingredient
            {
                Code = "FRL",
                Name = "Friarielli",
                Cost = 1.5m,
                Stock = 100f
            };

            Composition mrg1 = new Composition
            {
                Pizza = margheritaP,
                Ingredient = mozzarella,
                Quantity = 1
            };
            Composition mrg2 = new Composition
            {
                Pizza = margheritaP,
                Ingredient = pomodoro,
                Quantity = 1
            };
            Composition fng1 = new Composition
            {
                Pizza = funghiP,
                Ingredient = mozzarella,
                Quantity = 1
            };
            Composition fng2 = new Composition
            {
                Pizza = funghiP,
                Ingredient = pomodoro,
                Quantity = 1
            };
            Composition fng3 = new Composition
            {
                Pizza = funghiP,
                Ingredient = funghi,
                Quantity = 1
            };

            Composition sfr1 = new Composition
            {
                Pizza = salsicciaFriarielliP,
                Ingredient = mozzarella,
                Quantity = 1
            };
            Composition sfr2 = new Composition
            {
                Pizza = salsicciaFriarielliP,
                Ingredient = pomodoro,
                Quantity = 1
            };
            Composition sfr3 = new Composition
            {
                Pizza = salsicciaFriarielliP,
                Ingredient = salsiccia,
                Quantity = 1
            };
            Composition sfr4 = new Composition
            {
                Pizza = salsicciaFriarielliP,
                Ingredient = friarielli,
                Quantity = 1
            };

            margheritaP.Compositions.Add(mrg1);
            margheritaP.Compositions.Add(mrg2);

            funghiP.Compositions.Add(fng1);
            funghiP.Compositions.Add(fng2);
            funghiP.Compositions.Add(fng3);

            salsicciaFriarielliP.Compositions.Add(sfr1);
            salsicciaFriarielliP.Compositions.Add(sfr2);
            salsicciaFriarielliP.Compositions.Add(sfr3);
            salsicciaFriarielliP.Compositions.Add(sfr4);

            Pizzas.Add(margheritaP);
            Pizzas.Add(funghiP);
            Pizzas.Add(salsicciaFriarielliP);

            Ingredients.Add(pomodoro);
            Ingredients.Add(mozzarella);
            Ingredients.Add(funghi);
            Ingredients.Add(salsiccia);
            Ingredients.Add(friarielli);

            Compositions.Add(mrg1);
            Compositions.Add(mrg2);
            Compositions.Add(fng1);
            Compositions.Add(fng2);
            Compositions.Add(fng3);
            Compositions.Add(sfr1);
            Compositions.Add(sfr2);
            Compositions.Add(sfr3);
            Compositions.Add(sfr4);



        }
    }
}

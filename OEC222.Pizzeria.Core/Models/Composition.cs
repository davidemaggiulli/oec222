using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Models
{
    public class Composition
    {
        public string PizzaCode { get; set; }
        public Pizza Pizza { get; set; }

        public string IngredientCode { get; set; }
        public Ingredient Ingredient { get; set; }

        public float Quantity { get; set; }
    }
}

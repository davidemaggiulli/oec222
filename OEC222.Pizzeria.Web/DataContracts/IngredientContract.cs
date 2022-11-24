using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Web.DataContracts
{
    public class IngredientContract
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public float Stock { get; set; }
    }
}

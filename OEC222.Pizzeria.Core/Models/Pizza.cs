using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Models
{
    public class Pizza
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IList<Composition> Compositions { get; set; }

        public string FormattedPrice => $"{Price}:C2";
    }
}

using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.EF.Repositories
{
    public class EFPizzaRepository : IPizzaRepository
    {
        public Task<BLResult> AddItemAsync(Pizza item)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> DeleteItemAsync(Pizza item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pizza>> FetchAsync(Func<Pizza, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> UpdateItemAsync(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}

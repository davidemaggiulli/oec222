using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Mock.Repositories
{
    public class MockIngredientRepository : IIngredientRepository
    {
        public Task<BLResult> AddItemAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> DeleteItemAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ingredient>> FetchAsync(Func<Ingredient, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> UpdateItemAsync(Ingredient item)
        {
            throw new NotImplementedException();
        }
    }
}

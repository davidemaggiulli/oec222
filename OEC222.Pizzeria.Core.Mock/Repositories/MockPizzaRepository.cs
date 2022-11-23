using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Mock.Storages;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Mock.Repositories
{
    public class MockPizzaRepository : IPizzaRepository
    {
        public async Task<BLResult> AddItemAsync(Pizza item)
        {
            Pizza exisingPizza = await GetByIdAsync(item.Code);
            if (exisingPizza != null)
                return new BLResult($"Pizza {item.Code} already exists.");
            PizzeriaMockStorage.Pizzas.Add(item);
            return new BLResult();
        }

        public async Task<BLResult> DeleteItemAsync(Pizza item)
        {
            PizzeriaMockStorage.Pizzas.Remove(item);
            return new BLResult();
        }

        public async Task<IEnumerable<Pizza>> FetchAsync(Func<Pizza, bool> filter = null)
        {
            if (filter == null)
                return PizzeriaMockStorage.Pizzas;
            return PizzeriaMockStorage.Pizzas.Where(filter);
        }

        public async Task<Pizza> GetByIdAsync(object id)
        {
            if (id == null || id is not string)
                return null;

            return PizzeriaMockStorage.Pizzas.SingleOrDefault(x => x.Code == (id as string));
        }

        public async Task<BLResult> UpdateItemAsync(Pizza item)
        {
            Pizza existing = await GetByIdAsync(item.Code);
            await DeleteItemAsync(existing);
            PizzeriaMockStorage.Pizzas.Add(item);
            return new BLResult();
        }
    }
}

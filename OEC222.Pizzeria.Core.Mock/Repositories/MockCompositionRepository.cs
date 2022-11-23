using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Mock.Repositories
{
    public class MockCompositionRepository : ICompositionRepository
    {
        public Task<BLResult> AddItemAsync(Composition item)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> DeleteItemAsync(Composition item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Composition>> FetchAsync(Func<Composition, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Composition> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<BLResult> UpdateItemAsync(Composition item)
        {
            throw new NotImplementedException();
        }
    }
}

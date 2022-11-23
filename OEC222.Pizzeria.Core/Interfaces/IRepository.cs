using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FetchAsync(Func<T, bool> filter = null);
        Task<T> GetByIdAsync(object id);
        Task<BLResult> AddItemAsync(T item);
        Task<BLResult> UpdateItemAsync(T item);
        Task<BLResult> DeleteItemAsync(T item);
    }
}

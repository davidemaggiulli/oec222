using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private readonly PizzeriaDbContext _dbContext;

        public EFPizzaRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<BLResult> AddItemAsync(Pizza item)
        {
            if (item == null)
                return new BLResult("Pizza is null");
            _dbContext.Pizzas.Add(item);
            try
            {
                await _dbContext.SaveChangesAsync();
            }catch(DbUpdateException e)
            {
                return new BLResult(false, "Cannot insert pizza. Db error", e);
            }catch(Exception e)
            {
                return new BLResult("Cannot update pizza. Generic Error.");
            }
            return new BLResult();
        }

        public async Task<BLResult> DeleteItemAsync(Pizza item)
        {
            if (item == null)
                return new BLResult("Pizza is null");
            _dbContext.Pizzas.Remove(item);
            try
            {
                await _dbContext.SaveChangesAsync();
            }catch(Exception e)
            {
                return new BLResult(false, "Cannot insert pizza. Db error", e);
            }
            return new BLResult();
        }

        public async Task<IEnumerable<Pizza>> FetchAsync(Func<Pizza, bool> filter = null)
        {
            if (filter == null)
                return await _dbContext.Pizzas
                    .Include(x => x.Compositions)
                        .ThenInclude(x => x.Ingredient)
                    .ToListAsync();
            return _dbContext.Pizzas.Where(filter).ToList();
        }

        public async Task<Pizza> GetByIdAsync(object id)
        {
            return await _dbContext.Pizzas.FindAsync(id);
        }

        public async Task<BLResult> UpdateItemAsync(Pizza item)
        {
            if (item == null)
                return new BLResult("Pizza is null");

            _dbContext.Pizzas.Update(item);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new BLResult(false, "Cannot insert pizza. Db error", e);
            }
            return new BLResult();
        }
    }
}

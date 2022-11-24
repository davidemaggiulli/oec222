using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.Interfaces
{
    public interface IMainBusinessLogic
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<BLResult> InsertNewPizzaAsync(string code, string name, decimal price);

        Task<BLResult> AssignIngredientToPizzaAsync(string codePizza, string codeIngredient, float qty);

    }
}

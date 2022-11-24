using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.BusinessLogic
{
    public class MainBusinessLogic : IMainBusinessLogic
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICompositionRepository _compositionRepository;

        public MainBusinessLogic(IPizzaRepository pizzaRepository, IIngredientRepository ingredientRepository, ICompositionRepository compositionRepository)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
            _compositionRepository = compositionRepository;
        }

        public async Task<BLResult> AssignIngredientToPizzaAsync(string codePizza, string codeIngredient, float qty)
        {
            if (qty <= 0)
                return new BLResult($"Qty invalid: {qty}");
            var pizza = await _pizzaRepository.GetByIdAsync(codePizza);
            if (pizza == null)
                return new BLResult($"Pizza invalid. Code: '{codePizza}'");
            var ingredient = await _ingredientRepository.GetByIdAsync(codeIngredient);
            if(ingredient == null)
                return new BLResult($"Ingredient invalid. Code: '{codeIngredient}'");

            Composition composition = new Composition
            {
                Pizza = pizza,
                Ingredient = ingredient,
                Quantity = qty
            };

            return await _compositionRepository.AddItemAsync(composition);
        }

        public async Task<BLResult> InsertNewPizzaAsync(string code, string name, decimal price)
        {
            if (string.IsNullOrEmpty(code))
                return new BLResult("Code is empty");

            if (string.IsNullOrEmpty(name))
                return new BLResult("Name is empty");

            if (price <= 0)
                return new BLResult("Price is not positive");

            Pizza pizza = new Pizza
            {
                Code = code,
                Name = name,
                Price = price
            };

            //Task<BLResult> result = _pizzaRepository.AddItemAsync(pizza);
            //return await result;
            return await _pizzaRepository.AddItemAsync(pizza);
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas(decimal? filter = null)
        {
            if(filter.HasValue)
            {
                return await _pizzaRepository.FetchAsync(p => p.Price >= filter.Value);
            }
            return await _pizzaRepository.FetchAsync();
        }
    }
}

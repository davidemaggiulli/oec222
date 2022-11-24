using Microsoft.AspNetCore.Mvc;
using OEC222.Pizzeria.Web.Models;
using OEC222.Pizzeria.Web.Utils;

namespace OEC222.Pizzeria.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly PizzeriaApiClient _client;
        public MenuController(PizzeriaApiClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            //Recuperare i dati
            var pizzas = await _client.GetAllPizzas();

            //Costruire un modello
            var models = pizzas.Select(x => new PizzaViewModel(
                x.Name,
                x.Price,
                x.Compositions.Count(), 
                x.Compositions.Any(c => c.IngredientCode == "MRZ") 
            ));

            //Recuperare la vista
            return View(models);
        }

        public IActionResult Create()
        {
            var model = new CreatePizzaViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.InsertPizza(model.Code, model.Name, model.Price);
                if (string.IsNullOrEmpty(response))
                    return RedirectToAction("Index");
                ModelState.AddModelError("",response);
            }
            return View(model);
        }
    }
}

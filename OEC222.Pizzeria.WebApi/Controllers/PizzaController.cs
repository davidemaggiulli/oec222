using Microsoft.AspNetCore.Mvc;
using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Models;

namespace OEC222.Pizzeria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMainBusinessLogic _logic;

        public PizzaController(IMainBusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(IEnumerable<Pizza>))]
        public async Task<IActionResult> GetPizzas()
        {
            var result = await _logic.GetAllPizzas();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> InsertPizza([FromBody]Pizza pizza)
        {
            if (pizza == null)
                return BadRequest("Input data invalid");
            BLResult result = await _logic.InsertNewPizzaAsync(pizza.Code, pizza.Name, pizza.Price);
            if (result.Success)
                return NoContent();
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
        }

    }
}

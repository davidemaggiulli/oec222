using Newtonsoft.Json;
using OEC222.Pizzeria.Web.DataContracts;
using System.Text;
using System.Text.Json;

namespace OEC222.Pizzeria.Web.Utils
{
    public class PizzeriaApiClient : IDisposable
    {
        private HttpClient _httpClient;

        public PizzeriaApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7277/");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            _httpClient = null;
        }

        public async Task<IEnumerable<PizzaContract>> GetAllPizzas(decimal? filter = null)
        {
            string url = filter.HasValue
                ? $"api/pizza?filter={filter.Value}"
                : "api/pizza";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return (List<PizzaContract>)JsonConvert.DeserializeObject<List<PizzaContract>>(json);
            }
            return new List<PizzaContract>();
        }

        public async Task<string> InsertPizza(string code, string name, decimal price)
        {
            PizzaContract pizzaContract = new PizzaContract
            {
                Code = code,
                Name = name,
                Price = price
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(pizzaContract), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/pizza", content);
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}

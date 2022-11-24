namespace OEC222.Pizzeria.Web.Models
{
    public class PizzaViewModel
    {
        public string Name { get; }

        public decimal Price { get; }

        public int IngredientCount { get; }

        public bool HasMozzarella { get; }

        public PizzaViewModel(string name, decimal price, int ingredientCount, bool hasMozzarella)
        {
            Name = name;
            Price = price;
            IngredientCount = ingredientCount;
            HasMozzarella = hasMozzarella;
        }
    }
}

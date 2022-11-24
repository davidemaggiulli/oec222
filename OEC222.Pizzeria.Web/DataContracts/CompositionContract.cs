namespace OEC222.Pizzeria.Web.DataContracts
{
    public class CompositionContract
    {
        public string PizzaCode { get; set; }
        public PizzaContract Pizza { get; set; }

        public string IngredientCode { get; set; }
        public IngredientContract Ingredient { get; set; }

        public float Quantity { get; set; }
    }
}

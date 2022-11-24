namespace OEC222.Pizzeria.Web.DataContracts
{
    public class PizzaContract
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public IList<CompositionContract> Compositions { get; set; } = new List<CompositionContract>();
        public string FormattedPrice { get; set; }
    }
}

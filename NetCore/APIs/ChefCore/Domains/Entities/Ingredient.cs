namespace ChefCore.Domains.Entities
{
    public class Ingredient
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public UnityMeasurement Measurement { get; set; }
    }
}

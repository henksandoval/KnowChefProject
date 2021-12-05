namespace ChefCore.Domains.Entities
{
    public class Recipe
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TimePreparation TimePreparation { get; set; } = new TimePreparation();
        public Difficulty Difficulty { get; set; }
        public IEnumerable<Ubication> OrigenRecipe { get; set; } = Enumerable.Empty<Ubication>();
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
        public IEnumerable<Ingredient> Ingredients { get; set; } = Enumerable.Empty<Ingredient>();
        public IEnumerable<Step> Steps { get; set; } = Enumerable.Empty<Step>();
        public string Advice { get; set; } = string.Empty;
    }
}

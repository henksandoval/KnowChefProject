namespace Chef.Core.Domains.Models
{
	using Chef.Shared.Utilities.Extensions;

	public class Recipe
	{
		public string? Name { get; private set; }
		public string? Description { get; private set; }
		public TimePreparation? TimePreparation { get; private set; }
		public Difficulty Difficulty { get; private set; }
		public IEnumerable<Ubication> OrigenRecipe { get; private set; } = Enumerable.Empty<Ubication>();
		public IEnumerable<Category> Categories { get; private set; } = Enumerable.Empty<Category>();
		public IEnumerable<Product> Ingredients { get; private set; } = Enumerable.Empty<Product>();
		public IEnumerable<Step> Steps { get; private set; } = Enumerable.Empty<Step>(); 
		public string? Advice { get; private set; }

		public Recipe(string name, string description)
		{
			Name = name.ThrowIfNullOrWhiteSpace(nameof(Name));
			Description = description.ThrowIfNullOrWhiteSpace(nameof(Description));
		}
	}
}

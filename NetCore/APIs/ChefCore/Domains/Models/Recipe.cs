namespace Chef.Core.Domains.Models
{
	using Chef.Core.Domains.Exceptions;
	using Chef.Shared.Utilities.Extensions;

	public class Recipe
	{
		private string? name;


		public string? Description { get; private set; }
		public Time? TimePreparation { get; private set; }
		public Difficulty Difficulty { get; private set; }
		public IEnumerable<Ubication> OrigenRecipe { get; private set; } = Enumerable.Empty<Ubication>();
		public IEnumerable<Category> Categories { get; private set; } = Enumerable.Empty<Category>();
		public IEnumerable<Product> Ingredients { get; private set; } = Enumerable.Empty<Product>();
		public IEnumerable<Step> Steps { get; private set; } = Enumerable.Empty<Step>();
		public string? Advice { get; private set; }

		public Recipe(string name, string description)
		{
			Name = name;
			Description = description.ThrowIfNullOrWhiteSpace(nameof(Description));
		}

		public string? Name
		{
			get => name;
			private set
			{
				try
				{
					name = value.ThrowIfNullOrWhiteSpace(nameof(Name));
				}
				catch (Exception ex)
				{
					throw new DomainRecipeException("The value by recipe name is empty or if only white spaces.", ex);
				}
			}
		}
	}
}

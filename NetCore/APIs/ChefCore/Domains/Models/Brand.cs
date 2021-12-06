namespace Chef.Core.Domains.Models
{
	using Chef.Shared.Utilities.Extensions;

	public class Brand
	{
		public string? Name { get; private set; }
		public string? Description { get; private set; }
		public string? Tenant { get; set; }

		public Brand(string? name, string? description)
		{
			Name = name;
			Description = description;
		}

		public Brand Update(string? name, string? description)
		{
			return this;
		}
	}
}

namespace Chef.Core.Domains.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class Product
	{
		public string? Name { get; private set; }
		public string? Description { get; private set; }
		public decimal Rate { get; private set; }
		public string? Tenant { get; set; }
		public string? ImagePath { get; set; }
		public Guid BrandId { get; set; }
		public virtual Brand Brand { get; set; } = default!;

		public Product(string? name, string? description, decimal rate, in Guid brandId, string? imagePath)
		{
			Name = name;
			Description = description;
			Rate = rate;
			ImagePath = imagePath;
			BrandId = brandId;
		}

		public Product Update(string? name, string? description, decimal rate, in Guid brandId, string? imagePath)
		{
			return this;
		}
	}
}

namespace Chef.Infrastructure.Configurations.Swagger
{
	using Microsoft.OpenApi.Models;

	public class NonBodyParameter : OpenApiParameter
	{
		public object? Default { get; set; }
	}
}

namespace Chef.Api.Swagger
{
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.OpenApi.Models;
	using Swashbuckle.AspNetCore.SwaggerGen;

	public class SwaggerDefaultValues : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			ApiDescription apiDescription = context.ApiDescription;

			operation.Deprecated = apiDescription.IsDeprecated();

			if (operation.Parameters is null)
			{
				return;
			}

			foreach (NonBodyParameter parameter in operation.Parameters.OfType<NonBodyParameter>())
			{
				ApiParameterDescription description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

				if (parameter.Description is null)
				{
					parameter.Description = description.ModelMetadata?.Description;
				}

				if (parameter.Default is null)
				{
					parameter.Default = description.DefaultValue;
				}

				parameter.Required |= description.IsRequired;
			}
		}
	}
}

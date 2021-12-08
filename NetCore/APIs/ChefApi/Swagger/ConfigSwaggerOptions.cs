namespace Chef.Api.Swagger
{
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.Options;
	using Microsoft.OpenApi.Models;
	using Swashbuckle.AspNetCore.SwaggerGen;

	public class ConfigSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider provider;

		public ConfigSwaggerOptions(IApiVersionDescriptionProvider provider)
		{
			this.provider = provider;
		}

		public void Configure(SwaggerGenOptions options)
		{
			foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
			}
		}

		private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
		{
			OpenApiInfo info = new OpenApiInfo()
			{
				Title = "Business API",
				Version = description.ApiVersion.ToString(),
				Description = "API Business documentation generated with Swagger, Swashbuckle, and API versioning.",
				Contact = new OpenApiContact() { Name = "Grupo Kaizen", Email = "grupokaizen@grupokaizen.com" },
				TermsOfService = new Uri("https://your-terms-of-service.com/tos"),
				License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
			};

			if (description.IsDeprecated)
			{
				info.Description += " This API version has been deprecated.";
			}

			return info;
		}
	}
}

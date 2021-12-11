namespace Chef.Infrastructure.Configurations.Swagger
{
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;
	using Microsoft.OpenApi.Models;
	using Shared.Utilities.Extensions;
	using Swashbuckle.AspNetCore.SwaggerGen;
	using OpenApiConf = OpenApiInfo;
	using OpenApiInf = Microsoft.OpenApi.Models.OpenApiInfo;

	public class ConfigSwaggerInfo : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider provider;
		private readonly OpenApiConf configOpenApi;

		public ConfigSwaggerInfo(IApiVersionDescriptionProvider provider, IOptions<OpenApiConf> options)
		{
			this.provider = provider;
			configOpenApi = options.Value;
		}

		public void Configure(SwaggerGenOptions options)
		{
			var info = CreateInfoForApiVersion();

			foreach (var description in provider.ApiVersionDescriptions)
			{
				info.Version = description.ApiVersion.ToString();
				if (description.IsDeprecated)
					info.Description += $" {configOpenApi?.DescriptionDeprecated ?? string.Empty}";
				
				options.SwaggerDoc(description.GroupName, info);
				info.Description = info.Description.ThrowIfNullOrWhiteSpace(nameof(OpenApiInf.Description));
			}
		}

		private OpenApiInf CreateInfoForApiVersion() => new OpenApiInf
		{
			Title = configOpenApi.Title.ThrowIfNullOrWhiteSpace(nameof(OpenApiInf.Title)),
			Description = configOpenApi.Description.ThrowIfNullOrWhiteSpace(nameof(OpenApiInf.Description)),
			Contact = new OpenApiContact
			{
				Name = configOpenApi.ContactName.ThrowIfNullOrWhiteSpace(nameof(OpenApiContact.Name)),
				Email = configOpenApi.ContactEmail.ThrowIfNullOrWhiteSpace(nameof(OpenApiContact.Email)),
				Url = new Uri(configOpenApi.ContactUrl.ThrowIfNullOrWhiteSpace(nameof(OpenApiContact.Url)))
			},
			TermsOfService = new Uri(configOpenApi.TermsOfService.ThrowIfNullOrWhiteSpace(nameof(OpenApiInf.TermsOfService))),
			License = new OpenApiLicense
			{
				Name = configOpenApi.LicenseName.ThrowIfNullOrWhiteSpace(nameof(OpenApiLicense.Name)),
				Url = new Uri(configOpenApi.LicenseUrl.ThrowIfNullOrWhiteSpace(nameof(OpenApiLicense.Url)))
			}
		};
	}
}

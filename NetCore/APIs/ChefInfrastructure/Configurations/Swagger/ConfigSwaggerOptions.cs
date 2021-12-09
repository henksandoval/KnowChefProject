namespace Chef.Infrastructure.Configurations.Swagger
{
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;
	using Microsoft.OpenApi.Models;
	using Shared.Utilities.Extensions;
	using Swashbuckle.AspNetCore.SwaggerGen;

	public class ConfigSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider provider;
		private readonly OpenApiModel openApiInfo;

		public ConfigSwaggerOptions(IApiVersionDescriptionProvider provider, IOptions<OpenApiModel> options)
		{
			this.provider = provider;
			openApiInfo = options.Value;
		}

		public void Configure(SwaggerGenOptions options)
		{
			var info = CreateInfoForApiVersion();

			foreach (var description in provider.ApiVersionDescriptions)
			{
				info.Version = description.ApiVersion.ToString();
				info.Description += $" {openApiInfo?.DescriptionDeprecated ?? string.Empty}";
				options.SwaggerDoc(description.GroupName, info);
			}
		}

		private OpenApiInfo CreateInfoForApiVersion() => new OpenApiInfo
		{
			Title = openApiInfo.Title.ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.Title)),
			Version = openApiInfo.Version.ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.Version)),
			Description = openApiInfo.Description.ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.Description)),
			Contact = new OpenApiContact
			{
				Name = openApiInfo.Contact?.Name.ThrowIfNullOrWhiteSpace(nameof(OpenApiContact.Name)),
				Email = openApiInfo.Contact?.Email.ThrowIfNullOrWhiteSpace(nameof(OpenApiContact.Email))
			},
			TermsOfService = new Uri(openApiInfo.TermsOfService.ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.TermsOfService))),
			License = new OpenApiLicense
			{
				Name = openApiInfo.License?.Name.ThrowIfNullOrWhiteSpace(nameof(OpenApiLicense.Name)),
				Url = new Uri(openApiInfo?.License?.Url.ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.TermsOfService)) ?? "".ThrowIfNullOrWhiteSpace(nameof(OpenApiInfo.TermsOfService)))
			}
		};
	}
}

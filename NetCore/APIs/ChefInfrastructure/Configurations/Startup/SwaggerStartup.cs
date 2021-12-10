namespace Chef.Infrastructure.Configurations.Startup
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;
	using Swagger;
	using Swashbuckle.AspNetCore.SwaggerGen;
	using Swashbuckle.AspNetCore.SwaggerUI;

	public static class SwaggerStartup
	{
		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			_ = services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = true;
			})
			.AddVersionedApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			})
			.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigSwaggerInfo>()
			.AddSwaggerGen(options =>
			{
				var baseDirectory = new DirectoryInfo(AppContext.BaseDirectory);
				foreach (var file in baseDirectory.EnumerateFiles("*.xml"))
				{
					options.IncludeXmlComments(file.FullName);
				}
			});

			return services;
		}

		public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
		{
			var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

			_ = SwaggerBuilderExtensions
				.UseSwagger(app)
				.UseSwaggerUI(options =>
				{
					options.DefaultModelsExpandDepth(1);
					provider?.ApiVersionDescriptions.ToList().ForEach(description =>
					{
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
					});
					options.RoutePrefix = "swagger";
					options.DisplayRequestDuration();
					options.DocExpansion(DocExpansion.List);
				});

			return app;
		}
	}
}

namespace Chef.Infrastructure.Configurations.Startup
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;
	using Swagger;
	using Swashbuckle.AspNetCore.SwaggerGen;

	public static class SwaggerStartup
	{
		public static IServiceCollection ConfigSwagger(this IServiceCollection services)
		{
			_ = services.AddSwaggerGen();
			_ = services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = true;
			})
			.AddVersionedApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			_ = services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigSwaggerOptions>();

			_ = services.AddSwaggerGen(options =>
			   {
				   options.OperationFilter<SwaggerDefaultValues>();
				   var baseDirectory = new DirectoryInfo(AppContext.BaseDirectory);
				   foreach (var file in baseDirectory.EnumerateFiles("*.xml"))
				   {
					   options.IncludeXmlComments(file.FullName);
				   }
			   });

			return services;
		}

		public static IApplicationBuilder ConfigSwagger(this IApplicationBuilder app)
		{
			var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

			_ = app
				.UseSwagger()
				.UseSwaggerUI(options =>
				{
					provider?.ApiVersionDescriptions.ToList().ForEach(description =>
					{
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
					});
				});

			return app;
		}
	}
}

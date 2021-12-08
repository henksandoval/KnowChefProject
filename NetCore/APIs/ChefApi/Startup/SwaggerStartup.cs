namespace Chef.Api.Startup
{
	using Chef.Api.Swagger;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.Options;
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
				   DirectoryInfo baseDirectory = new DirectoryInfo(AppContext.BaseDirectory);
				   foreach (FileInfo file in baseDirectory.EnumerateFiles("*.xml"))
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
					foreach (var description in provider?.ApiVersionDescriptions)
					{
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
					}
				});

			return app;
		}
	}
}

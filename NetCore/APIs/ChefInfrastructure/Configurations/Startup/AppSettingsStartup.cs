namespace Chef.Infrastructure.Configurations.Startup
{
	using Chef.Infrastructure.Configurations.Swagger;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	public static class AppSettingsStartup
	{
		public static IServiceCollection LoadAppSettingsConfigurations(this IServiceCollection services, IConfiguration configuration)
		{
			_ = services.Configure<OpenApiModel>(config => configuration.GetSection("OpenApiInfo").Bind(config));

			return services;
		}
	}
}

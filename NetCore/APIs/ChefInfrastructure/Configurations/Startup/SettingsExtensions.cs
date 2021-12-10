namespace Chef.Infrastructure.Configurations
{
	using Microsoft.Extensions.Options;
	using Microsoft.Extensions.DependencyInjection;
	using Swagger;
	using Microsoft.Extensions.Configuration;

	public static class SettingStartup
	{
		internal static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration config)
		{
			_ = services
				.Configure<OpenApiInfo>(config.GetSection(nameof(OpenApiInfo)));

			return services;
		}
	}
}

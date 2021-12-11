namespace Chef.Infrastructure.Configurations.Extensions
{
	using Microsoft.Extensions.Options;
	using Microsoft.Extensions.DependencyInjection;
	using Swagger;
	using Microsoft.Extensions.Configuration;

	public static class SettingExtensions
	{
		internal static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration config)
		{
			_ = services
				.Configure<OpenApiInfo>(config.GetSection(nameof(OpenApiInfo)));

			return services;
		}
	}
}

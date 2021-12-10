namespace Chef.Infrastructure
{
	using Chef.Infrastructure.Configurations;
	using Chef.Infrastructure.Configurations.Startup;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	public static class Program
	{
		public static IServiceCollection ServiceCollectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
		{
			_ = services
				.AddSettings(configuration)
				.ConfigCulture()
				.AddSwagger();

			return services;
		}

		public static IApplicationBuilder ApplicationBuilderInfraestructure(this IApplicationBuilder app)
		{
			_ = app
				.UseSwagger();

			return app;
		}
	}
}

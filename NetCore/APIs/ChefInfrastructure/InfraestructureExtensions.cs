namespace Chef.Infrastructure
{
	using Configurations.Middlewares;
	using Configurations.Extensions;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	public static class InfraestructureExtensions
	{
		public static IServiceCollection ServiceCollectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
		{
			_ = services
				.AddSettings(configuration)
				.AddCulture()
				.AddSwagger();

			return services;
		}

		public static IApplicationBuilder ApplicationBuilderInfraestructure(this IApplicationBuilder app)
		{
			_ = app
				.UseMiddleware<ExceptionMiddleware>()
				.UseSwagger();

			return app;
		}
	}
}

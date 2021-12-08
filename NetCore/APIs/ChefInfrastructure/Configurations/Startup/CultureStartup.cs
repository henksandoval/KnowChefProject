namespace Chef.Infrastructure.Configurations.Startup
{
	using System.Globalization;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Localization;
	using Microsoft.AspNetCore.Routing;
	using Microsoft.Extensions.DependencyInjection;
	using Culture;

	public static class CultureStartup
	{
		public static IServiceCollection ConfigCulture(this IServiceCollection services)
		{
			_ = services
				.AddLocalization()
				.Configure<RequestLocalizationOptions>(options =>
				{
					CultureInfo[] supportedCultures = new[]
					{
						new CultureInfo("es"),
						new CultureInfo("en")
					};

					options.DefaultRequestCulture = new RequestCulture(culture: "es", uiCulture: "es");
					options.SupportedCultures = supportedCultures;
					options.SupportedUICultures = supportedCultures;
					options.RequestCultureProviders = new List<IRequestCultureProvider>
					{
						new RouteDataRequestCultureProvider()
					};
				})
				.Configure<RouteOptions>(options =>
				{
					options.ConstraintMap.Add("culture", typeof(RouteConstraint));
				});

			return services;
		}
	}
}

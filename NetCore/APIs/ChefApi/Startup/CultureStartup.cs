namespace Chef.Api.Startup
{
	using System.Globalization;
	using Chef.Api.Culture;
	using Microsoft.AspNetCore.Localization;

	public static class CultureStartup
	{
		public static IServiceCollection ConfigureCulture(this IServiceCollection services)
		{
			services
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

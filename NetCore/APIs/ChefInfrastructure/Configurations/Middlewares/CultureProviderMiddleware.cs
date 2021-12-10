namespace Chef.Infrastructure.Configurations.Middlewares
{
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Localization;

	public class CultureProviderMiddleware : RequestCultureProvider
	{
		private readonly int indexOfCulture = 1;

		public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			var culture = httpContext?.Request?.Path.Value?.Split('/')[indexOfCulture]?.ToString();

			var providerResultCulture = new ProviderCultureResult(culture);

			return Task.FromResult<ProviderCultureResult?>(providerResultCulture);
		}
	}
}

namespace Chef.Api.Culture
{
	using Microsoft.AspNetCore.Localization;

	public class RouteDataRequestCultureProvider : RequestCultureProvider
	{
		private readonly int indexOfCulture = 1;

		public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			var culture = httpContext?.Request?.Path.Value?.Split('/')[indexOfCulture]?.ToString();

			ProviderCultureResult providerResultCulture = new(culture);

			return Task.FromResult(providerResultCulture);
		}
	}
}

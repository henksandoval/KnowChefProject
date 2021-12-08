namespace Chef.Api.Controllers.V01
{
	using Chef.Shared.Resources;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiVersion("0.1")]
	[Route("{culture:culture}/api/v{version:apiVersion}/[controller]")]
	public class WeatherForecastController : BaseController<WeatherForecastController>
	{
		private readonly IStringLocalizer<SharedResource> localizer;

		public WeatherForecastController(IStringLocalizer<SharedResource> localizer, ILogger<WeatherForecastController> logger)
			:base(logger)
		{
			this.localizer = localizer;
		}

		/// <summary>
		/// Gets a list of weather
		/// </summary>
		/// <param name="temperature">The requested business partner identifier.</param>
		/// <returns>The requested business partner.</returns>
		/// <response code="200">The business partner was successfully retrieved.</response>
		/// <response code="404">The business partner does not exist.</response>
		[HttpGet]
		public IEnumerable<WeatherForecast> Get(int? temperature)
		{
			var r = localizer["RecipeNameInvalid"];

			return new List<WeatherForecast>
			{
				new WeatherForecast
				{
					TemperatureC = temperature ?? 0,
					Summary = r
				}
			};
		}
	}
}
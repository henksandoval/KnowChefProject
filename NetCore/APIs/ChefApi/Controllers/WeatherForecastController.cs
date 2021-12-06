namespace Chef.Api.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiController]
	[Route("{culture:culture}/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IStringLocalizer<SharedResource> localizer;
		private readonly ILogger<WeatherForecastController> logger;

		public WeatherForecastController(IStringLocalizer<SharedResource> localizer, ILogger<WeatherForecastController> logger)
		{
			this.localizer = localizer;
			this.logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			var r = localizer["RecipeNameInvalid"];

			return new List<WeatherForecast>
			{
				new WeatherForecast
				{
					Summary = r
				}
			};
		}
	}
}
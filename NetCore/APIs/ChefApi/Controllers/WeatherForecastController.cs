namespace Chef.Api.Controllers
{
	using Chef.Core.Domains.Models;
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
			//Recipe recipe;
			//if (error)
			//	recipe = new Recipe(string.Empty, "Einz'ges ich");
			//else
			//	recipe = new Recipe("Soasas", "Einz'ges ich");

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
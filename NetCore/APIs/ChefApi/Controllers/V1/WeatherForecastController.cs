namespace Chef.Api.Controllers.V1
{
	using Chef.Shared.Resources;
	using Microsoft.AspNetCore.Mvc;

	[ApiVersion("1")]
	public class WeatherForecastController : BaseController<WeatherForecastController>
	{
		public WeatherForecastController(ILogger<WeatherForecastController> logger)
			: base(logger)
		{
		}

		/// <summary>
		/// Gets a list of weather
		/// </summary>
		/// <param name="temperature">The requested business partner identifier.</param>
		/// <returns>The requested business partner.</returns>
		/// <response code="200">The business partner was successfully retrieved.</response>
		/// <response code="404">The business partner does not exist.</response>
		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get(int? temperature)
		{
			var r = SharedResource.ConfirmationNewPassword;

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
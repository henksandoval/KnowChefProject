namespace Chef.Api.Controllers.V01
{
	using Chef.Core.Resources.Exceptions;
	using Chef.Shared.Resources;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiVersion("0.1")]
	public class WeatherForecastController : BaseController<WeatherForecastController>
	{
		private readonly IStringLocalizer<DomainResourceException> localizer;

		public WeatherForecastController(IStringLocalizer<DomainResourceException> localizer, ILogger<WeatherForecastController> logger)
			:base(logger)
		{
			this.localizer = localizer;
		}

		/// <summary>
		/// Gets a list of weather using DomainResourceExceptions from Core Layer
		/// </summary>
		/// <param name="temperature">Value of temperature.</param>
		/// <returns>The requested business partner.</returns>
		/// <response code="200">The data was successfully retrieved.</response>
		/// <response code="404">A error an occurred.</response>
		[HttpGet]
		[Route("UseDomainResourceException")]
		public IActionResult UseDomainResourceException(int? temperature)
		{
			var r = localizer["RecipeNameInvalid"];

			var data = Enumerable.Range(0, 15).Select(i => 
				new WeatherForecast
				{
					TemperatureC = temperature ?? 0,
					Summary = r
				}
			);

			return Ok(data);
		}

		/// <summary>
		/// Gets a list of weather using UseSharedResourceException from Shared Layer
		/// </summary>
		/// <param name="temperature">Value of temperature.</param>
		/// <returns>The requested business partner.</returns>
		/// <response code="200">The data was successfully retrieved.</response>
		/// <response code="404">A error an occurred.</response>
		[HttpGet]
		[Route("UseSharedResourceException")]
		public IActionResult UseSharedResourceException(int? temperature)
		{
			var r = SharedResource.Welcome;

			var data = Enumerable.Range(0, 15).Select(i => 
				new WeatherForecast
				{
					TemperatureC = temperature ?? 0,
					Summary = r
				}
			);

			return Ok(data);
		}
	}
}
namespace Chef.Api.Controllers.V01
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[ApiVersion("0.1")]
	[Route("{culture:culture}/api/v{version:apiVersion}/[controller]")]
	public class ValuesController : BaseController<ValuesController>
	{
		public ValuesController(ILogger<ValuesController> logger) : base(logger)
		{
		}

		/// <summary>
		/// Return a list of int from 0 to 15
		/// </summary>
		/// <returns>Return a list of int from 0 to 15</returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(Enumerable.Range(0, 15).Select(i => $"Project_{i}_V1"));
		}
	}
}

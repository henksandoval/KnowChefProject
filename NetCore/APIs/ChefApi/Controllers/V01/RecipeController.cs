namespace Chef.Api.Controllers.V01
{
	using Chef.Core.Domains.Models;
	using Chef.Core.Resources.Exceptions;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiVersion("0.1")]
	[Route("{culture:culture}/api/v{version:apiVersion}/[controller]")]
	public class RecipeController : BaseController<RecipeController>
	{
		private readonly IStringLocalizer<DomainResourceException> localizer;
		private readonly ILogger<RecipeController> logger;

		public RecipeController(IStringLocalizer<DomainResourceException> localizer, ILogger<RecipeController> logger)
			: base(logger)
		{
			this.localizer = localizer;
			this.logger = logger;
		}

		/// <summary>
		/// Gets a list of weather
		/// </summary>
		/// <returns>The requested business partner.</returns>
		/// <response code="200">The business partner was successfully retrieved.</response>
		/// <response code="404">The business partner does not exist.</response>
		[HttpGet]
		public IEnumerable<Recipe> Get()
		{
			var r = localizer["RecipeNameInvalid"];
			Recipe recipe = new (string.Empty, r);

			return new List<Recipe>
			{
				recipe
			};
		}
	}
}
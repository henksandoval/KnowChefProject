namespace Chef.Api.Controllers.V1
{
	using Chef.Core.Domains.Models;
	using Chef.Core.Resources.Exceptions;
	using Chef.Shared.Enums;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiVersion(ApiVersions.V1_0)]
	public class RecipeController : BaseController<RecipeController>
	{
		private readonly IStringLocalizer<DomainResourceException> localizer;

		public RecipeController(IStringLocalizer<DomainResourceException> localizer, ILogger<RecipeController> logger)
			: base(logger)
		{
			this.localizer = localizer;
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
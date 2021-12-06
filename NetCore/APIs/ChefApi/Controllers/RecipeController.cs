namespace Chef.Api.Controllers
{
	using Chef.Core.Domains.Models;
	using Chef.Core.Resources.Exceptions;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Localization;

	[ApiController]
	[Route("{culture:culture}/[controller]")]
	public class RecipeController : ControllerBase
	{
		private readonly IStringLocalizer<DomainResourceException> localizer;
		private readonly ILogger<RecipeController> logger;

		public RecipeController(IStringLocalizer<DomainResourceException> localizer, ILogger<RecipeController> logger)
		{
			this.localizer = localizer;
			this.logger = logger;
		}

		[HttpGet(Name = "GetRecipe")]
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
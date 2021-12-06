namespace Chef.Core.Test.Domains.Models
{
	using System;
	using Chef.Core.Domains.Models;
	using Chef.Core.Domains.Exceptions;
	using NUnit.Framework;

	[TestFixture]
	internal class RecipeTest
	{
		[TestCase("Porgere", "Con di di suo sí come potra divina dico cose")]
		public void ShouldHaveNameAndDescription(string name, string description)
		{
			var recipe = new Recipe(name, description);
			Assert.AreEqual(name, recipe.Name);
			Assert.AreEqual(description, recipe.Description);
		}

		[TestCase("", "", "The value by recipe name is empty or if only white spaces.", TestName = "ShouldThrowExceptionIfNameIsEmpty")]
		[TestCase("Cose segreto piene", "", "The property Description is empty or if only white spaces.", TestName = "ShouldThrowExceptionIfDescriptionIsEmpty")]
		public void ShouldThrowExceptionIfNameIsEmpty(string name, string description, string expectedErrorMessage)
		{
			var ex = Assert.Throws<DomainRecipeException>(() => new Recipe(name, description));

			Assert.AreEqual(expectedErrorMessage, ex?.Message);
		}

	}
}

namespace Chef.Core.Test.Domains.Models
{
	using System;
	using Chef.Core.Domains.Models;
	using Chef.Core.Domains.Exceptions;
	using NUnit.Framework;
	using Microsoft.AspNetCore.Localization;
	using System.Threading;
	using System.Globalization;

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

		[TestCase("", "", ExpectedResult = "The value by recipe name is empty or if only white spaces.", TestName = "ShouldThrowExceptionIfNameIsEmpty")]
		[TestCase("Cose segreto piene", "", ExpectedResult = "The value by recipe description is empty or if only white spaces.", TestName = "ShouldThrowExceptionIfDescriptionIsEmpty")]
		public string ShouldThrowExceptionIfIsEmpty(string name, string description)
		{
			var ex = Assert.Throws<DomainException>(() => new Recipe(name, description));

			return ex?.Message ?? string.Empty;
		}

		[Test]
		[SetUICulture("es")]
		public void ShouldThrowExceptionIfDescriptionIsEmptyInSpanish()
		{
			var expectedResult = "El valor para descripción de receta esta vacio o contiene solo espacios en blanco.";

			var ex = Assert.Throws<DomainException>(() => new Recipe("Consume los", string.Empty));

			Assert.AreEqual(expectedResult, ex?.Message);
		}
	}
}

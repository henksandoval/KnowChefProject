namespace Chef.Core.Test.Domains.Models
{
	using System;
	using Chef.Core.Domains.Models;
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

		[Test]
		public void ShouldThrowExceptionIfNameIsEmpty()
		{
			var ex = Assert.Throws<ArgumentException>(() => new Recipe(string.Empty, string.Empty));

			Assert.AreEqual($"The property Name is empty or if only white spaces.", ex?.Message);
		}

		[Test]
		public void ShouldThrowExceptionIfDescriptionIsEmpty()
		{
			var ex = Assert.Throws<ArgumentException>(() => new Recipe("Una", string.Empty));

			Assert.AreEqual($"The property Description is empty or if only white spaces.", ex?.Message);
		}
	}
}

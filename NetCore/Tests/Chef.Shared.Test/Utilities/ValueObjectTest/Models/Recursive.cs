namespace Chef.Shared.Test.Utilities.ValueObjectTest.Models
{
	using Chef.Shared.Utilities.Value;

	internal class Recursive : ValueObject
	{
		public Recursive Recurse { get; set; }
		public string Terminal;
	}
}

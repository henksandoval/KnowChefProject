namespace Chef.Shared.Test.Utilities.ValueObjectTest.Models
{
	using Chef.Shared.Utilities.Value;

	internal class Ignore : ValueObject
	{
		[IgnoreMember]
		public int Ignored { get; set; }
		[IgnoreMember]
		public int IgnoredField;
		public int Considered { get; set; }
	}
}

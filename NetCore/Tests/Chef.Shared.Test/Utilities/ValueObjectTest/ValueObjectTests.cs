#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
namespace Chef.Shared.Test.Utilities.ValueObjectTest
{
	using System;
	using Chef.Shared.Utilities.Value;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Models;

	[TestClass]
	public partial class ValueObjectTests
	{
		[TestMethod]
		public void Equals_NullIsConsideredEqual()
		{
			var value1 = new ValueObjectModel();
			var value2 = new ValueObjectModel();

			AssertEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_OnlyOneValueIsNull_DoesNotThrow_NotEqual()
		{
			var value1 = new ValueObjectModel();
			var value2 = new ValueObjectModel { Property1 = "value" };

			AssertNotEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_ComparesAllPropertiesAndFields_Equal()
		{
			var value1 = new ValueObjectModel { Property1 = "test", Property2 = 10, Field = 3 };
			var value2 = new ValueObjectModel { Property1 = "test", Property2 = 10, Field = 3 };

			AssertEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_ComparesAllPropertiesAndFields_PropertyDifferent_NotEqual()
		{
			var value1 = new ValueObjectModel { Property1 = "test", Property2 = 10 };
			var value2 = new ValueObjectModel { Property1 = "Test", Property2 = 10 };

			AssertNotEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_ComparesAllPropertiesAndFields_FieldDifferent_NotEqual()
		{
			var value1 = new ValueObjectModel { Property1 = "test", Property2 = 10, Field = 8 };
			var value2 = new ValueObjectModel { Property1 = "test", Property2 = 10, Field = 9 };

			AssertNotEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_IgnoresPrivatePropertiesAndFields()
		{
			var value1 = new ValueObjectModel(5);
			var value2 = new ValueObjectModel(8);

			AssertEqual(value1, value2);
		}

		[TestMethod]
		public void Equals_ComparingWithNull_ReturnsFalse()
		{
			var value = new ValueObjectModel { Property1 = "string" };

			Assert.IsFalse(value.Equals(null as object));
		}

		[TestMethod]
		public void Equals_ComparingWithWrongType_ReturnsFalse()
		{
			var value = new ValueObjectModel { Property1 = "string" };

			Assert.IsFalse(value.Equals(10));
		}

		[TestMethod]
		public void OperatorEquals_LeftSideNull_ReturnsFalse()
		{
			var value = new ValueObjectModel();

			Assert.IsFalse(null == value);
		}

		[TestMethod]
		public void OperatorEquals_RightSideNull_ReturnsFalse()
		{
			var value = new ValueObjectModel();

			Assert.IsFalse(value == null);
		}

		[TestMethod]
		public void OperatorEquals_BothValuesNull_ReturnsTrue()
		{

			Assert.IsTrue((ValueObjectModel)null == (ValueObjectModel)null);
		}

		[TestMethod]
		public void OperatorNotEquals_LeftSideNull_ReturnsTrue()
		{
			var value = new ValueObjectModel();

			Assert.IsTrue(null != value);
		}

		[TestMethod]
		public void OperatorNotEquals_RightSideNull_ReturnsTrue()
		{
			var value = new ValueObjectModel();

			Assert.IsTrue(value != null);
		}

		[TestMethod]
		public void OperatorNotEquals_BothValuesNull_ReturnsFalse()
		{
			Assert.IsFalse((ValueObjectModel)null != (ValueObjectModel)null);
		}

		[TestMethod]
		public void ImplementsIEquatable()
		{
			var value = new ValueObjectModel();

			Assert.IsInstanceOfType(value, typeof(IEquatable<ValueObject>));
		}

		[TestMethod]
		public void GetHashCode_AlwaysEqualForEqualObjects()
		{
			var value1 = new ValueObjectModel { Property1 = "string", Property2 = 4 };
			var value2 = new ValueObjectModel { Property1 = "string", Property2 = 4 };

			Assert.AreEqual(value1.GetHashCode(), value2.GetHashCode());
		}

		[TestMethod]
		public void GetHashCode_NotEqualForDistinctObjects_1()
		{
			var value1 = new ValueObjectModel { Property1 = "string", Property2 = 4 };
			var value2 = new ValueObjectModel { Property1 = "string", Property2 = 5 };

			Assert.AreNotEqual(value1.GetHashCode(), value2.GetHashCode());
		}

		[TestMethod]
		public void GetHashCode_NotEqualForDistinctObjects_2()
		{
			var value1 = new ValueObjectModel { Property1 = "string", Property2 = 4 };
			var value2 = new ValueObjectModel { Property1 = "String", Property2 = 4 };

			Assert.AreNotEqual(value1.GetHashCode(), value2.GetHashCode());
		}

		[TestMethod]
		public void GetHashCode_HandlesNull()
		{
			var value1 = new ValueObjectModel { Property2 = 2 };
			var value2 = new ValueObjectModel { Property2 = 5 };

			Assert.AreNotEqual(value1.GetHashCode(), value2.GetHashCode());
		}

		[TestMethod]
		public void GetHashCode_ConsidersPublicFields()
		{
			var value1 = new ValueObjectModel { Property2 = 2 };
			var value2 = new ValueObjectModel { Property2 = 2, Field = 4 };

			Assert.AreNotEqual(value1.GetHashCode(), value2.GetHashCode());
		}

		private void AssertEqual(ValueObjectModel value1, ValueObjectModel value2)
		{
			Assert.AreEqual(value1, value2);
			Assert.IsTrue(value1 == value2);
			Assert.IsFalse(value1 != value2);
			Assert.IsTrue(value1.Equals(value2));
		}

		private void AssertNotEqual(ValueObjectModel value1, ValueObjectModel value2)
		{
			Assert.AreNotEqual(value1, value2);
			Assert.IsTrue(value1 != value2);
			Assert.IsFalse(value1 == value2);
			Assert.IsFalse(value1.Equals(value2));
		}

		[TestMethod]
		public void Nesting()
		{
			var value = new Recursive();
			var value2 = new Recursive();
			var nestedValue = new Recursive() { Terminal = "test" };
			var nestedValue2 = new Recursive() { Terminal = "test" };

			value.Recurse = nestedValue;
			value2.Recurse = nestedValue2;

			Assert.IsTrue(value.Equals(value2));
			Assert.AreEqual(value.GetHashCode(), value2.GetHashCode());
		}

		[TestMethod]
		public void IgnoreMember_Property_DoesNotConsider()
		{
			var value1 = new Ignore { Ignored = 2, Considered = 4 };
			var value2 = new Ignore { Ignored = 3, Considered = 4 };

			Assert.IsTrue(value1.Equals(value2));
		}

		[TestMethod]
		public void IgnoreMember_Field_DoesNotConsider()
		{
			var value1 = new Ignore { IgnoredField = 3, Considered = 4 };
			var value2 = new Ignore { IgnoredField = 2, Considered = 4 };

			Assert.IsTrue(value1.Equals(value2));
		}

		[TestMethod]
		public void ObjectsOfDifferentTypeAreNotEqual_EvenIfSubclass()
		{
			var value1 = new MyValue();
			var value2 = new MyValue2();

			Assert.IsFalse(value1.Equals(value2));
		}
	}
}
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
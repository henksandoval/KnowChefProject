namespace Chef.Shared.Test.Utilities.ValueObject
{
    using Chef.Shared.Utilities.Value;

    internal class ValueObjectModel : ValueObject
    {
        public ValueObjectModel() { }

        public ValueObjectModel(int nonPublicValue)
        {
            ProtectedProperty = nonPublicValue;
            PrivateProperty = nonPublicValue;
            privateField = nonPublicValue;
            protectedField = nonPublicValue;
        }

        public string Property1 { get; set; }
        public int Property2 { get; set; }
        public int Field;
        protected int protectedField;
        private readonly int privateField;

        protected int ProtectedProperty { get; set; }
        private int PrivateProperty { get; set; }
    }
}
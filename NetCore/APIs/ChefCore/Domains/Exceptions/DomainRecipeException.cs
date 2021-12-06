namespace Chef.Core.Domains.Exceptions
{
	using System;

	[Serializable]
	internal class DomainRecipeException : Exception
	{
		public DomainRecipeException() { }

		public DomainRecipeException(string message)
			: base(message) { }

		public DomainRecipeException(string message, Exception inner)
			: base(message, inner) { }
	}
}

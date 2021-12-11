namespace Chef.Core.Domains.Exceptions
{
	using System;

	[Serializable]
	public class DomainException : Exception
	{
		public string CodeError { get; }

		public DomainException(string codeError) : base(ResourceExceptionHandler.GetDomainExceptionMessage(codeError))
		{
			CodeError = codeError;
		}

		public DomainException(string codeError, Exception inner)
			: base(ResourceExceptionHandler.GetDomainExceptionMessage(codeError), inner)
		{
			CodeError = codeError;
		}
	}
}

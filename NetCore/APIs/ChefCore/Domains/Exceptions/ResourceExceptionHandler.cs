namespace Chef.Core.Domains.Exceptions
{
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	internal static class ResourceExceptionHandler
	{
		private static readonly ResourceManager domainExceptionResource = 
			new ResourceManager("Chef.Core.Resources.Exceptions.DomainResourceException", Assembly.GetExecutingAssembly());

		internal static string GetDomainExceptionMessage(string codeError)
		{
			return domainExceptionResource.GetString(codeError) ?? string.Empty;
		}
	}
}

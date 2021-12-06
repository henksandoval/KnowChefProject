namespace Chef.Core.Domains.Exceptions
{
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	internal static class ResourceExceptionHandler
	{
		private static readonly ResourceManager domainExceptionResource = 
			new ResourceManager("Chef.Core.Resources.Exceptions.DomainResourceException", Assembly.GetExecutingAssembly());

		internal static string GetDomainExceptionMessage(string nameException)
		{
			//ResourceSet rs = domainExceptionResource.GetResourceSet(CultureInfo.CreateSpecificCulture("es"), true, false);
			return domainExceptionResource.GetString(nameException) ?? string.Empty;
		}
	}
}

namespace Chef.Infrastructure.Configurations.Swagger
{
	public class OpenApiModel
	{
		public string? Title { get; set; }
		public string? Version { get; set; }
		public string? Description { get; set; }
		public string? DescriptionDeprecated { get; set; }
		public Contact? Contact { get; set; }
		public string? TermsOfService { get; set; }
		public License? License { get; set; }
	}
	public class Contact
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
	}

	public class Termsofservice
	{
		public string? UriString { get; set; }
	}

	public class License
	{
		public string? Name { get; set; }
		public string? Url { get; set; }
	}
}

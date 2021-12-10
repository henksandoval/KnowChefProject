namespace Chef.Shared.Enums
{
	public class ApiVersions
	{
		public const string V0_1 = "0.1";
		public const string V1_0 = "1";
		public const string V2_0 = "2";
	}

	public class ApiRoutes
	{
		public const string TemplateRoute = "{culture:culture}/api/v{version:apiVersion}/[controller]";
	}

	public class ApiProduces
	{
		public const string ContentType = "application/json";
	}
}

namespace Chef.Api.Extensions
{
	public static class ConfigureHostBuilderExtensions
	{
		public static ConfigureHostBuilder AddJsonSettingsFiles(this ConfigureHostBuilder host)
		{
			_ = host.ConfigureAppConfiguration((context, config) =>
			  {
				  const string configurationsDirectory = "configurations";
				  var env = context.HostingEnvironment;
				  _ = config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
					  .AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
					  .AddJsonFile($"{configurationsDirectory}/logger.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
					  .AddJsonFile($"{configurationsDirectory}/swagger.json", optional: false, reloadOnChange: true)
					  .AddJsonFile($"{configurationsDirectory}/swagger.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
					  .AddEnvironmentVariables();
			  });

			return host;
		}
	}
}

using Chef.Api.Extensions;
using Chef.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddJsonSettingsFiles();

_ = builder.Services
	.ServiceCollectionInfraestructure(builder.Configuration)
	.AddEndpointsApiExplorer()
	.AddControllers();

var app = builder.Build();

_ = app.ApplicationBuilderInfraestructure();

var localizationOption = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOption is not null)
	_ = app.UseRequestLocalization(localizationOption.Value);

_ =	app
	.UseHttpsRedirection()
	.UseAuthorization();

_ = app.MapControllers();

app.Run();

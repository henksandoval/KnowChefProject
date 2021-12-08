using Chef.Infrastructure.Configurations.Startup;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_ = builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_ = builder.Services
	.AddEndpointsApiExplorer()
	.ConfigCulture()
	.ConfigSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	_ = app.ConfigSwagger();
}

var localizationOption = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOption is not null)
	_ = app.UseRequestLocalization(localizationOption.Value);

_ =	app
	.UseHttpsRedirection()
	.UseAuthorization();

_ = app.MapControllers();
app.Run();

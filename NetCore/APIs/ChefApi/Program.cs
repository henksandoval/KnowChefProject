using Chef.Api.Startup;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.ConfigureCulture();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

var localizationOption = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOption is not null)
	app.UseRequestLocalization(localizationOption.Value);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

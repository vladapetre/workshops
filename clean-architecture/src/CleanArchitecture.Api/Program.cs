using CleanArchitecture.Api;
using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Controllers.Converters;
using CleanArchitecture.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.ModelBinderProviders.Insert(0, new TemperatureScaleModelBinderProvider());
    })
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new TemperatureScaleJsonConverter());
        
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IWeatherStatisticsService, WeatherStatisticsService>();
builder.Services.AddScoped<IWeatherSummaryService, WeatherSummaryService>();
builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<ITemperatureConversionService, TemperatureConversionService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

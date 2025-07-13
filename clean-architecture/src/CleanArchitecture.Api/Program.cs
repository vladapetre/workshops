using CleanArchitecture.Api;
using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Controllers.Converters;
using CleanArchitecture.Api.Controllers.ModelBinders;
using CleanArchitecture.Api.Infrastructure;
using CleanArchitecture.Api.Infrastructure.Temperatures;
using CleanArchitecture.Api.Infrastructure.Temperatures.Convertors;

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

builder.Services.AddScoped<ITemperatureConvertor, FahrenheitToCelsiusTemperatureConvertor>();
builder.Services.AddScoped<ITemperatureConvertor, CelsiusToFahrenheitTemperatureConvertor>();


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

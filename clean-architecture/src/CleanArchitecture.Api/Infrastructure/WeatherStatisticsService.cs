using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure;

public sealed class WeatherStatisticsService :IWeatherStatisticsService
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherStatisticsService(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }
    
    public double GetAverageTemperature(DateOnly day, int days, TemperatureScale scale)
    {
        var forecasts = _weatherForecastService.GetWeatherForecast(day, days, scale);
        return CalculateAverageTemperature(forecasts);
    }

    private static double CalculateAverageTemperature(ICollection<WeatherForecast> forecasts)
    {
        return forecasts.Average(forecast => forecast.Temperature.Value);
    }
}
using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api;
public class WeatherForecastService : IWeatherForecastService
{
    private readonly ITemperatureService _temperatureService;
    private readonly IWeatherSummaryService _weatherSummaryService;

    public WeatherForecastService(
        ITemperatureService temperatureService,
        IWeatherSummaryService weatherSummaryService)
    {
        _temperatureService = temperatureService;
        _weatherSummaryService = weatherSummaryService;
    }
    
    public ICollection<WeatherForecast> GetWeatherForecast(DateOnly day, int days)
    {
        return Enumerable.Range(0, days)
            .Select(index => GenerateWeatherForecastForDay(day.AddDays((days))))
            .ToArray();
    }

    private WeatherForecast GenerateWeatherForecastForDay(DateOnly day)
    {
        var temperature = _temperatureService.Generate(TemperatureScale.Celsius);
        var summary = _weatherSummaryService.GenerateSummary(temperature);
        
        return new WeatherForecast(
            day,
            temperature,
            summary
        );
    }

    public double GetAverageTemperature(DateOnly day, int days, TemperatureScale scale)
    {
        var forecasts = GetWeatherForecast(day, days);
        return CalculateAverageTemperature(forecasts);
    }

    private static double CalculateAverageTemperature(ICollection<WeatherForecast> forecasts)
    {
        return forecasts.Average(forecast => forecast.Temperature.Value);
    }
}
using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure;
public class WeatherForecastService : IWeatherForecastService
{
    private readonly ITemperatureService _temperatureService;
    private readonly ITemperatureConversionService _temperatureConversionService;
    private readonly IWeatherSummaryService _weatherSummaryService;

    public WeatherForecastService(
        ITemperatureService temperatureService,
        ITemperatureConversionService  temperatureConversionService,
        IWeatherSummaryService weatherSummaryService)
    {
        _temperatureService = temperatureService;
        _temperatureConversionService = temperatureConversionService;
        _weatherSummaryService = weatherSummaryService;
    }
    
    public ICollection<WeatherForecast> GetWeatherForecast(DateOnly day, int days, TemperatureScale scale)
    {
        return Enumerable.Range(0, days)
            .Select(index => GenerateWeatherForecastForDay(day.AddDays(days),scale))
            .ToArray();
    }

    private WeatherForecast GenerateWeatherForecastForDay(DateOnly day, TemperatureScale scale)
    {
        var randomTemperature = _temperatureService.GenerateRandom();
        var temperature = _temperatureConversionService.Convert(randomTemperature, scale);
        var summary = _weatherSummaryService.GenerateSummary(temperature);
        
        return new WeatherForecast(
            day,
            temperature,
            summary
        );
    }
}
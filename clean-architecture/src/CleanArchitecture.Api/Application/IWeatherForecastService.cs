using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface IWeatherForecastService
{
    public ICollection<WeatherForecast> GetWeatherForecast(DateOnly day, int days, TemperatureScale scale);
}
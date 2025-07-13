using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface IWeatherForecastService
{
    public static ICollection<WeatherForecast> GetWeatherForecast(DateOnly day, int days);
}
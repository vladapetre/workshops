namespace CleanArchitecture.Api;
public static class WeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static ICollection<WeatherForecast> GetWeatherForecast(DateOnly day, int days)
    {
        return Enumerable.Range(0, days)
            .Select(index => new WeatherForecast(
                day.AddDays(index),
                new(Random.Shared.Next(-20, 55)),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();
    }

    public static double GetAverageTemperature(DateOnly day, int days, TemperatureScale scale)
    {
        var forecasts = GetWeatherForecast(day, days);
        return CalculateAverageTemperature(forecasts);
    }

    private static double CalculateAverageTemperature(ICollection<WeatherForecast> forecasts)
    {
        return forecasts.Average(forecast => forecast.Temperature.Value);
    }
}
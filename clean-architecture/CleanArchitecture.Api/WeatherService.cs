namespace CleanArchitecture.Api.Services;

public static class WeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public static ICollection<WeatherForecast> GetForecast(DateOnly day)
    {
        return Enumerable.Range(0, 5).Select(index => new WeatherForecast
            {
                Date = day.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
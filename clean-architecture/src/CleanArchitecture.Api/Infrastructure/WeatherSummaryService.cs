using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure;

public sealed class WeatherSummaryService : IWeatherSummaryService
{
    
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public string GenerateSummary(Temperature temperature) =>
        Summaries[Random.Shared.Next(Summaries.Length)];
}
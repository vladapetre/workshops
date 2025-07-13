using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface IWeatherSummaryService
{
    public string GenerateSummary(Temperature temperature);
}
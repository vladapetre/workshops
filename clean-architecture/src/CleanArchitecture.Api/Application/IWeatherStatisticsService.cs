using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface IWeatherStatisticsService
{
    public double GetAverageTemperature(DateOnly day, int days, TemperatureScale scale);
}
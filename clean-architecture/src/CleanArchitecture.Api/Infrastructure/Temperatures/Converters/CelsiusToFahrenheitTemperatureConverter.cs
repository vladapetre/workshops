using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure.Temperatures.Converters;

public class CelsiusToFahrenheitTemperatureConverter : ITemperatureConverter
{
    public TemperatureScale From => TemperatureScale.Celsius;
    public TemperatureScale To => TemperatureScale.Fahrenheit;

    public Domain.Temperature Convert(Domain.Temperature temperature) =>
        new((temperature.Value - 32) * 0.5556, TemperatureScale.Fahrenheit);
}
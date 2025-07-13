using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure.Temperatures.Converters;

public class FahrenheitToCelsiusTemperatureConverter : ITemperatureConverter
{
    public TemperatureScale From => TemperatureScale.Fahrenheit;
    public TemperatureScale To => TemperatureScale.Celsius;

    public Domain.Temperature Convert(Domain.Temperature temperature) =>
        new(32 + (temperature.Value / 0.5556), TemperatureScale.Celsius);
}
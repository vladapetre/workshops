using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure;

public sealed class TemperatureConversionService : ITemperatureConversionService
{
    public Temperature Convert(Temperature temperature, TemperatureScale scale)
        => (temperature, scale) switch
        {
            _ when scale == TemperatureScale.Fahrenheit => ConvertToFahrenheit(temperature),
            _ when scale == TemperatureScale.Celsius => ConvertToCelsius(temperature),
            _ when scale == TemperatureScale.Unknown => temperature,
            _ => throw new ArgumentOutOfRangeException()
        };

    private Temperature ConvertToCelsius(Temperature temperature)
        => temperature switch
        {
            { Value: var value, Scale: var scale } when scale == TemperatureScale.Unknown => temperature,
            { Value: var value, Scale: var scale } when scale == TemperatureScale.Celsius => temperature,
            { Value: var value, Scale: var scale } when scale == TemperatureScale.Fahrenheit => new ((temperature.Value - 32) * 0.5556,TemperatureScale.Fahrenheit),
            _ => throw new ArgumentOutOfRangeException(nameof(temperature), temperature, null)
        };

    private Temperature ConvertToFahrenheit(Temperature temperature)     
        => temperature switch
    {
        { Value: var value, Scale: var scale } when scale == TemperatureScale.Unknown => temperature,
        { Value: var value, Scale: var scale } when scale == TemperatureScale.Celsius => new (32 + (value / 0.5556),TemperatureScale.Fahrenheit),
        { Value: var value, Scale: var scale } when scale == TemperatureScale.Fahrenheit => temperature,
        _ => throw new ArgumentOutOfRangeException(nameof(temperature), temperature, null)
    };
}
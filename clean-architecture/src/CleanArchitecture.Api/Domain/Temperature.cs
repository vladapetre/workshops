using System.Text.Json.Serialization;

namespace CleanArchitecture.Api;

public record Temperature
{
    public TemperatureScale Scale => TemperatureScale.Celsius;
    public double Value { get; set; }
    public Temperature(double value) => Value = value;
}
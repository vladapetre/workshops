namespace CleanArchitecture.Api.Domain;

public sealed record TemperatureScale(string Name = "Unknown")
{
    public static readonly TemperatureScale Unknown = new("Unknown");
    public static readonly TemperatureScale Celsius = new("Celsius");
    public static readonly TemperatureScale Fahrenheit = new("Fahrenheit");

    public override string ToString() => Name;
}

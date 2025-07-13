namespace CleanArchitecture.Api;

public sealed record TemperatureScale(string Name = "Celsius")
{
    public static readonly TemperatureScale Celsius = new("Celsius");
    public static readonly TemperatureScale Fahrenheit = new("Fahrenheit");

    public override string ToString() => Name;
}

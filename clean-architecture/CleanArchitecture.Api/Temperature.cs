namespace CleanArchitecture.Api;

public record Temperature
{    
    public string Scale => "Celsius";
    public double Value { get; set; }
    
    public Temperature(double value) => Value = value;
}
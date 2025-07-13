using System.Text.Json.Serialization;

namespace CleanArchitecture.Api;

public record Temperature(double Value, TemperatureScale Scale);

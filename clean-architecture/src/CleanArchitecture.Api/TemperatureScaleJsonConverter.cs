using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Api;

public class TemperatureScaleJsonConverter: JsonConverter<TemperatureScale>
{
    public override TemperatureScale? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException("Expected string token for TemperatureScale.");

        string? name = reader.GetString();

        return name switch
        {
            _ when name == TemperatureScale.Celsius.Name => TemperatureScale.Celsius,
            _ when name == TemperatureScale.Fahrenheit.Name => TemperatureScale.Fahrenheit,
            _ => throw new JsonException($"Unknown temperature scale: {name}")
        };
    }

    public override void Write(Utf8JsonWriter writer, TemperatureScale value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }
}
using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure.Temperatures;

public class TemperatureService : ITemperatureService
{
    public Domain.Temperature GenerateRandom() => Random.Shared.Next(1, 3) switch
    {
        1 => new (Random.Shared.Next(-20, 55), TemperatureScale.Celsius),
        2 => new (Random.Shared.Next(-20, 55), TemperatureScale.Fahrenheit),
        _ => new (Random.Shared.Next(-20, 55), TemperatureScale.Unknown),
    };
}
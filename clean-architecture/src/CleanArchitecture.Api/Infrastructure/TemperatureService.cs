using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure;

public class TemperatureGenerator : ITemperatureGenerator
{
    public Temperature Generate(TemperatureScale scale) => new (Random.Shared.Next(-20, 55), scale);
}
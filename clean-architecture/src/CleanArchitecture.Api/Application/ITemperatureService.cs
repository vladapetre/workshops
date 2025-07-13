using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface ITemperatureGenerator
{
    public Temperature Generate(TemperatureScale scale);
}
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface ITemperatureService
{
    public Temperature GenerateRandom();
}
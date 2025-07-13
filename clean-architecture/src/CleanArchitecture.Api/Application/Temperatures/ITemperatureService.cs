using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application.Temperatures;

public interface ITemperatureService
{
    public Temperature GenerateRandom();
}
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application.Temperatures;

public interface ITemperatureConversionService
{
    public Temperature Convert(Temperature temperature, TemperatureScale scale);
}
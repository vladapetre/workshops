using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application;

public interface ITemperatureConversionService
{
    public Temperature Convert(Temperature temperature, TemperatureScale scale);
}
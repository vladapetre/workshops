using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Application.Temperatures;

public interface ITemperatureConverter
{
    public TemperatureScale From { get; }
    public TemperatureScale To { get; }

    public Temperature Convert(Temperature  temperature);
}
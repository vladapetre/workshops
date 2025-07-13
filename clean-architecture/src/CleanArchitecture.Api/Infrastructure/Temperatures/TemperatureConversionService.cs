using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure.Temperatures;

public sealed class TemperatureConversionService : ITemperatureConversionService
{
    private readonly IEnumerable<ITemperatureConverter> _temperatureConverters;

    public TemperatureConversionService(IEnumerable<ITemperatureConverter> temperatureConverters)
    {
        _temperatureConverters = temperatureConverters;
    }

    public Temperature Convert(Temperature temperature, TemperatureScale scale)
    {
        if (temperature.Scale == scale)
        {
            return temperature;
        }
        
        var convertor = _temperatureConverters.FirstOrDefault(c => c.From == temperature.Scale && c.To == scale);
        
        if (convertor is null)
        {
            return temperature;
        }

        return convertor.Convert(temperature);
    }
}
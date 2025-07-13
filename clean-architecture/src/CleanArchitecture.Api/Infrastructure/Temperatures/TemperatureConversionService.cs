using CleanArchitecture.Api.Application.Temperatures;
using CleanArchitecture.Api.Domain;

namespace CleanArchitecture.Api.Infrastructure.Temperatures;

public sealed class TemperatureConversionService : ITemperatureConversionService
{
    private readonly IEnumerable<ITemperatureConvertor> _temperatureConvertors;

    public TemperatureConversionService(IEnumerable<ITemperatureConvertor> temperatureConvertors)
    {
        _temperatureConvertors = temperatureConvertors;
    }

    public Temperature Convert(Temperature temperature, TemperatureScale scale)
    {
        if (temperature.Scale == scale)
        {
            return temperature;
        }
        
        var convertor = _temperatureConvertors.FirstOrDefault(c => c.From == temperature.Scale && c.To == scale);
        
        if (convertor is null)
        {
            return temperature;
        }

        return convertor.Convert(temperature);
    }
}
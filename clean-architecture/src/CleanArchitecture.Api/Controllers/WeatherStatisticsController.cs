using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherStatisticsController : ControllerBase
{
    [HttpGet(Name = "GetWeatherAverage")]
    public double Get([FromQuery] DateTime date, [FromQuery] int days, [FromQuery] TemperatureScale? scale) =>
        WeatherService.GetAverageTemperature(DateOnly.FromDateTime(date), days , scale ?? TemperatureScale.Celsius);
}

using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherStatisticsController : ControllerBase
{
    [HttpGet(Name = "GetWeatherAverage")]
    public double Get(
        [FromQuery] DateTime date,
        [FromQuery] int days,
        [FromQuery] TemperatureScale? scale,
        [FromServices] IWeatherStatisticsService weatherStatisticsService) =>
            weatherStatisticsService.GetAverageTemperature(DateOnly.FromDateTime(date), days , scale ?? TemperatureScale.Celsius);
}

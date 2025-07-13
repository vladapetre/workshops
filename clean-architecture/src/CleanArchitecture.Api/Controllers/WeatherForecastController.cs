using CleanArchitecture.Api.Application;
using CleanArchitecture.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public ICollection<WeatherForecast> Get(
        [FromQuery] DateTime date,
        [FromQuery] int? days,
        [FromQuery] TemperatureScale scale,    
        [FromServices] IWeatherForecastService weatherForecastService) =>
            weatherForecastService.GetWeatherForecast(DateOnly.FromDateTime(date), days ?? 0, scale);
}

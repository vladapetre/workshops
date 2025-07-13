using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public ICollection<WeatherForecast> Get([FromQuery] DateTime date, [FromQuery] int? days) =>
        WeatherService.GetWeatherForecast(DateOnly.FromDateTime(date), days ?? 0);
}

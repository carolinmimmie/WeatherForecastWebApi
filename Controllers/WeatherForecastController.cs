using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]// en array av string som består av olika väder
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // OLIKA ANROP 
    //GET - hämta data från backend
    //POST - skicka data till backend
    //PUT -  skicka data till backend
    //DELETE - radera data från backend
    [HttpGet(Name = "GetWeatherForecast")] 
    public IEnumerable<WeatherForecast> GetWeatherForecasts() // metod som returnera olika väder
    {

        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        return weatherForecasts;
    }
}

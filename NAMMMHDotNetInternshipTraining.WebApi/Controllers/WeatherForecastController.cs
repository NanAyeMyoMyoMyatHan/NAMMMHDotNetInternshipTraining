using Microsoft.AspNetCore.Mvc;

namespace NAMMMHDotNetInternshipTraining.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")] // This attribute specifies that this method will handle HTTP GET requests and assigns a name to the route for easier reference.
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast // This line generates a sequence of integers from 1 to 5 and projects each integer into a new WeatherForecast object.
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // This sets the Date property of the WeatherForecast object to a date that is 'index' days in the future from the current date.
                TemperatureC = Random.Shared.Next(-20, 55), // This assigns a random temperature in Celsius between -20 and 55 to the TemperatureC property of the WeatherForecast object.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

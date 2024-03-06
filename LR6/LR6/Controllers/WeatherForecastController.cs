using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast forecast)
        {
            // Виконання логіки для збереження передбачення погоди
            return Ok("Weather forecast has been successfully saved.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, WeatherForecast forecast)
        {
            // Виконання логіки для оновлення передбачення погоди за ідентифікатором
            return Ok($"Weather forecast with id {id} has been successfully updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Виконання логіки для видалення передбачення погоди за ідентифікатором
            return Ok($"Weather forecast with id {id} has been successfully deleted.");
        }
    }
}

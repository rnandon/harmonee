using harmonee.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

<<<<<<<< HEAD:harmonee/Server/Controllers/WeatherForecastController.cs
namespace harmonee.Server.Controllers
========
namespace harmonee.Controllers
>>>>>>>> 68b8e9c (Init):harmonee/harmonee/Controllers/WeatherForecastController.cs
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
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

<<<<<<<< HEAD:harmonee/Server/Controllers/WeatherForecastController.cs
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
========
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<string> Get()
        {
            return new List<string>();
>>>>>>>> 68b8e9c (Init):harmonee/harmonee/Controllers/WeatherForecastController.cs
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HelloDotnet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherClient _weatherClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherClient weatherClient)
        {
            _logger = logger;
            _weatherClient = weatherClient;
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var forecast = await _weatherClient.GetCurrentWeatherForCityAsync(city);

            var (weather, main, dt) = forecast;
            
            return new WeatherForecast{
                Summary = weather[0].description,
                TemperatureC = (int)main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(dt).DateTime
            };
        }
    }
}

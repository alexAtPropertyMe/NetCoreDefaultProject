using InterviewTemplate.Services.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTemplate.Controllers
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
        private readonly IFooBarGameService _fooBarGameService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFooBarGameService fooBarGameService)
        {
            _logger = logger;
            _fooBarGameService = fooBarGameService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IActionResult Get(int position, string answer)
        {
            return _fooBarGameService.ExecuteGame(new Domain.Games.FooBar { 
                Position = position,
                Answer = answer
            }) ? Ok() : BadRequest();
        }
    }
}

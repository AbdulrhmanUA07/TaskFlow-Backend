using Hangfire;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }



        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var result = await _weatherService.GetCurrentWeatherAsync();

            return Ok(result);
        }




    }
}
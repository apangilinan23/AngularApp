using Microsoft.AspNetCore.Mvc;
using AngularApp.Server.Services;

namespace AngularApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Forecast>> Get()
        {
            return await _weatherForecastService.GetAllAsync();
        }

        [HttpPost]
        public async Task<Forecast> Update(Forecast item)
        {
            return await _weatherForecastService.UpdateAsync(item);
        }
    }
}

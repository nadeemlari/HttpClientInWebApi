using Microsoft.AspNetCore.Mvc;

namespace HttpClientInWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            this._weatherForecastService = weatherForecastService;
        }
        

        [HttpGet]
        public async Task<string> Get(string cityName)
        {
           return await _weatherForecastService.GetAsync(cityName);
           
        }
    }
}
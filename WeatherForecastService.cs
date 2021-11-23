using Microsoft.Extensions.Options;

namespace HttpClientInWebApi
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherApiOptions _options;
        
        public WeatherForecastService(HttpClient httpClient,IOptionsSnapshot<WeatherApiOptions> options )
        {
            _httpClient = httpClient;
            _options = options.Value;
            
        }
        public async Task<string> GetAsync(string cityName)
        {
            var url = $"{_options.Url}?key={_options.Key}&q={cityName}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

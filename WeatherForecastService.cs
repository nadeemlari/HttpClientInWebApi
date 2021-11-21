namespace HttpClientInWebApi
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<string> GetAsync(string cityName)
        {
            var url = $"?key=3829ec236af9481da0d115901212111&q={cityName}";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

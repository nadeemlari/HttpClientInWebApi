namespace HttpClientInWebApi;

public interface IWeatherForecastService
{
    Task<string> GetAsync(string cityName);
}
using System.ComponentModel.DataAnnotations;

namespace HttpClientInWebApi
{
    public class WeatherApiOptions
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Key { get; set; }

        [Range(10,100)]
        public int Count { get; set; }

        public const string WeatherApiSection = "WeatherApi";
    }
}

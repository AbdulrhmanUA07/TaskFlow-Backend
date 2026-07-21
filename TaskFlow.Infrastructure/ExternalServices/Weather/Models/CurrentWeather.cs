using System.Text.Json.Serialization;

namespace TaskFlow.Infrastructure.ExternalServices.Weather.Models
{
    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }

}
using System.Text.Json.Serialization;

namespace TaskFlow.Infrastructure.ExternalServices.Weather.Models
{
    public class OpenMeteoResponse
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; } = null!;
    }
}
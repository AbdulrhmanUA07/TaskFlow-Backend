using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.Weather;
using TaskFlow.Application.Interfaces;
using TaskFlow.Infrastructure.ExternalServices.Weather.Models;

namespace TaskFlow.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<WeatherResponseDto> GetCurrentWeatherAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(
                "https://api.open-meteo.com/v1/forecast?latitude=30.04&longitude=31.24&current_weather=true");

            if (response == null)
                throw new Exception("Unable to retrieve weather.");

            return new WeatherResponseDto
            {
                Temperature = response.CurrentWeather.Temperature,
                WindSpeed = response.CurrentWeather.WindSpeed,
                Time = response.CurrentWeather.Time
            };

        }
    }
}

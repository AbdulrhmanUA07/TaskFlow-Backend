using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs.Weather;

namespace TaskFlow.Application.Interfaces
{
    public interface IWeatherService
    {
            Task<WeatherResponseDto> GetCurrentWeatherAsync();
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace TaskFlow.Application.DTOs.Weather
 {
        public class WeatherResponseDto
        {
            public double Temperature { get; set; }

            public double WindSpeed { get; set; }

            public DateTime Time { get; set; }
        }

 }




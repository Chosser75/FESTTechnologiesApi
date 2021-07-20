using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Models
{
    public class WeatherResponse
    {
        public float Temp { get; set; }
        public string Name { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

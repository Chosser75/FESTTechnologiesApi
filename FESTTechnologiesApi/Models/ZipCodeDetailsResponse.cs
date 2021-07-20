using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Models
{
    public class ZipCodeDetailsResponse
    {
        public WeatherResponse WeatherResponse { get; set; }
        public string TimeZone { get; set; }
    }
}

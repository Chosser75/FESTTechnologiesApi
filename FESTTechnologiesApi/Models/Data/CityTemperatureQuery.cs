using System;

namespace FESTTechnologiesApi.Models.Data
{
    public class CityTemperatureQuery
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public float Temp { get; set; }
        public string CityName { get; set; }
        public string TimeZoneName { get; set; }
        public DateTime? Requested { get; set; }

    }
}

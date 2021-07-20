namespace FESTTechnologiesApi.Models
{
    public class ZipCodeDetailsResponse
    {
        public WeatherResponse WeatherResponse { get; set; }
        public TimeZoneResponse TimeZoneResponse { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

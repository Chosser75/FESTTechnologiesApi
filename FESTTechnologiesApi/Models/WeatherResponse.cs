namespace FESTTechnologiesApi.Models
{
    public class WeatherResponse
    {
        public float Temp { get; set; }
        public string Name { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

using FESTTechnologiesApi.Interfaces;
using FESTTechnologiesApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Clients
{
    public class WeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public WeatherClient(HttpClient httpClient,
                             IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["ApiBaseUrls:OpenWeatherMap"];
            _apiKey = _configuration["ApiKeys:OpenWeatherMap"];
        }

        public async Task<WeatherResponse> GetCityNameAndTemperatureAsync(string zipCode)
        {
            WeatherResponse wheatherResponse = new WeatherResponse();

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                wheatherResponse.StatusCode = 400;
                wheatherResponse.ErrorMessage = "ZipCode is empty string.";
                return wheatherResponse;
            }

            string url = $"{_baseUrl}?zip={zipCode}&units=metric&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            wheatherResponse.StatusCode = (int)response.StatusCode;

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {                
                var result = JsonConvert.DeserializeObject<WeatherResult>(responseString);
                wheatherResponse.Name = result.Name;
                wheatherResponse.Temp = result.Main.Temp;
                wheatherResponse.Lat = result.Coord.Lat;
                wheatherResponse.Lon = result.Coord.Lon;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorResult>(responseString);
                wheatherResponse.ErrorMessage = result.Message;
            }

            return wheatherResponse;
        }
    }
}

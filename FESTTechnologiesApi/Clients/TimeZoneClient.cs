using FESTTechnologiesApi.Interfaces;
using FESTTechnologiesApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Clients
{
    public class TimeZoneClient : ITimeZoneClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public TimeZoneClient(HttpClient httpClient,
                              IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["ApiBaseUrls:GoogleTimeZone"];
            _apiKey = _configuration["ApiKeys:GoogleTimeZone"];
        }

        public async Task<TimeZoneResponse> GetTimeZoneAsync(float latitude, float longitude)
        {
            TimeZoneResponse timeZoneResponse = new TimeZoneResponse();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var lat = latitude.ToString().Replace(",", ".");
            var lon = longitude.ToString().Replace(",", ".");

            string url = $"{_baseUrl}/json?location={lat},{lon}&timestamp={unixTimestamp}&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                timeZoneResponse = JsonConvert.DeserializeObject<TimeZoneResponse>(responseString);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorResult>(responseString);
                timeZoneResponse.ErrorMessage = result.Status;
            }

            timeZoneResponse.StatusCode = (int)response.StatusCode;

            return timeZoneResponse;
        }
    }
}

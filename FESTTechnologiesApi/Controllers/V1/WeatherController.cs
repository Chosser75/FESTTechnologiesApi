using FESTTechnologiesApi.Interfaces;
using FESTTechnologiesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherClient _wheatherClient;

        public WeatherController(IWeatherClient wheatherClient)
        {
            _wheatherClient = wheatherClient;
        }

        [HttpGet("[action]/{zipCode}")]
        public async Task<IActionResult> GetZipCodeDetails(string zipCode)
        {
            ZipCodeDetailsResponse response = new ZipCodeDetailsResponse();

            var weatherResult = await _wheatherClient.GetCityNameAndTemperatureAsync(zipCode);

            if (weatherResult.StatusCode != 200)
            {
                response.WeatherResponse = new WeatherResponse
                {
                    StatusCode = weatherResult.StatusCode,
                    ErrorMessage = weatherResult.ErrorMessage
                };
                return StatusCode(weatherResult.StatusCode, response);
            }
                        
            response.WeatherResponse = weatherResult;

            response.TimeZone = "To be retrieved";

            return Ok(response);
        }

        

    }
}

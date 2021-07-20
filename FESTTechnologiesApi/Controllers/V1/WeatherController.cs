using FESTTechnologiesApi.Interfaces;
using FESTTechnologiesApi.Models;
using FESTTechnologiesApi.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherClient _wheatherClient;
        private readonly ITimeZoneClient _timeZoneClient;
        private readonly ILogger<WeatherController> _logger;
        private readonly IDbService _dbService;

        public WeatherController(IWeatherClient wheatherClient,
                                 ITimeZoneClient timeZoneClient,
                                 ILogger<WeatherController> logger,
                                 IDbService dbService)
        {
            _wheatherClient = wheatherClient;
            _timeZoneClient = timeZoneClient;
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet("[action]/{zipCode}")]
        public async Task<IActionResult> GetZipCodeDetails(string zipCode)
        {
            ZipCodeDetailsResponse response = new ZipCodeDetailsResponse();

            try
            {
                var weatherResult = await _wheatherClient.GetCityNameAndTemperatureAsync(zipCode);
                if (weatherResult.StatusCode != 200)
                {
                    response.StatusCode = weatherResult.StatusCode;
                    response.ErrorMessage = weatherResult.ErrorMessage;
                    return StatusCode(weatherResult.StatusCode, response);
                }

                response.WeatherResponse = weatherResult;

                var timeZoneResult = await _timeZoneClient.GetTimeZoneAsync(response.WeatherResponse.Lat, response.WeatherResponse.Lon);

                if (!timeZoneResult.Status.Equals("OK"))
                {
                    response.StatusCode = timeZoneResult.StatusCode;
                    response.ErrorMessage = timeZoneResult.ErrorMessage;
                    return StatusCode(timeZoneResult.StatusCode, response);
                }

                response.StatusCode = 200;
                response.TimeZoneResponse = timeZoneResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }

            await SaveQuery(zipCode, response);

            return Ok(response);
        }

        [HttpGet("[action]/{page}/{rowsPerPage}")]
        public IEnumerable<CityTemperatureQuery> GetCityTemperatureQueries(int page, int rowsPerPage)
        {
            return _dbService.GetCityTemperatureQueries(page, rowsPerPage);
        }

        private async Task SaveQuery(string zipCode, ZipCodeDetailsResponse response)
        {
            await _dbService.CreateCityTemperatureQueryAsync(new CityTemperatureQuery
            {
                CityName = response.WeatherResponse.Name,
                Temp = response.WeatherResponse.Temp,
                TimeZoneName = response.TimeZoneResponse.TimeZoneName,
                ZipCode = zipCode,
                Requested = DateTime.Now
            });
        }


    }
}

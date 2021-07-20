using FESTTechnologiesApi.Models;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Interfaces
{
    public interface IWeatherClient
    {
        Task<WeatherResponse> GetCityNameAndTemperatureAsync(string zipCode);
    }
}

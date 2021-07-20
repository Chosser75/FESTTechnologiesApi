using FESTTechnologiesApi.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Interfaces
{
    public interface IDbService
    {
        Task<int> CreateCityTemperatureQueryAsync(CityTemperatureQuery query);
        IEnumerable<CityTemperatureQuery> GetCityTemperatureQueries();
    }
}

using FESTTechnologiesApi.Models;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Interfaces
{
    public interface ITimeZoneClient
    {
        Task<TimeZoneResponse> GetTimeZoneAsync(float latitude, float longitude);
    }
}

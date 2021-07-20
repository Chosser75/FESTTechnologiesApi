using FESTTechnologiesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace FESTTechnologiesApi.Data
{
    public class FestDbContext : DbContext
    {
        public DbSet<CityTemperatureQuery> CityTemperatureQueries { get; set; }

        public FestDbContext(DbContextOptions<FestDbContext> options)
        : base(options)
        {

        }

    }
}

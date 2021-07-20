using FESTTechnologiesApi.Data;
using FESTTechnologiesApi.Interfaces;
using FESTTechnologiesApi.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Services
{
    public class DbService : IDbService
    {
        private readonly FestDbContext _dbContext;
        private readonly ILogger<DbService> _logger;

        public DbService(FestDbContext dbContext,
                         ILogger<DbService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<int> CreateCityTemperatureQueryAsync(CityTemperatureQuery query)
        {
            if (!isQueryValid(query))
            {
                return 0;
            }

            try
            {
                await _dbContext.CityTemperatureQueries.AddAsync(query);
                await _dbContext.SaveChangesAsync();

                return query.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return 0;
            }
        }

        public IEnumerable<CityTemperatureQuery> GetCityTemperatureQueries(int page, int rowsPerPage) =>
                                                                            _dbContext.CityTemperatureQueries
                                                                            .Skip((page - 1) * rowsPerPage)
                                                                            .Take(rowsPerPage)
                                                                            .AsNoTracking();

        private bool isQueryValid(CityTemperatureQuery query)
        {
            return !(string.IsNullOrEmpty(query.ZipCode) ||
                     string.IsNullOrEmpty(query.CityName) ||
                     string.IsNullOrEmpty(query.TimeZoneName) ||
                     query.Requested == DateTime.MinValue);
        }

    }
}

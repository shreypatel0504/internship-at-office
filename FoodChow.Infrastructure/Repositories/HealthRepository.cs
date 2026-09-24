using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly MySqlDalc _dalc;

        public HealthRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<VendorApiKeyResult?> GetVendorByApiKeyAsync(string apiKey)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<VendorApiKeyResult>(
                "USP_GetVendorByApiKey",
                new { p_api_key = apiKey },
                commandType: CommandType.StoredProcedure);
        }
    }
}
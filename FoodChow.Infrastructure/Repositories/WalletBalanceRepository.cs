using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class WalletBalanceRepository : IWalletBalanceRepository
    {
        private readonly MySqlDalc _dalc;

        public WalletBalanceRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<double?> GetWalletBalanceByApiKeyAsync(string apiKey)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<double?>(
                "USP_GetWalletBalanceByApiKey",
                new { p_api_key = apiKey },
                commandType: CommandType.StoredProcedure);
        }
    }
}
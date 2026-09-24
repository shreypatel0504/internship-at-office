using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        private readonly MySqlDalc _dalc;

        public MetaRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<bool> IsLocationServiceableAsync(double latitude, double longitude)
        {
            var result = await _dalc.CreateConnection().QueryFirstOrDefaultAsync<int?>(
                "USP_CheckAreaServiceability",
                new { p_latitude = latitude, p_longitude = longitude },
                commandType: CommandType.StoredProcedure);
            return (result ?? 0) > 0;
        }

        public async Task<MetaTypesRawResult> GetMetaTypesAsync()
        {
            using var multi = await _dalc.CreateConnection().QueryMultipleAsync(
                "USP_GetMetaTypes",
                commandType: CommandType.StoredProcedure);

            var vehicles = (await multi.ReadAsync<VehicleTypeRow>()).ToList();
            var settings = (await multi.ReadAsync<MetaSettingRow>()).ToList();

            return new MetaTypesRawResult { Vehicles = vehicles, Settings = settings };
        }
    }
}
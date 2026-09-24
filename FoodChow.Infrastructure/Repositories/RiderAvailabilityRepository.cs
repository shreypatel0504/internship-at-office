using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class RiderAvailabilityRepository : IRiderAvailabilityRepository
    {
        private readonly MySqlDalc _dalc;

        public RiderAvailabilityRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<bool> IsRiderAvailableAsync(
            double latitude, double longitude,
            string vehicleTypeId, int rangeMeters)
        {
            var result = await _dalc.CreateConnection().QueryFirstOrDefaultAsync<int?>(
                "USP_CheckRiderAvailability",
                new
                {
                    p_latitude = latitude,
                    p_longitude = longitude,
                    p_vehicle_type_id = vehicleTypeId,
                    p_range_meters = rangeMeters
                },
                commandType: CommandType.StoredProcedure);

            return (result ?? 0) > 0;
        }
    }
}
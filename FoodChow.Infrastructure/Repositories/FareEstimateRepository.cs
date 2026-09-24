using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class FareEstimateRepository : IFareEstimateRepository
    {
        private readonly MySqlDalc _dalc;

        public FareEstimateRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<FareCalculationResult?> CalculateFareAsync(
            double pickupLatitude, double pickupLongitude,
            double dropLatitude, double dropLongitude,
            string vehicleTypeId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<FareCalculationResult>(
                "USP_GetFareEstimate",
                new
                {
                    pickup_latitude = pickupLatitude,
                    pickup_longitude = pickupLongitude,
                    drop_latitude = dropLatitude,
                    drop_longitude = dropLongitude,
                    vehicle_type_id = vehicleTypeId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
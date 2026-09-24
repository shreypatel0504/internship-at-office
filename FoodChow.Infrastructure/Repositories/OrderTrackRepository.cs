using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class OrderTrackRepository : IOrderTrackRepository
    {
        private readonly MySqlDalc _dalc;

        public OrderTrackRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<OrderTrackRawResult?> GetOrderTrackingAsync(string externalOrderId)
        {
            using var multi = await _dalc.CreateConnection().QueryMultipleAsync(
                "USP_TrackOrder",
                new { p_external_order_id = externalOrderId },
                commandType: CommandType.StoredProcedure);

            var main = await multi.ReadFirstOrDefaultAsync<OrderTrackMainRow>();
            if (main is null) return null;

            var stops = (await multi.ReadAsync<OrderTrackStopRow>()).ToList();
            var goods = (await multi.ReadAsync<OrderTrackGoodsRow>()).ToList();
            var history = (await multi.ReadAsync<OrderTrackHistoryRow>()).ToList();

            return new OrderTrackRawResult
            {
                Main = main,
                Stops = stops,
                Goods = goods,
                History = history
            };
        }
    }
}
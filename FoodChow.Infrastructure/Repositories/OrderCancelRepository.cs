using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class OrderCancelRepository : IOrderCancelRepository
    {
        private readonly MySqlDalc _dalc;

        public OrderCancelRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<string?> GetOrderStatusAsync(string externalOrderId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<string>(
                "USP_GetOrderStatus",
                new { p_external_order_id = externalOrderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task CancelOrderAsync(string externalOrderId, string cancelReason, DateTime cancelledAt)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Cancel_Order",
                new { p_external_order_id = externalOrderId, p_cancel_reason = cancelReason, p_cancelled_at = cancelledAt },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddOrderStatusHistoryAsync(string externalOrderId, string? statusFrom, string statusTo, string changedBy, string changeReason, DateTime createdDate)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_OrderStatusHistory",
                new
                {
                    external_order_id = externalOrderId,
                    status_from = statusFrom,
                    status_to = statusTo,
                    changed_by = changedBy,
                    change_reason = changeReason,
                    created_date = createdDate
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
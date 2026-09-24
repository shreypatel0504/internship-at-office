using Dapper;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class OrderCreateRepository : IOrderCreateRepository
    {
        private readonly MySqlDalc _dalc;

        public OrderCreateRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<OrderCreateResult?> CreateOrderAsync(CreateOrderParams p)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<OrderCreateResult>(
                "Add_Order",
                new
                {
                    p_external_order_id = p.ExternalOrderId,
                    p_vehicle_type_id = p.VehicleTypeId,
                    p_order_pay_type = p.OrderPayType,
                    p_is_scheduled = p.IsScheduled,
                    p_schedule_date = p.ScheduleDate,
                    p_load_assist_needed = p.LoadAssistNeeded,
                    p_cash_collect_at_pickup = p.CashCollectAtPickUp,
                    p_is_otp_requested = p.IsOtpRequestedForVerification,
                    p_pickup_latitude = p.PickupLatitude,
                    p_pickup_longitude = p.PickupLongitude,
                    p_drop_latitude = p.DropLatitude,
                    p_drop_longitude = p.DropLongitude,
                    p_created_at = p.CreatedAt
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddOrderStopAsync(string externalOrderId, OrderLocationDto location, int stopOrder)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_OrderStop",
                new
                {
                    external_order_id = externalOrderId,
                    latitude = location.Latitude,
                    longitude = location.Longitude,
                    address = location.Address,
                    near_by_landmark = location.NearByLandmark,
                    pincode = location.Pincode,
                    other_location_text = location.OtherLocationText,
                    unit_number = location.UnitNumber,
                    sender_name = location.SenderName,
                    sender_number = location.SenderNumber,
                    city = location.City,
                    stop_order = stopOrder
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddOrderGoodsTypeAsync(string externalOrderId, string goodsType)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_OrderGoodsType",
                new { external_order_id = externalOrderId, goods_type = goodsType },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddOrderStatusHistoryAsync(string externalOrderId, string statusTo, string changedBy, string changeReason, DateTime createdDate)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Add_OrderStatusHistory",
                new
                {
                    external_order_id = externalOrderId,
                    status_from = (string?)null,
                    status_to = statusTo,
                    changed_by = changedBy,
                    change_reason = changeReason,
                    created_date = createdDate
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
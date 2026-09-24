using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class LalaMoveRepository(MySqlDalc dalc) : ILalaMoveRepository
    {
        // ================= USER DETAILS =================
        public Task<LalaMoveUserDetailsDto?> GetUserDetailsAsync(long shopId) =>
            dalc.ExecuteSpSingleAsync<LalaMoveUserDetailsDto>(
                "get_lalamove_user_details",
                new
                {
                    shop_id = shopId,   // ✅ FIXED
                    type = "LalaMove"
                });

        // ================= SAVE ORDER =================
        public Task<int> SaveOrderDetailsAsync(SaveLalaMoveOrderDto dto) =>
            dalc.ExecuteSpNonQueryAsync("add_lalamove_order_details", new
            {
                shop_id = dto.ShopId,   // ✅ FIXED
                foodchow_order_id = dto.FoodchowOrderId,
                order_id = dto.LalaMoveOrderId ?? string.Empty,
                total = dto.Total,
                order_status = dto.OrderStatus ?? string.Empty,
                updatedAt = string.Empty,
                track_link = dto.TrackLink ?? string.Empty,
                created_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                updated_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            });

        // ================= ADD ORDER =================
        public Task<int> AddOrderDetailsAsync(PlaceOrderDto dto) =>
            dalc.ExecuteSpNonQueryAsync("USP_add_lalamoveorderdetails", new
            {
                user_name = dto.UserName ?? string.Empty,
                user_phone = dto.UserPhone ?? string.Empty,
                foodchow_order_id = dto.FoodchowOrderId,
                shop_id = dto.ShopId,   // ✅ FIXED
                shop_name = dto.ShopName ?? string.Empty,
                shop_phone = dto.ShopPhone ?? string.Empty,
                quotationIds = dto.QuotationIds ?? string.Empty,
                stop_id_1 = dto.StopId1 ?? string.Empty,
                stop_id_2 = dto.StopId2 ?? string.Empty,
                cust_email = dto.CustEmail ?? string.Empty
            });

        // ================= ORDER DETAILS =================
        public Task<dynamic?> GetOrderDetailsAsync(string foodchowOrderId) =>
            dalc.ExecuteSpSingleAsync<dynamic>(
                "get_lalamove_order_details",
                new
                {
                    foodchow_order_id = foodchowOrderId   // ✅ FIXED
                });

        // ================= ORDER STATUS =================
        public Task<int> UpdateOrderStatusAsync(string orderId, string status, string updatedAt) =>
            dalc.ExecuteSpNonQueryAsync("usp_lalamove_order_status", new
            {
                order_id = orderId,   // ✅ FIXED
                order_status = status,
                updatedAt = updatedAt
            });

        // ================= DRIVER DETAILS =================
        public Task<int> UpdateDriverDetailsAsync(string orderId, string driverId,
            string driverName, string driverPhone, string updatedAt) =>
            dalc.ExecuteSpNonQueryAsync("usp_lalamove_driver_details", new
            {
                order_id = orderId,   // ✅ FIXED
                driver_id = driverId,
                driver_name = driverName,
                driver_phone = driverPhone,
                updatedAt = updatedAt
            });
    }
}
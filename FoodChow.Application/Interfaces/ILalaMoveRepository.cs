using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface ILalaMoveRepository
    {
        Task<LalaMoveUserDetailsDto?> GetUserDetailsAsync(long shopId);
        Task<int> SaveOrderDetailsAsync(SaveLalaMoveOrderDto dto);
        Task<int> AddOrderDetailsAsync(PlaceOrderDto dto);
        Task<dynamic?> GetOrderDetailsAsync(string foodchowOrderId);
        Task<int> UpdateOrderStatusAsync(string orderId, string status, string updatedAt);
        Task<int> UpdateDriverDetailsAsync(string orderId, string driverId, string driverName, string driverPhone, string updatedAt);
    }
}
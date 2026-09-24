namespace FoodChow.Application.Interfaces
{
    public interface IOrderCancelRepository
    {
        Task<string?> GetOrderStatusAsync(string externalOrderId);
        Task CancelOrderAsync(string externalOrderId, string cancelReason, DateTime cancelledAt);
        Task AddOrderStatusHistoryAsync(string externalOrderId, string? statusFrom, string statusTo, string changedBy, string changeReason, DateTime createdDate);
    }
}
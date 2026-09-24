using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class OrderCancelService
    {
        private readonly IOrderCancelRepository _repo;

        public OrderCancelService(IOrderCancelRepository repo)
        {
            _repo = repo;
        }

        public async Task<CancelOrderResponseDto> CancelOrderAsync(string orderId, CancelOrderRequestDto request)
        {
            var currentStatus = await _repo.GetOrderStatusAsync(orderId);

            if (currentStatus is null)
            {
                return new CancelOrderResponseDto
                {
                    Status = 404,
                    Success = false,
                    Message = "Order not found.",
                    Data = null
                };
            }

            if (currentStatus != "Pending" && currentStatus != "Accepted")
            {
                return new CancelOrderResponseDto
                {
                    Status = 400,
                    Success = false,
                    Message = $"Order cannot be cancelled from '{currentStatus}' state.",
                    Data = null
                };
            }

            var cancelledAt = DateTime.UtcNow;
            var cancelReason = string.IsNullOrWhiteSpace(request?.CancelReason)
                ? "Not specified"
                : request.CancelReason;

            await _repo.CancelOrderAsync(orderId, cancelReason, cancelledAt);
            await _repo.AddOrderStatusHistoryAsync(orderId, currentStatus, "Cancelled", "Vendor", cancelReason, cancelledAt);

            return new CancelOrderResponseDto
            {
                Status = 200,
                Success = true,
                Message = "Order cancelled successfully",
                Data = new CancelOrderDataDto
                {
                    ExternalOrderId = orderId,
                    Status = "Cancelled",
                    CancelReason = cancelReason,
                    CancelledAt = cancelledAt
                }
            };
        }
    }
}
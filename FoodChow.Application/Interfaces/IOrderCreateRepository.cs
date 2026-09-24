namespace FoodChow.Application.Interfaces
{
    public class OrderCreateResult
    {
        public double total_amount { get; set; }
        public double total_payable_amount { get; set; }
        public double distance { get; set; }
        public double estimated_duration { get; set; }
        public string? vehicle_name { get; set; }
        public double vehicle_weight { get; set; }
    }

    public class CreateOrderParams
    {
        public string ExternalOrderId { get; set; } = string.Empty;
        public string VehicleTypeId { get; set; } = string.Empty;
        public string OrderPayType { get; set; } = string.Empty;
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public bool LoadAssistNeeded { get; set; }
        public bool CashCollectAtPickUp { get; set; }
        public bool IsOtpRequestedForVerification { get; set; }
        public double PickupLatitude { get; set; }
        public double PickupLongitude { get; set; }
        public double DropLatitude { get; set; }
        public double DropLongitude { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public interface IOrderCreateRepository
    {
        Task<OrderCreateResult?> CreateOrderAsync(CreateOrderParams p);
        Task AddOrderStopAsync(string externalOrderId, FoodChow.Application.DTOs.OrderLocationDto location, int stopOrder);
        Task AddOrderGoodsTypeAsync(string externalOrderId, string goodsType);
        Task AddOrderStatusHistoryAsync(string externalOrderId, string statusTo, string changedBy, string changeReason, DateTime createdDate);
    }
}
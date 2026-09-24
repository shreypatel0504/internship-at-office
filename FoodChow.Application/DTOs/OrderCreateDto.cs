namespace FoodChow.Application.DTOs
{
    public class OrderLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
        public string? NearByLandmark { get; set; }
        public string? Pincode { get; set; }
        public string? OtherLocationText { get; set; }
        public string? UnitNumber { get; set; }
        public string? SenderName { get; set; }
        public string? SenderNumber { get; set; }
        public string? City { get; set; }
    }

    public class OrderStopDto : OrderLocationDto
    {
        public int StopOrder { get; set; }
    }

    public class CreateOrderRequestDto
    {
        public List<OrderLocationDto> Locations { get; set; } = new();
        public string VehicleTypeId { get; set; } = string.Empty;
        public List<string> GoodsTypes { get; set; } = new();
        public bool LoadAssistNeeded { get; set; }
        public string OrderPayType { get; set; } = string.Empty;
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public bool CashCollectAtPickUp { get; set; }
        public string ExternalOrderId { get; set; } = string.Empty;
        public bool IsOtpRequestedForVerification { get; set; }
    }

    public class CreateOrderResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public CreateOrderDataDto? Data { get; set; }
    }

    public class CreateOrderDataDto
    {
        public string ExternalOrderId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public OrderLocationDto PickupLocation { get; set; } = new();
        public List<OrderStopDto> OrderStops { get; set; } = new();
        public OrderLocationDto DropLocation { get; set; } = new();
        public OrderPricingDto Pricing { get; set; } = new();
        public OrderDeliveryInfoDto DeliveryInfo { get; set; } = new();
        public OrderVehicleDto OrderVehicle { get; set; } = new();
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public List<OrderStatusHistoryDto> StatusHistory { get; set; } = new();
    }

    public class OrderPricingDto
    {
        public double TotalAmount { get; set; }
        public double TotalPayableAmount { get; set; }
    }

    public class OrderDeliveryInfoDto
    {
        public List<string> GoodsTypes { get; set; } = new();
        public double Distance { get; set; }
        public double EstimatedDuration { get; set; }
    }

    public class OrderVehicleDto
    {
        public string VehicleType { get; set; } = string.Empty;
        public string VehicleSubType { get; set; } = string.Empty;
    }

    public class OrderStatusHistoryDto
    {
        public string ExternalOrderId { get; set; } = string.Empty;
        public string? StatusFrom { get; set; }
        public string StatusTo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string ChangedBy { get; set; } = string.Empty;
        public string ChangeReason { get; set; } = string.Empty;
    }
}
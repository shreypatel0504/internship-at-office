namespace FoodChow.Application.DTOs
{
    public class TrackLocationDto
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
        public string? PickupLocationType { get; set; }
    }

    public class TrackStopDto : TrackLocationDto
    {
        public int StopOrder { get; set; }
    }

    public class TrackOrderResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public TrackOrderDataDto? Data { get; set; }
    }

    public class TrackOrderDataDto
    {
        public string TrackingUrl { get; set; } = string.Empty;
        public string ExternalOrderId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public TrackLocationDto PickupLocation { get; set; } = new();
        public List<TrackStopDto> OrderStops { get; set; } = new();
        public TrackLocationDto DropLocation { get; set; } = new();
        public TrackPricingDto Pricing { get; set; } = new();
        public TrackDeliveryInfoDto DeliveryInfo { get; set; } = new();
        public TrackVehicleDto OrderVehicle { get; set; } = new();
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public List<TrackStatusHistoryDto> StatusHistory { get; set; } = new();
    }

    public class TrackPricingDto
    {
        public double TotalAmount { get; set; }
        public double TotalPayableAmount { get; set; }
    }

    public class TrackDeliveryInfoDto
    {
        public List<string> GoodsTypes { get; set; } = new();
        public double Distance { get; set; }
        public double Duration { get; set; }
    }

    public class TrackVehicleDto
    {
        public string VehicleType { get; set; } = string.Empty;
        public string VehicleSubType { get; set; } = string.Empty;
    }

    public class TrackStatusHistoryDto
    {
        public string? StatusFrom { get; set; }
        public string StatusTo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string ChangedBy { get; set; } = string.Empty;
        public string ChangeReason { get; set; } = string.Empty;
        public int? LocationIndex { get; set; }
        public string? CurrentLocationType { get; set; }
        public object? AdditionalData { get; set; }
        public object? Pilot { get; set; }
        public object? VehicleInfo { get; set; }
    }
}
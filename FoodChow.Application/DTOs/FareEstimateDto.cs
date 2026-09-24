namespace FoodChow.Application.DTOs
{
    public class FareEstimateRequestDto
    {
        public List<FareLocationDto> Locations { get; set; } = new();
        public string VehicleTypeId { get; set; } = string.Empty;
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
    }

    public class FareLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
    }

    public class FareEstimateResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public FareEstimateDataDto? Data { get; set; }
    }

    public class FareEstimateDataDto
    {
        public FarePricingDto Pricing { get; set; } = new();
        public FareRouteDto Route { get; set; } = new();
        public FareVehicleInfoDto VehicleInfo { get; set; } = new();
    }

    public class FarePricingDto
    {
        public double TotalAmount { get; set; }
        public double Cgst { get; set; }
        public double Sgst { get; set; }
        public double TotalPayableAmount { get; set; }
    }

    public class FareRouteDto
    {
        public double Distance { get; set; }
        public double EstimatedDuration { get; set; }
    }

    public class FareVehicleInfoDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
    }
}
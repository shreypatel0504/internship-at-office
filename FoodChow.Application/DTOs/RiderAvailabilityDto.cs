namespace FoodChow.Application.DTOs
{
    public class RiderAvailabilityRequestDto
    {
        public List<LocationDto> Locations { get; set; } = new();
        public string VehicleTypeId { get; set; } = string.Empty;
        public int RangeMeters { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? ScheduleDate { get; set; }
    }

    public class RiderAvailabilityResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public RiderAvailabilityDataDto? Data { get; set; }
    }

    public class RiderAvailabilityDataDto
    {
        public bool Available { get; set; }
    }
}
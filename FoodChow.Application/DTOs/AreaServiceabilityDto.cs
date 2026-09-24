namespace FoodChow.Application.DTOs
{
    public class AreaServiceabilityBatchRequestDto
    {
        public List<LocationDto> Locations { get; set; } = new();
    }

    public class LocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationServiceabilityDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsServiceable { get; set; }
    }

    public class AreaServiceabilityResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<LocationServiceabilityDto>? Data { get; set; }
    }
}
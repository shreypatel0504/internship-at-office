namespace FoodChow.Application.DTOs
{
    // =========================
    // REQUEST DTO
    // =========================
    public class PorterRequest
    {
        public long ShopId { get; set; }
        public double PickupLat { get; set; }
        public double PickupLng { get; set; }
        public double DropLat { get; set; }
        public double DropLng { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    // =========================
    // RESPONSE DTO
    // =========================
    public class PorterResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
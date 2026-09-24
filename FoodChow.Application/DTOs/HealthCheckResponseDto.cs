namespace FoodChow.Application.DTOs
{
    public class HealthCheckResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public HealthCheckDataDto? Data { get; set; }
    }

    public class HealthCheckDataDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime Timestamp { get; set; }
        public VendorInfoDto? Vendor { get; set; }
        public ApiKeyInfoDto? ApiKey { get; set; }
    }

    public class VendorInfoDto
    {
        public string? CompanyName { get; set; }
        public bool IsActive { get; set; }
    }

    public class ApiKeyInfoDto
    {
        public List<string> Permissions { get; set; } = new();
    }
}
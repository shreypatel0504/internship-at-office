namespace FoodChow.Application.DTOs
{
    public class UpdatePorterConfigurationDto
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string? ApiKey { get; set; }

        public string? ApiSecret { get; set; }

        public string? CustomerId { get; set; }

        public string? BaseUrl { get; set; }

        public string? CountryCode { get; set; }

        public string? Mode { get; set; }

        public bool IsActive { get; set; }
    }
}
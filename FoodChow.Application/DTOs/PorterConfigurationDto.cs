namespace FoodChow.Application.DTOs
{
    public class PorterConfigurationDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string BaseUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
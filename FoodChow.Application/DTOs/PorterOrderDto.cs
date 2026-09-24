namespace FoodChow.Application.DTOs
{
    public class PorterOrderDto
    {
        public long ShopId { get; set; }

        public string? RequestId { get; set; }

        public string? PickupAddress { get; set; }

        public string? DropAddress { get; set; }

        public string? CustomerName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
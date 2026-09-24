// LalamoveOrderDto.cs
namespace FoodChow.Application.DTOs
{
    public class LalamoveOrderDto
    {
        public long ShopId { get; set; }
        public string? PickupAddress { get; set; }
        public string? DropAddress { get; set; }
        public string? PickupLat { get; set; }
        public string? PickupLng { get; set; }
        public string? DropLat { get; set; }
        public string? DropLng { get; set; }
    }
}
// LalamoveOrderDetailsDto.cs
namespace FoodChow.Application.DTOs
{
    public class LalamoveOrderDetailsDto
    {
        public long ShopId { get; set; }
        public string? FoodchowOrderId { get; set; }
        public string? LalamoveOrderId { get; set; }
        public decimal Total { get; set; }
        public string? OrderStatus { get; set; }
        public string? TrackLink { get; set; }
    }
}
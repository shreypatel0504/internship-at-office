namespace FoodChow.Domain.Entities
{
    public class LalaMove
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string OrderId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerPhone { get; set; } = string.Empty;

        public string PickupAddress { get; set; } = string.Empty;

        public string DropAddress { get; set; } = string.Empty;

        public decimal DeliveryCharge { get; set; }

        public string DriverName { get; set; } = string.Empty;

        public string DriverPhone { get; set; } = string.Empty;

        public string VehicleType { get; set; } = string.Empty;

        public string TrackingUrl { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
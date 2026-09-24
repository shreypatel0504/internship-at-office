namespace FoodChow.Application.DTOs
{
    public class PorterQuoteDto
    {
        public long ShopId { get; set; }

        public double PickupLat { get; set; }

        public double PickupLng { get; set; }

        public double DropLat { get; set; }

        public double DropLng { get; set; }

        public string? CustomerName { get; set; }

        public string? CountryCode { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
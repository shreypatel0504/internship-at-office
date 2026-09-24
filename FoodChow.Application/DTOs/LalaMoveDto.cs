using System.ComponentModel.DataAnnotations.Schema;

namespace FoodChow.Application.DTOs
{
    public class LalaMoveUserDetailsDto
    {
        [Column("api_key")]
        public string? ApiKey { get; set; }

        [Column("api_secret")]
        public string? ApiSecret { get; set; }

        [Column("market_code")]
        public string? MarketCode { get; set; }

        [Column("baseurl")]
        public string? BaseUrl { get; set; }
    }

    public class GetQuotationDto
    {
        public long ShopId { get; set; }
        public string? PickupLat { get; set; }
        public string? PickupLng { get; set; }
        public string? PickupAddress { get; set; }
        public string? DropLat { get; set; }
        public string? DropLng { get; set; }
        public string? DropAddress { get; set; }
    }

    public class PlaceOrderDto
    {
        public long ShopId { get; set; }
        public string? QuotationIds { get; set; }
        public string? StopId1 { get; set; }
        public string? StopId2 { get; set; }
        public string? ShopName { get; set; }
        public string? ShopPhone { get; set; }
        public string? UserName { get; set; }
        public string? UserPhone { get; set; }
        public long FoodchowOrderId { get; set; }
        public string? CustEmail { get; set; }
    }

    public class SaveLalaMoveOrderDto
    {
        public long ShopId { get; set; }
        public long FoodchowOrderId { get; set; }
        public string? LalaMoveOrderId { get; set; }
        public decimal Total { get; set; }
        public string? OrderStatus { get; set; }
        public string? TrackLink { get; set; }
    }
}
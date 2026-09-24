namespace FoodChow.Domain.Entities
{
    public class UberDirectIntegrationEntity
    {
        public int Id { get; set; }
        public long ShopId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string BaseUrl { get; set; }
        public int DeliveryProcess { get; set; }
        public string OrderTime { get; set; }
        public string SigningSecret { get; set; }
        public string WebhookSecret { get; set; }
    }
    public class UberDirectQuoteEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string Kind { get; set; }
        public string QuoteId { get; set; }
        public decimal DeliveryFees { get; set; }
        public string CurrencyType { get; set; }
        public string QuoteObject { get; set; }
        public string OrderId { get; set; }
        public string DeliveryId { get; set; }
        public string TrackingUrl { get; set; }
        public string Status { get; set; }
        public string DeliveryObject { get; set; }
       

    }
}
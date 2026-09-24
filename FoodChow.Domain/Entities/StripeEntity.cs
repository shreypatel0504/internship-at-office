namespace FoodChow.Domain.Entities
{
    public class StripePlatformEntity
    {
        public int Id { get; set; }
        public string ApiUrl { get; set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
        public string WebhookSecret { get; set; }
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
    }
    public class StripeConnectAccountEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string RefreshToken { get; set; }
        public string SecretKey { get; set; }
        public string PublishKey { get; set; }
        public int Status { get; set; }
      
              
    }
    public class StripeTransactionEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string OrderId { get; set; }
        public string ChargeId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string ShopAccount { get; set; }
    }
    public class ShopStripeEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string ConnectId { get; set; }
        public string SecretKey { get; set; }
        public string PublishKey { get; set; }
        public string Type { get; set; }
        public string TransactionType { get; set; }
    }
    public class StripeCountryEntity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
    }
}
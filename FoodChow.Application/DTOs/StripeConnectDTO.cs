namespace FoodChow.Application.DTOs
{
    public class StripeConnectDTO
    {
        public long StripeConnectId { get; set; }
        public long ShopId { get; set; }
        public string StripeAccountId { get; set; }
        public string StripeCustomerId { get; set; }
        public string AccountEmail { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
    }
}
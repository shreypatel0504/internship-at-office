namespace FoodChow.Domain.Entities
{
    public class ReferredRestaurantEntity
    {
        public int Id { get; set; }
        public string RestaurantId { get; set; }
        public string ReferringRestaurantId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ReferredBy { get; set; }
        public int Claimed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class ClaimRequestOwnerEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string NewEmail { get; set; }
        public string CountryCode { get; set; }
        public string ContactNo { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class WhatsAppSummaryEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string OrderId { get; set; }
        public string SuccessResponse { get; set; }
        public string WhatsappResponse { get; set; }
        public string MessageId { get; set; }
        public string ElementType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
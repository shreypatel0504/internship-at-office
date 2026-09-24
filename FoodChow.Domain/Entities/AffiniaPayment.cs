namespace FoodChow.Domain.Entities
{
    public class AffiniaPayment
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public long OrderId { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }  // "Card" | "UPI" | "NetBanking" | "Wallet"
        public decimal Amount { get; set; }
        public string? Currency { get; set; }        // "INR"
        public string? Status { get; set; }          // "Pending" | "Success" | "Failed" | "Refunded"
        public string? ReferenceNo { get; set; }
        public string? Remarks { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
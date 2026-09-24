namespace FoodChow.Application.DTOs
{
    public class AffiniaPaymentDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public long OrderId { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Remarks { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AddAffiniaPaymentDto
    {
        public long ShopId { get; set; }
        public long OrderId { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Remarks { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class UpdateAffiniaPaymentDto
    {
        public long Id { get; set; }
        public string? Status { get; set; }
        public string? TransactionId { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Remarks { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class CreatePaymentDto
    {
        public long OrderId { get; set; }
        public long ShopId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}
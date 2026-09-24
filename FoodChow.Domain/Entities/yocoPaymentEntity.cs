namespace FoodChow.Domain.Entities
{
    public class YocoCredentialEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
        public string WebhookId { get; set; }
        public string WebhookSecret { get; set; }
    }
    public class YocoOrderPaymentEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string CheckoutId { get; set; }
        public string PaymentId { get; set; }
        public string RefundId { get; set; }
        public string Status { get; set; }
        public string CheckoutResponse { get; set; }
        public string RefundResponse { get; set; }
    }
    public class YocoPaymentErrorEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string Timestamps { get; set; }
        public string Path { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public string RequestId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
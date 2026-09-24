namespace FoodChow.Application.DTOs
{
    public class CreateFoodOrderRequest
    {
        public long ShopId { get; set; }
        public double Amount { get; set; }
        public double Charges { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = string.Empty;
        public DateTime TransDate { get; set; }
        public string? TableNo { get; set; }
        public long UserId { get; set; }
        public string? Notes { get; set; }
        public long OrderStatus { get; set; }
        public double Discount { get; set; }
        public double DiscountedAmount { get; set; }
        public string? CouponCode { get; set; }
        public string? OrderMenuType { get; set; }
    }
}
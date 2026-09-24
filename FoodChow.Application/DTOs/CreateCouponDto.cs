namespace FoodChow.Application.DTOs
{
    public class CreateCouponDto
    {
        public string CouponCode { get; set; } = string.Empty;

        public string CouponType { get; set; } = string.Empty;

        public decimal DiscountValue { get; set; }

        public decimal MinOrderAmount { get; set; }

        public decimal MaxDiscountAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int UsageLimit { get; set; }

        public bool IsActive { get; set; }
    }
}
namespace FoodChow.Domain.Entities
{
    public class CouponMaster
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public string CouponType { get; set; } = string.Empty;  // "Flat" | "Percentage"
        public decimal DiscountValue { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
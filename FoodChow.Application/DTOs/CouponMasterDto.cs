namespace FoodChow.Application.DTOs
{
    public class CouponMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal MinimumOrderAmount { get; set; }
        public string? CouponCode { get; set; }
        public decimal Discount { get; set; }
        public string? DiscountIn { get; set; }   // "Flat" | "Percentage"
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
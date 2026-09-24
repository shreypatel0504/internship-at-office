namespace FoodChow.Application.DTOs
{
    public class ApplyCouponResultDto
    {
        public bool IsSuccess { get; set; }

        public bool IsValid { get; set; }

        public string Message { get; set; } = string.Empty;

        public decimal DiscountAmount { get; set; }

        public decimal FinalAmount { get; set; }
    }
}
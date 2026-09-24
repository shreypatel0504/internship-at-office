namespace FoodChow.Domain.Entities
{
    public class PricingPlan
    {
        public long Id { get; set; }
        public long ShopId { get; set; }

        public string PlanType { get; set; } = string.Empty; // POS / ONLINE / FREE
        public string CountryName { get; set; } = string.Empty;

        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;

        public int NoOfOrders { get; set; }
        public int NoOfDays { get; set; }

        public decimal Commission { get; set; }
        public decimal CommissionGst { get; set; }
        public decimal PlatformFees { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
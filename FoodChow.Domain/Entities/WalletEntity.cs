namespace FoodChow.Domain.Entities
{
    public class WalletEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double TotalCashEarned { get; set; }
        public int ReferredCount { get; set; }
    }
    public class PointPlanDetailsEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public double Amount { get; set; }
        public double Coins { get; set; }
        public string PlanName { get; set; }
        public string Commision { get; set; }
        public string Currency { get; set; }
        public string CustomerId { get; set; }
        public string PaymentId { get; set; }
    }
    public class CurrentPointPlanEntity
    {
        public long ShopId { get; set; }
        public double Coins { get; set; }
        public double Amount { get; set; }
        public string CustomerId { get; set; }
        public string PaymentId { get; set; }
        public string PlanName { get; set; }
        public DateTime StartDate { get; set; }
        public string Commision { get; set; }
    }
    public class RestaurantWalletSummaryEntity
    {
        public long ShopId { get; set; }
        public double TotalCoins { get; set; }
        public double TotalAmount { get; set; }
        public string CurrentPlan { get; set; }
    }
}
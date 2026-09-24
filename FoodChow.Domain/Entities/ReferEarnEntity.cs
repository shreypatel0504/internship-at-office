namespace FoodChow.Domain.Entities
{
    public class CampaignEntity
    {
        public int CampaignId { get; set; }
        public string ShopId { get; set; }
        public string CampaignName { get; set; }
        public string RewardType { get; set; }
        public double CustomerReward { get; set; }
        public double ReferrerReward { get; set; }
        public double MinPurchase { get; set; }
    }
    public class ReferralRewardEntity
    {
        public int RewardId { get; set; }

        public string UserId { get; set; }

        public string RestaurantId { get; set; }

        public string RewardType { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public DateTime? EarnedDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsClaimed { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string ReferredUserId { get; set; }

        public double NewUserAmount { get; set; }
    }
   
    //public class WalletEntity
    //{
    //    public int Id { get; set; }
    //    public string UserId { get; set; }
    //    public double TotalCashEarned { get; set; }
    //    public int ReferredCount { get; set; }
    //}
   
    public class CashbackEntity
    {
        public int CashbackId { get; set; }

        public string ShopId { get; set; }

        public int CashbackEnable { get; set; }

        public string CashbackType { get; set; }

        public double CashbackValue { get; set; }

        public double MinimumOrderAmount { get; set; }

        public string TermAndCondition { get; set; }
    }
    

}
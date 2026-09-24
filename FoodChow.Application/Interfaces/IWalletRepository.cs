using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IWalletRepository
    {
        Task<WalletEntity> GetUserWallet(string userId);
        Task<long> AddUserWallet(WalletEntity e);
        Task<int> UpdateUserWallet(WalletEntity e);

        Task<IEnumerable<PointPlanDetailsEntity>> GetPointPlanHistory(long shopId);
        Task<long> AddPointPlan(PointPlanDetailsEntity e);

        Task<CurrentPointPlanEntity> GetCurrentPointPlan(long shopId);
        Task<int> UpdateCurrentPointPlan(CurrentPointPlanEntity e);
        Task<RestaurantWalletSummaryEntity> GetRestaurantWalletSummary(long shopId);

        Task<IEnumerable<ReferralRewardEntity>> GetReferralDetailsByRestaurant(string shopId);

        Task<long> AddFoodChowPricingPlanPoint(PointPlanDetailsEntity e);

        Task<IEnumerable<PointPlanDetailsEntity>> GetFoodChowPricingPlanPoint(long shopId);
    }
}
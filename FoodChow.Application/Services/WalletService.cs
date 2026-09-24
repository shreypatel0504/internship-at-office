using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class WalletService
    {
        private readonly IWalletRepository _repo;

        public WalletService(IWalletRepository repo)
        {
            _repo = repo;
        }

        public Task<WalletEntity> GetUserWallet(string userId)
            => _repo.GetUserWallet(userId);

        public Task<long> AddUserWallet(WalletEntity e)
            => _repo.AddUserWallet(e);

        public Task<int> UpdateUserWallet(WalletEntity e)
            => _repo.UpdateUserWallet(e);

        public Task<IEnumerable<PointPlanDetailsEntity>> GetPointPlanHistory(long shopId)
            => _repo.GetPointPlanHistory(shopId);

        public Task<long> AddPointPlan(PointPlanDetailsEntity e)
            => _repo.AddPointPlan(e);

        public Task<CurrentPointPlanEntity> GetCurrentPointPlan(long shopId)
            => _repo.GetCurrentPointPlan(shopId);

        public Task<int> UpdateCurrentPointPlan(CurrentPointPlanEntity e)
            => _repo.UpdateCurrentPointPlan(e);
        public Task<RestaurantWalletSummaryEntity> GetRestaurantWalletSummary(long shopId)
            => _repo.GetRestaurantWalletSummary(shopId);

        public Task<IEnumerable<ReferralRewardEntity>> GetReferralDetailsByRestaurant(string shopId)
            => _repo.GetReferralDetailsByRestaurant(shopId);

        public Task<long> AddFoodChowPricingPlanPoint(PointPlanDetailsEntity e)
            => _repo.AddFoodChowPricingPlanPoint(e);

        public Task<IEnumerable<PointPlanDetailsEntity>> GetFoodChowPricingPlanPoint(long shopId)
            => _repo.GetFoodChowPricingPlanPoint(shopId);
    }
}
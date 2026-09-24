using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly MySqlDalc _dalc;

        public WalletRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<WalletEntity> GetUserWallet(string userId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WalletEntity>(
                "USP_GetUserWallet",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddUserWallet(WalletEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddUserWallet",
                new
                {
                    p_user_id = e.UserId,
                    p_total_cash_earned = e.TotalCashEarned,
                    p_referred_count = e.ReferredCount
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateUserWallet(WalletEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateUserWallet",
                new
                {
                    p_user_id = e.UserId,
                    p_total_cash_earned = e.TotalCashEarned,
                    p_referred_count = e.ReferredCount
                },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<PointPlanDetailsEntity>> GetPointPlanHistory(long shopId)
            => await _dalc.CreateConnection().QueryAsync<PointPlanDetailsEntity>(
                "USP_GetPointPlanHistory",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddPointPlan(PointPlanDetailsEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddPointPlan",
                new
                {
                    p_shop_id = e.ShopId,
                    p_amount = e.Amount,
                    p_coins = e.Coins,
                    p_plan_name = e.PlanName,
                    p_commision = e.Commision,
                    p_currency = e.Currency,
                    p_customer_id = e.CustomerId,
                    p_payment_id = e.PaymentId
                },
                commandType: CommandType.StoredProcedure);

        public async Task<CurrentPointPlanEntity> GetCurrentPointPlan(long shopId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<CurrentPointPlanEntity>(
                "USP_GetCurrentPointPlan",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateCurrentPointPlan(CurrentPointPlanEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCurrentPointPlan",
                new
                {
                    p_shop_id = e.ShopId,
                    p_coins = e.Coins,
                    p_amount = e.Amount,
                    p_customer_id = e.CustomerId,
                    p_payment_id = e.PaymentId,
                    p_plan_name = e.PlanName,
                    p_commision = e.Commision
                },
                commandType: CommandType.StoredProcedure);

        public async Task<RestaurantWalletSummaryEntity> GetRestaurantWalletSummary(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<RestaurantWalletSummaryEntity>(
                "USP_GetRestaurantWalletSummary",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ReferralRewardEntity>> GetReferralDetailsByRestaurant(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_GetReferralDetailsByRestaurant",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddFoodChowPricingPlanPoint(PointPlanDetailsEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddFoodChowPricingPlanPoint",
                new
                {
                    p_shop_id = e.ShopId,
                    p_amount = e.Amount,
                    p_coins = e.Coins,
                    p_plan_name = e.PlanName
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PointPlanDetailsEntity>> GetFoodChowPricingPlanPoint(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<PointPlanDetailsEntity>(
                "USP_GetFoodChowPricingPlanPoint",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
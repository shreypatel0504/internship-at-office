using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class ReferAndEarnRepository : IReferAndEarnRepository
    {
        private readonly MySqlDalc _dalc;

        public ReferAndEarnRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        // ================= Campaign =================

        public async Task<IEnumerable<CampaignEntity>> GetAllCampaign()
            => await _dalc.CreateConnection().QueryAsync<CampaignEntity>(
                "USP_GetAllCampaign",
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<CampaignEntity>> GetCampaignsByShop(string shopId)
            => await _dalc.CreateConnection().QueryAsync<CampaignEntity>(
                "USP_GetCampaignByShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddCampaign(CampaignEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddCampaign",
                new
                {
                    p_shop_id = e.ShopId,
                    p_campaign_name = e.CampaignName,
                    p_reward_type = e.RewardType,
                    p_customer_reward = e.CustomerReward,
                    p_referrer_reward = e.ReferrerReward,
                    p_min_purchase = e.MinPurchase
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateCampaign(CampaignEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCampaign",
                new
                {
                    p_campaign_id = e.CampaignId,
                    p_campaign_name = e.CampaignName,
                    p_reward_type = e.RewardType,
                    p_customer_reward = e.CustomerReward,
                    p_referrer_reward = e.ReferrerReward
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteCampaign(int campaignId)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCampaign",
                new { p_campaign_id = campaignId },
                commandType: CommandType.StoredProcedure);

        // ================= Reward =================

        public async Task<IEnumerable<ReferralRewardEntity>> GetAllReferralRewards()
            => await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_GetAllReferralRewards",
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ReferralRewardEntity>> GetRewardsForUser(string userId)
            => await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_GetRewardsForUser",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ReferralRewardEntity>> GetRewardsForShop(string shopId)
            => await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_GetRewardsForShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddReferralReward(ReferralRewardEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddReferralReward",
                new
                {
                    p_user_id = e.UserId,
                    p_restaurant_id = e.RestaurantId,
                    p_reward_type = e.RewardType,
                    p_amount = e.Amount
                },
                commandType: CommandType.StoredProcedure);

      
        public async Task<int> UpdateReferralReward(ReferralRewardEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateReferralReward",
                new
                {
                    p_reward_id = e.RewardId,
                    p_reward_type = e.RewardType,
                    p_amount = e.Amount
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteReferralReward(int id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteReferralReward",
                new { p_reward_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddUser(string userId)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddUser",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateRefferedStatus(int id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateRefferedStatus",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        // ================= Wallet =================

        public async Task<IEnumerable<WalletEntity>> GetAllUsers()
            => await _dalc.CreateConnection().QueryAsync<WalletEntity>(
                "USP_GetAllUsers",
                commandType: CommandType.StoredProcedure);

        public async Task<WalletEntity> GetWalletByUserId(string userId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WalletEntity>(
                "USP_GetWalletByUserId",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddUser(WalletEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddUserWallet",
                new
                {
                    p_user_id = e.UserId,
                    p_total_cash_earned = e.TotalCashEarned
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateUser(WalletEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateUser",
                new
                {
                    p_user_id = e.UserId,
                    p_total_cash = e.TotalCashEarned,
                    p_referred_count = e.ReferredCount
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteUser(string userId)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteUserWallet",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);

        // ================= Cashback =================

        public async Task<IEnumerable<CashbackEntity>> GetAllCashback()
            => await _dalc.CreateConnection().QueryAsync<CashbackEntity>(
                "USP_GetAllCashback",
                commandType: CommandType.StoredProcedure);

        //public async Task<CashbackEntity> GetCashback(string shopId)
        //    => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<CashbackEntity>(
        //        "USP_GetCashbackByShop",
        //        new { p_shop_id = shopId },
        //        commandType: CommandType.StoredProcedure);

        public async Task<CashbackEntity> GetCashback(string shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<CashbackEntity>(
                "USP_GetCashback",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddCashback(CashbackEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddCashback",
                new
                {
                    p_shop_id = e.ShopId,
                    p_cashback_type = e.CashbackType,
                    p_cashback_value = e.CashbackValue
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateCashback(CashbackEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCashback",
                new
                {
                    p_cashback_id = e.CashbackId,
                    p_cashback_value = e.CashbackValue
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> DeleteCashback(int cashbackId)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCashback",
                new { p_cashback_id = cashbackId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateReferredStatus(int id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateReferredStatus",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<CampaignEntity>> ActiveCampaignsByShop(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<CampaignEntity>(
                "USP_ActiveCampaignsByShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ReferralRewardEntity>> UsersShopCashbackHistory(string userId)
        {
            return await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_UsersShopCashbackHistory",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ReferralRewardEntity>> UsersFoodchowCashbackHistory(string userId)
        {
            return await _dalc.CreateConnection().QueryAsync<ReferralRewardEntity>(
                "USP_UsersFoodchowCashbackHistory",
                new { p_user_id = userId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
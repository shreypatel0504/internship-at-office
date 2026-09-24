using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IReferAndEarnRepository
    {
        // Campaign
        Task<IEnumerable<CampaignEntity>> GetAllCampaign();
        Task<IEnumerable<CampaignEntity>> GetCampaignsByShop(string shopId);
        Task<long> AddCampaign(CampaignEntity entity);
        Task<int> UpdateCampaign(CampaignEntity entity);
        Task<int> DeleteCampaign(int campaignId);
        Task<IEnumerable<CampaignEntity>> ActiveCampaignsByShop(string shopId);

        // Referral Reward
        Task<IEnumerable<ReferralRewardEntity>> GetAllReferralRewards();
        Task<IEnumerable<ReferralRewardEntity>> GetRewardsForUser(string userId);
        Task<IEnumerable<ReferralRewardEntity>> GetRewardsForShop(string shopId);
        Task<long> AddReferralReward(ReferralRewardEntity entity);
        Task<int> UpdateReferralReward(ReferralRewardEntity entity);
        Task<int> DeleteReferralReward(int rewardId);
        Task<int> UpdateRefferedStatus(int id);

        

        

        // Wallet
        Task<IEnumerable<WalletEntity>> GetAllUsers();
        Task<WalletEntity> GetWalletByUserId(string userId);
        Task<long> AddUser(string userId);
        Task<int> UpdateUser(WalletEntity entity);
        Task<int> DeleteUser(string userId);

        // Cashback
        Task<IEnumerable<CashbackEntity>> GetAllCashback();
        Task<CashbackEntity> GetCashback(string shopId);
        Task<long> AddCashback(CashbackEntity entity);
        Task<int> UpdateCashback(CashbackEntity entity);
        Task<int> DeleteCashback(int cashbackId);

        Task<int> UpdateReferredStatus(int id);
       
        Task<IEnumerable<ReferralRewardEntity>> UsersShopCashbackHistory(string userId);

        Task<IEnumerable<ReferralRewardEntity>> UsersFoodchowCashbackHistory(string userId);
    }
}
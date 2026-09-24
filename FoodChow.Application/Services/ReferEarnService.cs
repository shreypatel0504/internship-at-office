using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class ReferAndEarnService
    {
        private readonly IReferAndEarnRepository _repo;

        public ReferAndEarnService(IReferAndEarnRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<CampaignEntity>> GetAllCampaign() => _repo.GetAllCampaign();
        public Task<IEnumerable<CampaignEntity>> GetCampaignsByShop(string shopId) => _repo.GetCampaignsByShop(shopId);
        public Task<long> AddCampaign(CampaignEntity e) => _repo.AddCampaign(e);
        public Task<int> UpdateCampaign(CampaignEntity e) => _repo.UpdateCampaign(e);
        public Task<int> DeleteCampaign(int id) => _repo.DeleteCampaign(id);

        public Task<IEnumerable<ReferralRewardEntity>> GetAllReferralRewards() => _repo.GetAllReferralRewards();
        public Task<IEnumerable<ReferralRewardEntity>> GetRewardsForUser(string id) => _repo.GetRewardsForUser(id);
        public Task<IEnumerable<ReferralRewardEntity>> GetRewardsForShop(string id) => _repo.GetRewardsForShop(id);
        public Task<long> AddReferralReward(ReferralRewardEntity e) => _repo.AddReferralReward(e);

        public Task<IEnumerable<WalletEntity>> GetAllUsers() => _repo.GetAllUsers();
        public Task<WalletEntity> GetWalletByUserId(string id) => _repo.GetWalletByUserId(id);

        public Task<IEnumerable<CashbackEntity>> GetAllCashback() => _repo.GetAllCashback();
        public Task<CashbackEntity> GetCashback(string id) => _repo.GetCashback(id);
        public async Task<int> UpdateReferralReward(ReferralRewardEntity e)
        {
            return await _repo.UpdateReferralReward(e);
        }

        public async Task<int> DeleteReferralReward(int id)
        {
            return await _repo.DeleteReferralReward(id);
        }

        public async Task<long> AddUser(string userId)
        {
            return await _repo.AddUser(userId);
        }

        public async Task<int> DeleteUser(string userId)
        {
            return await _repo.DeleteUser(userId);
        }

        public async Task<int> UpdateUser(WalletEntity e)
        {
            return await _repo.UpdateUser(e);
        }

        public async Task<int> UpdateRefferedStatus(int id)
        {
            return await _repo.UpdateRefferedStatus(id);
        }

        public async Task<IEnumerable<ReferralRewardEntity>> UsersShopCashbackHistory(string userId)
        {
            return await _repo.UsersShopCashbackHistory(userId);
        }

        public async Task<IEnumerable<ReferralRewardEntity>> UsersFoodchowCashbackHistory(string userId)
        {
            return await _repo.UsersFoodchowCashbackHistory(userId);
        }

        public async Task<IEnumerable<CampaignEntity>> ActiveCampaignsByShop(string shopId)
        {
            return await _repo.ActiveCampaignsByShop(shopId);
        }
    }
}
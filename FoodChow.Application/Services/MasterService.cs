using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class MasterService
    {
        private readonly IMasterRepository _repo;

        public MasterService(IMasterRepository masterRepository)
        {
            _repo = masterRepository;
        }

        public async Task<dynamic> GetCustomDomain(long shopId)
        {
            return await _repo.GetCustomDomain(shopId);
        }

        public async Task SaveCustomDomain(long shopId, string subdomain, string customDomain)
        {
            await _repo.SaveCustomDomain(shopId, subdomain, customDomain);
        }

        public async Task<int> CheckSubdomain(string subdomain)
        {
            return await _repo.CheckSubdomain(subdomain);
        }

        public async Task<int> CheckEmailVerified(string email)
        {
            return await _repo.CheckEmailVerified(email);
        }

        public async Task<string> GetStoreEmail(long shopId)
        {
            return await _repo.GetStoreEmail(shopId);
        }

        public async Task<long> SaveStoreSetupPhase1(MasterEntity model)
        {
            return await _repo.SaveStoreSetupPhase1(model);
        }

        public async Task<long> SaveStoreSetupFinal(MasterEntity model)
        {
            return await _repo.SaveStoreSetupFinal(model);
        }

        public async Task UpdateShopCname(long shopId, string domain)
        {
            await _repo.UpdateShopCname(shopId, domain);
        }

        public async Task<dynamic> GetAllBusinessTypes()
        {
            return await _repo.GetAllBusinessTypes();
        }

        public async Task AddPosServiceCharge(long shopId, double rate, string label)
        {
            await _repo.AddPosServiceCharge(shopId, rate, label);
        }

        public async Task UpdatePosServiceCharge(long shopId, double rate, string label)
        {
            await _repo.UpdatePosServiceCharge(shopId, rate, label);
        }

        public async Task<dynamic> GetAiMenuList()
        {
            return await _repo.GetAiMenuList();
        }

        public async Task UpdateAiMenuStatus(int id, int status)
        {
            await _repo.UpdateAiMenuStatus(id, status);
        }

        public async Task<dynamic> GetAiMenuByShopId(long shopId)
        {
            return await _repo.GetAiMenuByShopId(shopId);
        }

        public async Task<dynamic> GetShopDetails(string subdomain)
        {
            return await _repo.GetShopDetails(subdomain);
        }

        public async Task<dynamic> GetShopAddress(long shopId)
        {
            return await _repo.GetShopAddress(shopId);
        }

        public async Task<dynamic> GetShopSettings(long shopId)
        {
            return await _repo.GetShopSettings(shopId);
        }

        public async Task UpdateShopStatus(long shopId, int status)
        {
            await _repo.UpdateShopStatus(shopId, status);
        }

        public async Task<dynamic> GetPosServiceCharge(long shopId)
        {
            return await _repo.GetPosServiceCharge(shopId);
        }

        public async Task DeletePosServiceCharge(int id)
        {
            await _repo.DeletePosServiceCharge(id);
        }

        public async Task<int> GetDomainStatus(long shopId)
        {
            return await _repo.GetDomainStatus(shopId);
        }

        public async Task UpdateDomainStatus(long shopId, int status)
        {
            await _repo.UpdateDomainStatus(shopId, status);
        }

        public async Task DeleteAiMenu(int id)
        {
            await _repo.DeleteAiMenu(id);
        }

        public async Task<string> GetShopTimezone(long shopId)
        {
            return await _repo.GetShopTimezone(shopId);
        }
    }
}
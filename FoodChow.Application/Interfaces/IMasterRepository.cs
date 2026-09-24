using FoodChow.Application.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IMasterRepository
    {
        Task<dynamic> GetCustomDomain(long shopId);
        Task SaveCustomDomain(long shopId, string subdomain, string customDomain);

        Task<int> CheckSubdomain(string subdomain);

        Task<int> CheckEmailVerified(string email);

        Task<string> GetStoreEmail(long shopId);

        Task<long> SaveStoreSetupPhase1(MasterEntity model);

        Task<long> SaveStoreSetupFinal(MasterEntity model);

        Task UpdateShopCname(long shopId, string domain);

        Task<dynamic> GetAllBusinessTypes();

        Task AddPosServiceCharge(long shopId, double rate, string label);

        Task UpdatePosServiceCharge(long shopId, double rate, string label);

        Task<dynamic> GetAiMenuList();

        Task UpdateAiMenuStatus(int id, int status);

        Task<dynamic> GetAiMenuByShopId(long shopId);
        Task<dynamic> GetShopDetails(string subdomain);
        Task<dynamic> GetShopAddress(long shopId);
        Task<dynamic> GetShopSettings(long shopId);
        Task UpdateShopStatus(long shopId, int status);

        Task<dynamic> GetPosServiceCharge(long shopId);
        Task DeletePosServiceCharge(int id);

        Task<int> GetDomainStatus(long shopId);
        Task UpdateDomainStatus(long shopId, int status);

        Task DeleteAiMenu(int id);

        Task<string> GetShopTimezone(long shopId);
    }
}
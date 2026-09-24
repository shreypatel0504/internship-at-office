using Dapper;
using System.Data;
using FoodChow.Application.Interfaces;
using FoodChow.Application.Entities;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly MySqlDalc _dalc;

        public MasterRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<dynamic> GetCustomDomain(long shopId)
            => await _dalc.CreateConnection().QueryAsync("USP_GetCustomDomainAdmin",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task SaveCustomDomain(long shopId, string sub, string domain)
            => await _dalc.CreateConnection().ExecuteAsync("USP_SaveCustomDomainAdmin",
                new
                {
                    p_shop_id = shopId,
                    p_subdomain = sub,
                    p_custom_domain = domain
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> CheckSubdomain(string subdomain)
            => await _dalc.CreateConnection().ExecuteScalarAsync<int>(
                "USP_CheckSubdomainExists",
                new { p_subdomain = subdomain },
                commandType: CommandType.StoredProcedure);

        public async Task<int> CheckEmailVerified(string email)
            => await _dalc.CreateConnection().ExecuteScalarAsync<int>(
                "USP_CheckEmailVerified",
                new { p_email = email },
                commandType: CommandType.StoredProcedure);

        public async Task<string> GetStoreEmail(long shopId)
            => await _dalc.CreateConnection().ExecuteScalarAsync<string>(
                "USP_GetStoreEmail",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetAllBusinessTypes()
            => await _dalc.CreateConnection().QueryAsync(
                "USP_GetAllTypeOfBusiness",
                commandType: CommandType.StoredProcedure);

        public async Task AddPosServiceCharge(long shopId, double rate, string label)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddPosServiceCharge",
                new { p_shop_id = shopId, p_rate = rate, p_label = label },
                commandType: CommandType.StoredProcedure);

        public async Task UpdatePosServiceCharge(long shopId, double rate, string label)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePosServiceCharge",
                new { p_shop_id = shopId, p_rate = rate, p_label = label },
                commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetAiMenuList()
            => await _dalc.CreateConnection().QueryAsync(
                "USP_GetAiMenuAddList",
                commandType: CommandType.StoredProcedure);

        public async Task UpdateAiMenuStatus(int id, int status)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateAiMenuStatus",
                new { p_id = id, p_status = status },
                commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetAiMenuByShopId(long shopId)
            => await _dalc.CreateConnection().QueryAsync(
                "USP_GetAiMenuByShopId",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public Task<long> SaveStoreSetupPhase1(MasterEntity model) => Task.FromResult(0L);
        public Task<long> SaveStoreSetupFinal(MasterEntity model) => Task.FromResult(0L);
        public Task UpdateShopCname(long shopId, string domain) => Task.CompletedTask;

        public async Task<dynamic> GetShopDetails(string subdomain)
=> await _dalc.CreateConnection().QueryAsync("USP_GetShopDetails",
new { subdomain = subdomain }, commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetShopAddress(long shopId)
        => await _dalc.CreateConnection().QueryAsync("USP_GetShopAddress",
        new { p_shop_id = shopId }, commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetShopSettings(long shopId)
        => await _dalc.CreateConnection().QueryAsync("USP_GetShopSettings",
        new { p_shop_id = shopId }, commandType: CommandType.StoredProcedure);

        public async Task UpdateShopStatus(long shopId, int status)
        => await _dalc.CreateConnection().ExecuteAsync("USP_UpdateShopStatus",
        new { p_shop_id = shopId, p_status = status },
        commandType: CommandType.StoredProcedure);

        public async Task<dynamic> GetPosServiceCharge(long shopId)
        => await _dalc.CreateConnection().QueryAsync("USP_GetPosServiceCharge",
        new { p_shop_id = shopId },
        commandType: CommandType.StoredProcedure);

        public async Task DeletePosServiceCharge(int id)
        => await _dalc.CreateConnection().ExecuteAsync("USP_DeletePosServiceCharge",
        new { p_id = id },
        commandType: CommandType.StoredProcedure);

        public async Task<int> GetDomainStatus(long shopId)
        => await _dalc.CreateConnection().ExecuteScalarAsync<int>(
        "USP_GetDomainStatus",
        new { p_shop_id = shopId },
        commandType: CommandType.StoredProcedure);

        public async Task UpdateDomainStatus(long shopId, int status)
        => await _dalc.CreateConnection().ExecuteAsync("USP_UpdateDomainStatus",
        new { p_shop_id = shopId, p_status = status },
        commandType: CommandType.StoredProcedure);

        public async Task DeleteAiMenu(int id)
        => await _dalc.CreateConnection().ExecuteAsync("USP_DeleteAiMenu",
        new { p_id = id },
        commandType: CommandType.StoredProcedure);

        public async Task<string> GetShopTimezone(long shopId)
        => await _dalc.CreateConnection().ExecuteScalarAsync<string>(
        "USP_GetShopTimezone",
        new { p_shop_id = shopId },
        commandType: CommandType.StoredProcedure);
    }
}
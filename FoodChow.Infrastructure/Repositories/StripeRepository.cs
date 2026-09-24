using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class StripeRepository : IStripeRepository
    {
        private readonly MySqlDalc _dalc;

        public StripeRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<long> StripeCharges(StripeTransactionEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_StripeCharges",
                new
                {
                    p_shop_id = e.ShopId,
                    p_order_id = e.OrderId,
                    p_charge_id = e.ChargeId,
                    p_amount = e.Amount,
                    p_currency = e.Currency
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> StripeRefund(string chargeId)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_StripeRefund",
                new { p_charge_id = chargeId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> CreateStripeConnectAccount(StripeConnectAccountEntity e)
        {
            var parameters = new
            {
                p_shop_id = e.ShopId,
                p_account = e.Account,
                p_email = e.Email,
                p_country = e.Country,
                p_name = e.Name,
                p_refresh_token = e.RefreshToken,
                p_secret_key = e.SecretKey,
                p_publish_key = e.PublishKey
            };

            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_CreateStripeConnectAccount",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<StripeConnectAccountEntity>> CheckStripeAccount(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<StripeConnectAccountEntity>(
                "USP_CheckStripeAccount",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<StripePlatformEntity>> GetStripePlatform()
        {
            return await _dalc.CreateConnection().QueryAsync<StripePlatformEntity>(
                "USP_GetStripePlatform");
        }

        public async Task<IEnumerable<StripeTransactionEntity>> GetTodayReport()
            => await _dalc.CreateConnection().QueryAsync<StripeTransactionEntity>("USP_GetTodayStripeReport", commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<StripeTransactionEntity>> GetWeeklyReport()
            => await _dalc.CreateConnection().QueryAsync<StripeTransactionEntity>("USP_GetWeeklyStripeReport", commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<StripeTransactionEntity>> GetMonthlyReport()
            => await _dalc.CreateConnection().QueryAsync<StripeTransactionEntity>("USP_GetMonthlyStripeReport", commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<StripeTransactionEntity>> GetYearlyReport()
            => await _dalc.CreateConnection().QueryAsync<StripeTransactionEntity>("USP_GetYearlyStripeReport", commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateStripeAccountStatus(string shopId, int status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateStripeAccountStatus",
                new
                {
                    p_shop_id = shopId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ShopStripeEntity>> GetShopStripe(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<ShopStripeEntity>(
                "USP_GetShopStripe",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<StripeCountryEntity>> GetSupportedCountries()
        {
            return await _dalc.CreateConnection().QueryAsync<StripeCountryEntity>(
                "USP_GetSupportedCountries",
                commandType: CommandType.StoredProcedure);
        }
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class PaymentConfigurationRepository(MySqlDalc dalc) : IPaymentConfigurationRepository
    {
        // GET ALL BY SHOP
        public Task<IEnumerable<PaymentConfigurationDto>> GetByShopIdAsync(int shopId) =>
            dalc.ExecuteSpListAsync<PaymentConfigurationDto>(
                "USP_get_payment_configuration",
                new { p_shop_id = shopId });

        // GET BY ID
        public Task<PaymentConfigurationDto?> GetByIdAsync(int id, int shopId) =>
            dalc.ExecuteSpSingleAsync<PaymentConfigurationDto>(
                "USP_get_payment_configuration_by_id",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // ADD
        public Task<long> AddAsync(CreatePaymentConfigurationDto dto) =>
            dalc.ExecuteSpScalarAsync<long>(
                "USP_add_payment_configuration",
                new
                {
                    p_shop_id = dto.ShopId,
                    p_provider_name = dto.ProviderName ?? string.Empty,
                    p_api_key = dto.ApiKey ?? string.Empty,
                    p_api_secret = dto.ApiSecret ?? string.Empty,
                    p_merchant_id = dto.MerchantId ?? string.Empty,
                    p_currency = dto.Currency ?? "INR",
                    p_mode = dto.Mode ?? "Test",
                    p_extra_config = dto.ExtraConfig ?? string.Empty
                });

        // UPDATE
        public Task<int> UpdateAsync(UpdatePaymentConfigurationDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_update_payment_configuration",
                new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_provider_name = dto.ProviderName ?? string.Empty,
                    p_api_key = dto.ApiKey ?? string.Empty,
                    p_api_secret = dto.ApiSecret ?? string.Empty,
                    p_merchant_id = dto.MerchantId ?? string.Empty,
                    p_currency = dto.Currency ?? "INR",
                    p_mode = dto.Mode ?? "Test",
                    p_extra_config = dto.ExtraConfig ?? string.Empty,
                    p_is_active = dto.IsActive
                });

        // DELETE
        public Task<int> DeleteAsync(int id, int shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_delete_payment_configuration",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // GET ACTIVE BY SHOP
        public Task<IEnumerable<PaymentConfigurationDto>> GetActiveByShopIdAsync(int shopId) =>
            dalc.ExecuteSpListAsync<PaymentConfigurationDto>(
                "USP_get_active_payment_configuration",
                new { p_shop_id = shopId });

        // CHECK EXISTS
        public Task<bool> ExistsAsync(int shopId, string providerName) =>
            dalc.ExecuteSpScalarAsync<bool>(
                "USP_check_payment_configuration_exists",
                new
                {
                    p_shop_id = shopId,
                    p_provider_name = providerName
                });
    }
}
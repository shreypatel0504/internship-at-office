using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class PorterConfigurationRepository(MySqlDalc dalc)
        : IPorterConfigurationRepository
    {
        // =========================
        // GET ALL
        // =========================

        public async Task<IEnumerable<PorterConfigurationDto>> Get(long shopId)
        {
            var result = await dalc.ExecuteSpListAsync<PorterConfigurationDto>(
                "USP_get_porter_configuration",
                new
                {
                    p_shop_id = shopId
                });

            var configList = result.ToList();

            // 🔥 MOCK LOGIC (ADD HERE)
            var config = configList.FirstOrDefault();

            if (config != null && config.BaseUrl != null && config.BaseUrl.Contains("mock"))
            {
                return new List<PorterConfigurationDto>
             {
                new PorterConfigurationDto
                {
                    Id = config.Id,
                    ShopId = config.ShopId,
                    ApiKey = config.ApiKey,
                    ApiSecret = config.ApiSecret,
                    BaseUrl = config.BaseUrl,
                    IsActive = config.IsActive
                }
             };
            }

            return configList;
        }

        // =========================
        // GET BY ID
        // =========================

        public Task<PorterConfigurationDto?> GetById(
            long id,
            long shopId) =>

            dalc.ExecuteSpSingleAsync<PorterConfigurationDto>(
                "USP_get_porter_configuration_by_id",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // =========================
        // ADD
        // =========================

        public Task<long> Add(
            AddPorterConfigurationDto dto) =>

            dalc.ExecuteSpScalarAsync<long>(
                "USP_add_porter_configuration",
                new
                {
                    p_shop_id = dto.ShopId,
                    p_api_key = dto.ApiKey ?? "",
                    p_base_url = dto.BaseUrl ?? "",
                    p_customer_id = dto.CustomerId ?? "",
                    p_is_active = dto.IsActive
                });

        // =========================
        // UPDATE
        // =========================

        public async Task<bool> Update(
            UpdatePorterConfigurationDto dto)
        {
            var result = await dalc.ExecuteSpNonQueryAsync(
                "USP_update_porter_configuration",
                new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_api_key = dto.ApiKey ?? "",
                    p_base_url = dto.BaseUrl ?? "",
                    p_customer_id = dto.CustomerId ?? "",
                    p_is_active = dto.IsActive
                });

            return result > 0;
        }

        // =========================
        // DELETE
        // =========================

        public async Task<bool> Delete(
            long id,
            long shopId)
        {
            var result = await dalc.ExecuteSpNonQueryAsync(
                "USP_delete_porter_configuration",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

            return result > 0;
        }
    }
}
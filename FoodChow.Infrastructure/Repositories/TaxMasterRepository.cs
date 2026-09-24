using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class TaxMasterRepository(MySqlDalc dalc) : ITaxMasterRepository
    {
        // ✅ Get All
        public Task<IEnumerable<TaxMasterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<TaxMasterDto>(
                "USP_GetAllTaxMaster",
                new { p_shop_id = shopId });

        // ✅ Get By Id
        public Task<TaxMasterDto?> GetByIdAsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<TaxMasterDto>(
                "USP_GetTaxMasterById",
                new { p_id = id, p_shop_id = shopId });

        // ✅ Add
        public Task<long> AddAsync(AddTaxMasterDto dto) =>
            dalc.ExecuteSpScalarAsync<long>(
                "USP_AddTaxMaster", new
                {
                    p_shop_id = dto.ShopId,
                    p_tax_name = dto.TaxName ?? string.Empty,
                    p_tax_percentage = dto.TaxPercentage,
                    p_tax_type = dto.TaxType ?? string.Empty,
                    p_is_inclusive = dto.IsInclusive,
                    p_is_active = dto.IsActive
                });

        // ✅ Update
        public Task<int> UpdateAsync(UpdateTaxMasterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateTaxMaster", new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_tax_name = dto.TaxName ?? string.Empty,
                    p_tax_percentage = dto.TaxPercentage,
                    p_tax_type = dto.TaxType ?? string.Empty,
                    p_is_inclusive = dto.IsInclusive,
                    p_is_active = dto.IsActive
                });

        // ✅ Delete
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteTaxMaster",
                new { p_id = id, p_shop_id = shopId });
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class TaxMasterService(ITaxMasterRepository repo)
    {
        // ✅ Get All
        public async Task<ApiResponse<IEnumerable<TaxMasterDto>>> GetAllAsync(long shopId)
        {
            try
            {
                if (shopId <= 0)
                    return ApiResponse<IEnumerable<TaxMasterDto>>.Fail("Invalid shop_id.");

                var list = await repo.GetAllAsync(shopId);
                return ApiResponse<IEnumerable<TaxMasterDto>>.Ok(list);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<TaxMasterDto>>.Fail(ex.Message); }
        }

        // ✅ Get By Id
        public async Task<ApiResponse<TaxMasterDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<TaxMasterDto>.Fail("Invalid id.");

                var tax = await repo.GetByIdAsync(id, shopId);
                if (tax is null)
                    return ApiResponse<TaxMasterDto>.Fail("Tax not found.");

                return ApiResponse<TaxMasterDto>.Ok(tax);
            }
            catch (Exception ex) { return ApiResponse<TaxMasterDto>.Fail(ex.Message); }
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddTaxMasterDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.TaxName))
                    return ApiResponse<long>.Fail("Tax name is required.");

                if (dto.TaxPercentage < 0)
                    return ApiResponse<long>.Fail("Tax percentage cannot be negative.");

                var newId = await repo.AddAsync(dto);
                return ApiResponse<long>.Ok(newId, "Tax added successfully.");
            }
            catch (Exception ex) { return ApiResponse<long>.Fail(ex.Message); }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateTaxMasterDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (dto.ShopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.TaxName))
                    return ApiResponse<bool>.Fail("Tax name is required.");

                if (dto.TaxPercentage < 0)
                    return ApiResponse<bool>.Fail("Tax percentage cannot be negative.");

                await repo.UpdateAsync(dto);
                return ApiResponse<bool>.Ok(true, "Tax updated successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }

        // ✅ Delete
        public async Task<ApiResponse<bool>> DeleteAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (shopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                await repo.DeleteAsync(id, shopId);
                return ApiResponse<bool>.Ok(true, "Tax deleted successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }
    }
}
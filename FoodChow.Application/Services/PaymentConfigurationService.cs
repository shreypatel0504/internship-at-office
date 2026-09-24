using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class PaymentConfigurationService(IPaymentConfigurationRepository repo)
    {
        // ✅ 1 - Get By Shop
        public async Task<ApiResponse<object>> GetByShopIdAsync(int shopId)
        {
            try
            {
                var data = await repo.GetByShopIdAsync(shopId);
                return ApiResponse<object>.Ok(data, "Fetched Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 2 - Get By Id
        public async Task<ApiResponse<object>> GetByIdAsync(int id, int shopId)
        {
            try
            {
                var data = await repo.GetByIdAsync(id, shopId);
                return ApiResponse<object>.Ok(data, "Fetched Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 3 - Get Active
        public async Task<ApiResponse<object>> GetActiveByShopIdAsync(int shopId)
        {
            try
            {
                var data = await repo.GetActiveByShopIdAsync(shopId);
                return ApiResponse<object>.Ok(data, "Fetched Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 4 - Add
        public async Task<ApiResponse<object>> AddAsync(CreatePaymentConfigurationDto dto)
        {
            try
            {
                var exists = await repo.ExistsAsync(dto.ShopId, dto.ProviderName);

                if (exists)
                    return ApiResponse<object>.Fail("Payment provider already exists for this shop");

                var id = await repo.AddAsync(dto);

                return ApiResponse<object>.Ok(id, "Added Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 5 - Update
        public async Task<ApiResponse<object>> UpdateAsync(UpdatePaymentConfigurationDto dto)
        {
            try
            {
                var result = await repo.UpdateAsync(dto);

                if (result <= 0)
                    return ApiResponse<object>.Fail("Update Failed");

                return ApiResponse<object>.Ok("", "Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 6 - Delete
        public async Task<ApiResponse<object>> DeleteAsync(int id, int shopId)
        {
            try
            {
                var result = await repo.DeleteAsync(id, shopId);

                if (result <= 0)
                    return ApiResponse<object>.Fail("Delete Failed");

                return ApiResponse<object>.Ok("", "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }
    }
}
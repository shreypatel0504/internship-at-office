using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class RestaurantProfileService(IRestaurantProfileRepository repo)
    {
        // ✅ Get By ShopId
        public async Task<ApiResponse<RestaurantProfileDto>> GetByShopIdAsync(long shopId)
        {
            try
            {
                if (shopId <= 0)
                    return ApiResponse<RestaurantProfileDto>.Fail("Invalid shop_id.");

                var profile = await repo.GetByShopIdAsync(shopId);
                if (profile is null)
                    return ApiResponse<RestaurantProfileDto>.Fail("Restaurant profile not found.");

                return ApiResponse<RestaurantProfileDto>.Ok(profile);
            }
            catch (Exception ex) { return ApiResponse<RestaurantProfileDto>.Fail(ex.Message); }
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddRestaurantProfileDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.RestaurantName))
                    return ApiResponse<long>.Fail("Restaurant name is required.");

                if (string.IsNullOrWhiteSpace(dto.Phone))
                    return ApiResponse<long>.Fail("Phone is required.");

                var newId = await repo.AddAsync(dto);
                return ApiResponse<long>.Ok(newId, "Restaurant profile added successfully.");
            }
            catch (Exception ex) { return ApiResponse<long>.Fail(ex.Message); }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateRestaurantProfileDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (dto.ShopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.RestaurantName))
                    return ApiResponse<bool>.Fail("Restaurant name is required.");

                await repo.UpdateAsync(dto);
                return ApiResponse<bool>.Ok(true, "Restaurant profile updated successfully.");
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
                return ApiResponse<bool>.Ok(true, "Restaurant profile deleted successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }
    }
}
using Dapper;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class RestaurantProfileRepository(MySqlDalc dalc) : IRestaurantProfileRepository
    {

        // ✅ Get By ShopId
        public Task<RestaurantProfileDto?> GetByShopIdAsync(long shopId) =>
            dalc.ExecuteSpSingleAsync<RestaurantProfileDto>(
                "USP_GetRestaurantProfileByShopId",
                new { p_shop_id = shopId });

        // ✅ Add
        public async Task<long> AddAsync(AddRestaurantProfileDto dto)
        {
            var parameters = new DynamicParameters();

            parameters.Add("p_shop_id", dto.ShopId);
            parameters.Add("p_restaurant_name", dto.RestaurantName);
            parameters.Add("p_owner_name", dto.OwnerName);
            parameters.Add("p_email", dto.Email);
            parameters.Add("p_phone", dto.Phone);
            parameters.Add("p_alternate_phone", dto.AlternatePhone);
            parameters.Add("p_address", dto.Address);
            parameters.Add("p_city", dto.City);
            parameters.Add("p_state", dto.State);
            parameters.Add("p_country", dto.Country);
            parameters.Add("p_zip_code", dto.ZipCode);
            parameters.Add("p_logo", dto.Logo);
            parameters.Add("p_cover_image", dto.CoverImage);
            parameters.Add("p_cuisine_type", dto.CuisineType);

            // 🔥 THIS MUST EXIST
            parameters.Add("p_description", dto.Description);

            parameters.Add("p_website", dto.Website);
            parameters.Add("p_gst_number", dto.GstNumber);
            parameters.Add("p_fssai_number", dto.FssaiNumber);
            parameters.Add("p_delivery_radius", dto.DeliveryRadius);
            parameters.Add("p_min_order_amount", dto.MinOrderAmount);
            parameters.Add("p_delivery_charge", dto.DeliveryCharge);
            parameters.Add("p_is_active", dto.IsActive);

            return await dalc.ExecuteSpScalarAsync<long>(
                 "USP_AddRestaurantProfile",
                 parameters
             );
        }

        // ✅ Update
        public Task<int> UpdateAsync(UpdateRestaurantProfileDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateRestaurantProfile", new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_restaurant_name = dto.RestaurantName ?? string.Empty,
                    p_owner_name = dto.OwnerName ?? string.Empty,
                    p_email = dto.Email ?? string.Empty,
                    p_phone = dto.Phone ?? string.Empty,
                    p_alternate_phone = dto.AlternatePhone ?? string.Empty,
                    p_address = dto.Address ?? string.Empty,
                    p_city = dto.City ?? string.Empty,
                    p_state = dto.State ?? string.Empty,
                    p_country = dto.Country ?? string.Empty,
                    p_zip_code = dto.ZipCode ?? string.Empty,
                    p_logo = dto.Logo ?? string.Empty,
                    p_cover_image = dto.CoverImage ?? string.Empty,
                    p_cuisine_type = dto.CuisineType ?? string.Empty,
                    p_description = dto.Description ?? string.Empty,
                    p_website = dto.Website ?? string.Empty,
                    p_gst_number = dto.GstNumber ?? string.Empty,
                    p_fssai_number = dto.FssaiNumber ?? string.Empty,
                    p_delivery_radius = dto.DeliveryRadius,
                    p_min_order_amount = dto.MinOrderAmount,
                    p_delivery_charge = dto.DeliveryCharge,
                    p_is_active = dto.IsActive
                });

        // ✅ Delete
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteRestaurantProfile",
                new { p_id = id, p_shop_id = shopId });

        // ✅ Get Restaurant Information
        public Task<RestaurantProfileDto?> GetRestaurantInformation(long shopId) =>
            dalc.ExecuteSpSingleAsync<RestaurantProfileDto>(
                "USP_GetRestaurantInformation",
                new
                {
                    shop_id = shopId
                });
    }
}
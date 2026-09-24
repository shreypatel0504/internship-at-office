using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class FoodUserMasterRepository(MySqlDalc dalc) : IFoodUserMasterRepository
    {
        public Task<IEnumerable<FoodUserMasterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<FoodUserMasterDto>(
                "USP_GetAllFoodUsers",
                new { p_shop_id = shopId });

        public Task<FoodUserMasterDto?> GetByIdAsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<FoodUserMasterDto>(
                "USP_GetFoodUserById",
                new { p_id = id, p_shop_id = shopId });

        public Task<FoodUserMasterDto?> GetByEmailAsync(string email, long shopId) =>
            dalc.ExecuteSpSingleAsync<FoodUserMasterDto>(
                "USP_GetFoodUserByEmail",
                new { p_email = email, p_shop_id = shopId });

        public Task<long> RegisterAsync(RegisterUserDto dto) =>
            dalc.ExecuteSpScalarAsync<long>(
                "USP_RegisterFoodUser", new
                {
                    p_shop_id = dto.ShopId,
                    p_full_name = dto.FullName ?? string.Empty,
                    p_email = dto.Email ?? string.Empty,
                    p_phone = dto.Phone ?? string.Empty,
                    p_password = dto.Password ?? string.Empty,
                    p_device_token = dto.DeviceToken ?? string.Empty,
                    p_login_type = dto.LoginType ?? "Email"
                });

        public Task<int> UpdateAsync(UpdateUserDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateFoodUser", new
                {
                    p_id = dto.Id,
                    p_full_name = dto.FullName ?? string.Empty,
                    p_phone = dto.Phone ?? string.Empty,
                    p_profile_image = dto.ProfileImage ?? string.Empty,
                    p_device_token = dto.DeviceToken ?? string.Empty
                });

        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteFoodUser",
                new { p_id = id, p_shop_id = shopId });
    }
}
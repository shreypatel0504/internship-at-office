using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class UserMasterRepository(MySqlDalc dalc) : IUserMasterRepository
    {
        public Task<IEnumerable<UserMasterDTO>> GetAllUsersAsync() =>
            dalc.ExecuteSpListAsync<UserMasterDTO>("USP_GetAllUsers", new { });

        public Task<UserMasterDTO?> GetUserByIdAsync(long userId) =>
            dalc.ExecuteSpSingleAsync<UserMasterDTO>("USP_GetUserById",
                new { p_user_id = userId });

        // ✅ NEW: full row lookup by email (including password hash) - used by AuthService for JWT login
        public Task<UserMasterDTO?> GetUserByEmailAsync(string email) =>
            dalc.ExecuteSpSingleAsync<UserMasterDTO>("USP_GetUserByEmail",
                new { p_email = email });

        public Task<int> AddUserAsync(UserMasterDTO dto) =>
            dalc.ExecuteSpNonQueryAsync("USP_AddUser", new
            {
                p_first_name = dto.FirstName,
                p_last_name = dto.LastName,
                p_email = dto.Email,
                p_mobile_no = dto.MobileNo,
                p_password = dto.Password,
                p_role = dto.Role,
                //p_created_by = dto.CreatedBy
            });

        public Task<int> UpdateUserAsync(UserMasterDTO dto) =>
            dalc.ExecuteSpNonQueryAsync("USP_UpdateUser", new
            {
                p_user_id = dto.UserId,
                p_first_name = dto.FirstName,
                p_last_name = dto.LastName,
                p_email = dto.Email,
                p_mobile_no = dto.MobileNo,
                p_password = dto.Password,
                p_role = dto.Role,
                p_is_active = dto.IsActive,
                p_updated_by = dto.UpdatedBy
            });

        public Task<int> DeleteUserAsync(long userId) =>
            dalc.ExecuteSpNonQueryAsync("USP_DeleteUser",
                new { p_user_id = userId });

        public Task<int> ToggleUserStatusAsync(long userId, bool isActive, long updatedBy) =>
            dalc.ExecuteSpNonQueryAsync("USP_ToggleUserStatus", new
            {
                p_user_id = userId,
                p_is_active = isActive,
                p_updated_by = updatedBy
            });

        // ✅ Exact SP params: UserId, DeviceType, DeviceId, DeviceToken
        public Task<int> UpdateUserTokenAsync(long userId, string deviceType, string deviceId, string deviceToken) =>
            dalc.ExecuteSpNonQueryAsync("USP_UserUpdateToken", new
            {
                UserId = userId,
                DeviceType = deviceType,
                DeviceId = deviceId,
                DeviceToken = deviceToken
            });

        // ✅ Exact SP params: Emailid, Password
        public Task<dynamic> PerformUserLoginAsync(string mobileNo, string password) =>
            dalc.ExecuteSpSingleAsync<dynamic>("USP_UserLogin", new
            {
                Emailid = mobileNo,
                Password = password
            });

        public Task<int> PerformUserSignupAsync(UserMasterDTO dto) =>
            dalc.ExecuteSpNonQueryAsync("USP_PerformUserSignup", new
            {
                p_first_name = dto.FirstName,
                p_last_name = dto.LastName,
                p_email = dto.Email,
                p_mobile_no = dto.MobileNo,
                p_password = dto.Password,
                p_device_type = dto.DeviceType,
                p_device_id = dto.DeviceId,
                p_device_token = dto.DeviceToken,
                //p_created_by = dto.CreatedBy
            });

        // ✅ Exact SP params: p_email, login_type
        public Task<dynamic> PerformSocialLoginAsync(string email, string loginType) =>
     dalc.ExecuteSpSingleAsync<dynamic>("PerformUserLoginWithSocialMedia", new
     {
         p_user_email = email,
         p_login_type = loginType
     });

        // ✅ Exact SP param: m_no
        public Task<dynamic> CheckUserExistsAsync(string mobileNo) =>
            dalc.ExecuteSpSingleAsync<dynamic>("USP_CheckUserMobileNoExists",
                new { m_no = mobileNo });

        // ✅ Exact SP param: p_email
        public Task<dynamic> CheckUserEmailExistsAsync(string email) =>
            dalc.ExecuteSpSingleAsync<dynamic>("USP_CheckUserEmailExists",
                new { p_email = email });
    }
}
using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IUserMasterRepository
    {
        // =========================
        // USER CRUD
        // =========================
        Task<IEnumerable<UserMasterDTO>> GetAllUsersAsync();

        Task<UserMasterDTO?> GetUserByIdAsync(long userId);

        // NEW: full row lookup by email, including the password hash column.
        // Used by AuthService for JWT login (never expose the Password field to clients).
        Task<UserMasterDTO?> GetUserByEmailAsync(string email);

        Task<int> AddUserAsync(UserMasterDTO dto);

        Task<int> UpdateUserAsync(UserMasterDTO dto);

        Task<int> DeleteUserAsync(long userId);

        Task<int> ToggleUserStatusAsync(long userId, bool isActive, long updatedBy);

        // =========================
        // AUTH / LOGIN / SIGNUP
        // =========================
        Task<int> UpdateUserTokenAsync(
            long userId,
            string deviceType,
            string deviceId,
            string deviceToken);

        Task<dynamic> PerformUserLoginAsync(
            string mobileNo,
            string password);

        Task<int> PerformUserSignupAsync(
            UserMasterDTO dto);

        Task<dynamic> PerformSocialLoginAsync(
            string email,
            string loginType);

        // =========================
        // CHECK USER EXISTS
        // =========================
        Task<dynamic> CheckUserExistsAsync(
            string mobileNo);

        Task<dynamic> CheckUserEmailExistsAsync(
            string email);


    }
}
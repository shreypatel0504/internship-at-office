using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class UserMasterService
    {
        private readonly IUserMasterRepository repo;

        public UserMasterService(IUserMasterRepository repo)
        {
            this.repo = repo;
        }

        // =========================
        // GET ALL USERS
        // =========================
        public async Task<ApiResponse<object>> GetAllUsersAsync()
        {
            try
            {
                var data = await repo.GetAllUsersAsync();

                return ApiResponse<object>.Ok(data, "Success");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // GET USER BY ID
        // =========================
        public async Task<ApiResponse<object>> GetUserByIdAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<object>.Fail("Invalid User Id");

                var data = await repo.GetUserByIdAsync(userId);

                if (data == null)
                    return ApiResponse<object>.Fail("User Not Found");

                return ApiResponse<object>.Ok(data, "Success");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // ADD USER
        // =========================
        public async Task<ApiResponse<object>> AddUserAsync(UserMasterDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.FirstName))
                    return ApiResponse<object>.Fail("First Name Required");

                if (string.IsNullOrWhiteSpace(dto.Email))
                    return ApiResponse<object>.Fail("Email Required");

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return ApiResponse<object>.Fail("Password Required");

                await repo.AddUserAsync(dto);

                return ApiResponse<object>.Ok(
                    "",
                    "User Added Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // UPDATE USER
        // =========================
        public async Task<ApiResponse<object>> UpdateUserAsync(UserMasterDTO dto)
        {
            try
            {
                if (dto.UserId <= 0)
                    return ApiResponse<object>.Fail("Invalid User Id");

                await repo.UpdateUserAsync(dto);

                return ApiResponse<object>.Ok(
                    "",
                    "User Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // DELETE USER
        // =========================
        public async Task<ApiResponse<object>> DeleteUserAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<object>.Fail("Invalid User Id");

                await repo.DeleteUserAsync(userId);

                return ApiResponse<object>.Ok(
                    "",
                    "User Deleted Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // TOGGLE USER STATUS
        // =========================
        public async Task<ApiResponse<object>> ToggleUserStatusAsync(
            long userId,
            bool isActive,
            long updatedBy)
        {
            try
            {
                if (userId <= 0)
                    return ApiResponse<object>.Fail("Invalid User Id");

                await repo.ToggleUserStatusAsync(
                    userId,
                    isActive,
                    updatedBy);

                return ApiResponse<object>.Ok(
                    "",
                    "Status Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }
    }
}
using BCrypt.Net;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class FoodUserMasterService
    {
        private readonly IFoodUserMasterRepository repo;

        public FoodUserMasterService(IFoodUserMasterRepository repo)
        {
            this.repo = repo;
        }

        // ✅ Get All Users
        public async Task<ApiResponse<IEnumerable<FoodUserMasterDto>>> GetAllAsync(long shopId)
        {
            try
            {
                var list = await repo.GetAllAsync(shopId);

                return ApiResponse<IEnumerable<FoodUserMasterDto>>.Ok(
                    list,
                    "Users fetched successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FoodUserMasterDto>>.Fail(ex.Message);
            }
        }

        // ✅ Get User By Id
        public async Task<ApiResponse<FoodUserMasterDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                var user = await repo.GetByIdAsync(id, shopId);

                if (user == null)
                    return ApiResponse<FoodUserMasterDto>.Fail("User not found.");

                return ApiResponse<FoodUserMasterDto>.Ok(
                    user,
                    "User fetched successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<FoodUserMasterDto>.Fail(ex.Message);
            }
        }

        // ✅ Register User
        public async Task<ApiResponse<long>> RegisterAsync(RegisterUserDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.FullName))
                    return ApiResponse<long>.Fail("Full name is required.");

                if (string.IsNullOrWhiteSpace(dto.Email))
                    return ApiResponse<long>.Fail("Email is required.");

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return ApiResponse<long>.Fail("Password is required.");

                // ✅ Check Existing User
                var existingUser = await repo.GetByEmailAsync(dto.Email, dto.ShopId);

                if (existingUser != null)
                    return ApiResponse<long>.Fail("Email already registered.");

                // ✅ Hash Password
                dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                // ✅ Save User
                var newId = await repo.RegisterAsync(dto);

                return ApiResponse<long>.Ok(
                    newId,
                    "User registered successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<long>.Fail(ex.Message);
            }
        }

        // ✅ Login User
        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginUserDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Email))
                    return ApiResponse<LoginResponseDto>.Fail("Email is required.");

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return ApiResponse<LoginResponseDto>.Fail("Password is required.");

                // ✅ Find User
                var user = await repo.GetByEmailAsync(dto.Email, dto.ShopId);

                if (user == null)
                    return ApiResponse<LoginResponseDto>.Fail("Invalid email or password.");

                // ✅ Verify Password
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

                if (!isValidPassword)
                    return ApiResponse<LoginResponseDto>.Fail("Invalid email or password.");

                // ✅ Response
                var response = new LoginResponseDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Phone = user.Phone,
                    ProfileImage = user.ProfileImage
                };

                return ApiResponse<LoginResponseDto>.Ok(
                    response,
                    "Login successful."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<LoginResponseDto>.Fail(ex.Message);
            }
        }

        // ✅ Update User
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateUserDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid user id.");

                await repo.UpdateAsync(dto);

                return ApiResponse<bool>.Ok(
                    true,
                    "User updated successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }

        // ✅ Delete User
        public async Task<ApiResponse<bool>> DeleteAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<bool>.Fail("Invalid user id.");

                await repo.DeleteAsync(id, shopId);

                return ApiResponse<bool>.Ok(
                    true,
                    "User deleted successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }
    }
}
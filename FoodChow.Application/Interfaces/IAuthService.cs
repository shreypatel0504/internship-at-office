using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
        Task<ApiResponse<AuthResponseDto>> LoginAsync(AuthLoginRequestDto dto);
        Task<ApiResponse<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto dto);
        Task<ApiResponse<bool>> RevokeTokenAsync(string refreshToken);
    }
}
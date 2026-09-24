using System.Security.Claims;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserMasterRepository _users;
        private readonly IRefreshTokenRepository _refreshTokens;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenService _jwt;

        public AuthService(
            IUserMasterRepository users,
            IRefreshTokenRepository refreshTokens,
            IPasswordHasher hasher,
            IJwtTokenService jwt)
        {
            _users = users;
            _refreshTokens = refreshTokens;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return ApiResponse<AuthResponseDto>.Fail("Email and password are required.");

            if (dto.Password.Length < 6)
                return ApiResponse<AuthResponseDto>.Fail("Password must be at least 6 characters long.");

            var existing = await _users.GetUserByEmailAsync(dto.Email);
            if (existing is not null)
                return ApiResponse<AuthResponseDto>.Fail("Email is already registered.");

            var newUser = new UserMasterDTO
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                MobileNo = dto.MobileNo,
                Password = _hasher.Hash(dto.Password),
                Role = string.IsNullOrWhiteSpace(dto.Role) ? "Staff" : dto.Role
            };

            await _users.AddUserAsync(newUser);

            var created = await _users.GetUserByEmailAsync(dto.Email);
            if (created is null)
                return ApiResponse<AuthResponseDto>.Fail("User was created but could not be reloaded.");

            return await IssueTokensAsync(created);
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(AuthLoginRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return ApiResponse<AuthResponseDto>.Fail("Email and password are required.");

            var user = await _users.GetUserByEmailAsync(dto.Email);

            if (user is null || string.IsNullOrEmpty(user.Password))
                return ApiResponse<AuthResponseDto>.Fail("Invalid email or password.");

            if (!user.IsActive)
                return ApiResponse<AuthResponseDto>.Fail("This account has been deactivated.");

            if (!_hasher.Verify(dto.Password, user.Password))
                return ApiResponse<AuthResponseDto>.Fail("Invalid email or password.");

            return await IssueTokensAsync(user);
        }

        public async Task<ApiResponse<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var principal = _jwt.GetPrincipalFromExpiredToken(dto.AccessToken);
            if (principal is null)
                return ApiResponse<AuthResponseDto>.Fail("Invalid access token.");

            var stored = await _refreshTokens.GetActiveAsync(dto.RefreshToken);
            if (stored is null || !stored.IsActive)
                return ApiResponse<AuthResponseDto>.Fail("Refresh token is invalid or has expired.");

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim is null || !long.TryParse(userIdClaim, out var claimedUserId) || claimedUserId != stored.UserId)
                return ApiResponse<AuthResponseDto>.Fail("Token mismatch.");

            var user = await _users.GetUserByIdAsync(stored.UserId);
            if (user is null || !user.IsActive)
                return ApiResponse<AuthResponseDto>.Fail("User no longer exists or is inactive.");

            await _refreshTokens.RevokeAsync(dto.RefreshToken);

            return await IssueTokensAsync(user);
        }

        public async Task<ApiResponse<bool>> RevokeTokenAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return ApiResponse<bool>.Fail("Refresh token is required.");

            await _refreshTokens.RevokeAsync(refreshToken);
            return ApiResponse<bool>.Ok(true, "Logged out successfully.");
        }

        private async Task<ApiResponse<AuthResponseDto>> IssueTokensAsync(UserMasterDTO user)
        {
            var role = string.IsNullOrWhiteSpace(user.Role) ? "Staff" : user.Role!;
            var fullName = $"{user.FirstName} {user.LastName}".Trim();

            var tokens = _jwt.GenerateTokens(user.UserId, user.Email ?? string.Empty, role, fullName);

            await _refreshTokens.SaveAsync(user.UserId, tokens.RefreshToken, tokens.RefreshTokenExpiresAtUtc);

            var response = new AuthResponseDto
            {
                AccessToken = tokens.AccessToken,
                AccessTokenExpiresAtUtc = tokens.AccessTokenExpiresAtUtc,
                RefreshToken = tokens.RefreshToken,
                User = new AuthUserDto
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Role = role
                }
            };

            return ApiResponse<AuthResponseDto>.Ok(response, "Success.");
        }
    }
}
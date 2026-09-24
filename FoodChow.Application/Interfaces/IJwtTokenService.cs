using System.Security.Claims;

namespace FoodChow.Application.Interfaces
{
    public class TokenResult
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiresAtUtc { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiresAtUtc { get; set; }
    }

    public interface IJwtTokenService
    {
        TokenResult GenerateTokens(long userId, string email, string role, string fullName);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string expiredAccessToken);
    }
}
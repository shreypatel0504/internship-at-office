using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class RefreshTokenRepository(MySqlDalc dalc) : IRefreshTokenRepository
    {
        public Task SaveAsync(long userId, string token, DateTime expiresAtUtc) =>
            dalc.ExecuteSpNonQueryAsync("USP_SaveRefreshToken", new
            {
                p_user_id = userId,
                p_token = token,
                p_expires_at = expiresAtUtc
            });

        public Task<RefreshTokenRecord?> GetActiveAsync(string token) =>
            dalc.ExecuteSpSingleAsync<RefreshTokenRecord>("USP_GetRefreshToken", new { p_token = token });

        public Task RevokeAsync(string token) =>
            dalc.ExecuteSpNonQueryAsync("USP_RevokeRefreshToken", new { p_token = token });

        public Task RevokeAllForUserAsync(long userId) =>
            dalc.ExecuteSpNonQueryAsync("USP_RevokeAllUserRefreshTokens", new { p_user_id = userId });
    }
}
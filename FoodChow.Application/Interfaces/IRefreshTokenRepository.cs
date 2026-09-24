namespace FoodChow.Application.Interfaces
{
    public class RefreshTokenRecord
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public bool IsActive => RevokedAt == null && ExpiresAt > DateTime.UtcNow;
    }

    public interface IRefreshTokenRepository
    {
        Task SaveAsync(long userId, string token, DateTime expiresAtUtc);
        Task<RefreshTokenRecord?> GetActiveAsync(string token);
        Task RevokeAsync(string token);
        Task RevokeAllForUserAsync(long userId);
    }
}
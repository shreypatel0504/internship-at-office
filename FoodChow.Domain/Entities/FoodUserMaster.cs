namespace FoodChow.Domain.Entities
{
    public class FoodUserMaster
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; }
        public string? ProfileImage { get; set; }
        public string? DeviceToken { get; set; }
        public string? LoginType { get; set; }   // "Email" | "Google" | "Facebook"
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
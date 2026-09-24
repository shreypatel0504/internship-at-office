namespace FoodChow.Application.DTOs
{
    public class FoodUserMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; }
        public string? ProfileImage { get; set; }
        public string? DeviceToken { get; set; }
        public string? LoginType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class RegisterUserDto
    {
        public long ShopId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? DeviceToken { get; set; }
        public string? LoginType { get; set; }
    }

    public class LoginUserDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public long ShopId { get; set; }
    }

    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImage { get; set; }
        public string? DeviceToken { get; set; }
    }

    public class LoginResponseDto
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImage { get; set; }
        public string? Token { get; set; }
    }
}
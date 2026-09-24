namespace FoodChow.Application.DTOs
{
    public class UserMasterDTO
    {
        public long UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? MobileNo { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public bool IsActive { get; set; }

        public long CreatedBy { get; set; }

        public long UpdatedBy { get; set; }

        // =========================
        // DEVICE DETAILS
        // =========================
        public string? DeviceType { get; set; }

        public string? DeviceId { get; set; }

        public string? DeviceToken { get; set; }
    }
}
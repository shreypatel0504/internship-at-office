namespace FoodChow.Domain.Entities
{
    public class RestaurantProfile
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? RestaurantName { get; set; }
        public string? OwnerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? Logo { get; set; }
        public string? CoverImage { get; set; }
        public string? CuisineType { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
        public string? GstNumber { get; set; }
        public string? FssaiNumber { get; set; }
        public decimal? DeliveryRadius { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
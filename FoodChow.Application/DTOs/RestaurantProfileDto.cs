namespace FoodChow.Application.DTOs
{
    public class RestaurantProfileDto
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

    public class AddRestaurantProfileDto
    {
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
    }

    public class UpdateRestaurantProfileDto
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
    }

    // Ye existing file me add karo

    public class ShopOwnerInfoDto
    {
        public long ShopId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OwnerEmail { get; set; }
        public string? PhoneNo { get; set; }
        public string? PromoCode { get; set; }
        public string? CountryCode { get; set; }
    }

    public class ShopInfoDto
    {
        public long ShopId { get; set; }
        public string? ShopName { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? CountryCode { get; set; }
        public string? Timezone { get; set; }
        public string? Subdomain { get; set; }
        public string? ShopLogo { get; set; }
        public string? ShopType { get; set; }
        public string? CuisineType { get; set; }
        public string? BusinessTypeId { get; set; }
        public string? InstaUrl { get; set; }
    }

    public class ShopAddressDto
    {
        public long Id { get; set; }
        public string? HouseNo { get; set; }
        public string? Address { get; set; }
        public string? Address1 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Pincode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }

    public class ShopTimingsModelDto
    {
        public long ShopId { get; set; }
        public long PartnerId { get; set; }
        public List<ShopTimeDto> LstShopTimings { get; set; } = new();
    }

    public class ShopTimeDto
    {
        public long ShopId { get; set; }
        public string? DaysName { get; set; }
        public string? OpenTime1 { get; set; }
        public string? CloseTime1 { get; set; }
        public string? OpenTime2 { get; set; }
        public string? CloseTime2 { get; set; }
        public string? OpenTime3 { get; set; }
        public string? CloseTime3 { get; set; }
        public int CloseDay { get; set; }
        public int HrsDay { get; set; }
    }
}
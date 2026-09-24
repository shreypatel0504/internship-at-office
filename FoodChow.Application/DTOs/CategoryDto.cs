namespace FoodChow.Application.DTOs
{
    public class CategoryDto
    {
        public long CategoryId { get; set; }
        public long ShopId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
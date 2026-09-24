namespace FoodChow.Domain.Entities
{
    public class Category
    {
        public long CategoryId { get; set; }
        public long ShopId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public bool IsActive { get; set; }
    }
}
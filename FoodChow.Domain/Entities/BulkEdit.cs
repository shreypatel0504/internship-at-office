namespace FoodChow.Domain.Entities
{
    public class BulkEdit
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public long ItemId { get; set; }
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
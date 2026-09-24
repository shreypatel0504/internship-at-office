namespace FoodChow.Domain.Entities
{
    public class TaxMaster
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public string? TaxType { get; set; }       // "GST" | "VAT" | "Service Tax"
        public bool IsInclusive { get; set; }      // true = Inclusive | false = Exclusive
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
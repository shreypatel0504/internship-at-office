namespace FoodChow.Application.DTOs
{
    public class TaxMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public string? TaxType { get; set; }
        public bool IsInclusive { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AddTaxMasterDto
    {
        public long ShopId { get; set; }
        public string? TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public string? TaxType { get; set; }
        public bool IsInclusive { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateTaxMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public string? TaxType { get; set; }
        public bool IsInclusive { get; set; }
        public bool IsActive { get; set; }
    }
}
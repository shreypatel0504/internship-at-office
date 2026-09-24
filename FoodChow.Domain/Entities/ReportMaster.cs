namespace FoodChow.Domain.Entities
{
    public class ReportMaster
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }     // "Sales" | "Order" | "Item" | "Customer"
        public string? ReportFormat { get; set; }   // "PDF" | "Excel" | "CSV"
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Status { get; set; }         // "Pending" | "Generated" | "Failed"
        public string? FilePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
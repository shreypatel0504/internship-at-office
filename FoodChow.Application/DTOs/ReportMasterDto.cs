namespace FoodChow.Application.DTOs
{
    public class ReportMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public string? ReportFormat { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Status { get; set; }
        public string? FilePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AddReportMasterDto
    {
        public long ShopId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public string? ReportFormat { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Status { get; set; }
        public string? FilePath { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateReportMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public string? ReportFormat { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Status { get; set; }
        public string? FilePath { get; set; }
        public bool IsActive { get; set; }
    }

    public class ReportFilterDto
    {
        public long ShopId { get; set; }
        public string? ReportType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
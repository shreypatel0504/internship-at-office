namespace FoodChow.Domain.Entities
{
    public class Printer
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? PrinterName { get; set; }
        public string? PrinterIp { get; set; }
        public int PrinterPort { get; set; }
        public string? PrinterType { get; set; }   // "Network" | "USB" | "Bluetooth"
        public string? PaperSize { get; set; }     // "58mm" | "80mm"
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
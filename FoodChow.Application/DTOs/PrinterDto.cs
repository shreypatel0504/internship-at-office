namespace FoodChow.Application.DTOs
{
    // ✅ Printer CRUD DTOs
    public class PrinterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? PrinterName { get; set; }
        public string? PrinterIp { get; set; }
        public int PrinterPort { get; set; }
        public string? PrinterType { get; set; }
        public string? PaperSize { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AddPrinterDto
    {
        public long ShopId { get; set; }
        public string? PrinterName { get; set; }
        public string? PrinterIp { get; set; }
        public int PrinterPort { get; set; }
        public string? PrinterType { get; set; }
        public string? PaperSize { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdatePrinterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? PrinterName { get; set; }
        public string? PrinterIp { get; set; }
        public int PrinterPort { get; set; }
        public string? PrinterType { get; set; }
        public string? PaperSize { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }

    // ✅ Template DTOs
    public class UpdateTemplateDto
    {
        public List<FieldDetailDto> FieldDetails { get; set; } = new();
    }

    public class FieldDetailDto
    {
        public int FieldId { get; set; }

        public int SectionId { get; set; }

        public string LabelName { get; set; }

        public string TagName { get; set; }

        public int Position { get; set; }

        public string Alignment { get; set; }

        public string FontSize { get; set; }

        public string FontStyle { get; set; }

        public string Width { get; set; }

        public string DefaultValue { get; set; }

        public int Column { get; set; }

        public int DisplayPosition { get; set; }
    }

    // ✅ Field Position DTO
    public class FieldPositionUpdateDto
    {
        public List<int> FieldIds { get; set; } = new();
        public int DisplayPosition { get; set; }
    }
}
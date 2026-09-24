namespace FoodChow.Application.DTOs
{
    public class UpdateKdsTerminalSettingDto
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string? TerminalName { get; set; }

        public string? PrinterName { get; set; }

        public string? IpAddress { get; set; }

        public string? PortNo { get; set; }

        public bool IsActive { get; set; }
    }
}
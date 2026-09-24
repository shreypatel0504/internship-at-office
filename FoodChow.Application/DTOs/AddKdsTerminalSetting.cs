namespace FoodChow.Application.DTOs
{
    public class AddKdsTerminalSettingDto
    {
        public long ShopId { get; set; }

        public string? TerminalName { get; set; }

        public string? TerminalCode { get; set; }

        public string? IpAddress { get; set; }

        public int Port { get; set; }

        public bool IsActive { get; set; }
    }
}
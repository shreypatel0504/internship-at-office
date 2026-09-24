namespace FoodChow.Domain.Entities
{
    public class KdsTerminalsSetting
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string TerminalName { get; set; } = string.Empty;

        public string TerminalCode { get; set; } = string.Empty;

        public string IpAddress { get; set; } = string.Empty;

        public int Port { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
namespace FoodChow.Domain.Entities
{
    public class StoreTimingsMaster
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string? DaysName { get; set; }      // "Monday" | "Tuesday" | ...
        public string? OpenTime1 { get; set; }
        public string? CloseTime1 { get; set; }
        public string? OpenTime2 { get; set; }
        public string? CloseTime2 { get; set; }
        public string? OpenTime3 { get; set; }
        public string? CloseTime3 { get; set; }
        public int CloseDay { get; set; }          // 0 = Open | 1 = Closed
        public int HrsDay { get; set; }            // 0 = Normal | 1 = 24hrs
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
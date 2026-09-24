namespace FoodChow.Application.DTOs
{
    // =========================
    // BASE DTO
    // =========================
    public class StoreTimingsMasterDto
    {
        public long Id { get; set; }
        public long ShopId { get; set; }

        public string? DaysName { get; set; }

        public TimeSpan? OpenTime1 { get; set; }
        public TimeSpan? CloseTime1 { get; set; }

        public TimeSpan? OpenTime2 { get; set; }
        public TimeSpan? CloseTime2 { get; set; }

        public TimeSpan? OpenTime3 { get; set; }
        public TimeSpan? CloseTime3 { get; set; }

        public int CloseDay { get; set; }
        public int HrsDay { get; set; }
        public bool IsActive { get; set; }
    }

    // =========================
    // ADD DTO
    // =========================
    public class AddStoreTimingsMasterDto
    {
        public long ShopId { get; set; }

        public string? DaysName { get; set; }

        public TimeSpan? OpenTime1 { get; set; }
        public TimeSpan? CloseTime1 { get; set; }

        public TimeSpan? OpenTime2 { get; set; }
        public TimeSpan? CloseTime2 { get; set; }

        public TimeSpan? OpenTime3 { get; set; }
        public TimeSpan? CloseTime3 { get; set; }

        public int CloseDay { get; set; }
        public int HrsDay { get; set; }
        public bool IsActive { get; set; } = true;   // ⭐ default safe
    }

    // =========================
    // UPDATE DTO
    // =========================
    public class UpdateStoreTimingsMasterDto
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string? DaysName { get; set; }

        public TimeSpan? OpenTime1 { get; set; }
        public TimeSpan? CloseTime1 { get; set; }

        public TimeSpan? OpenTime2 { get; set; }
        public TimeSpan? CloseTime2 { get; set; }

        public TimeSpan? OpenTime3 { get; set; }
        public TimeSpan? CloseTime3 { get; set; }

        public int CloseDay { get; set; }
        public int HrsDay { get; set; }
        public bool IsActive { get; set; }
    }

    // =========================
    // BULK DTO
    // =========================
    public class BulkStoreTimingsDto
    {
        public long ShopId { get; set; }

        public List<AddStoreTimingsMasterDto> TimingsList { get; set; }
            = new List<AddStoreTimingsMasterDto>();   // ⭐ safe init
    }
}
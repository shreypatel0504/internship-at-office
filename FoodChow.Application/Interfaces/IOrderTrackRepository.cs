namespace FoodChow.Application.Interfaces
{
    public class OrderTrackMainRow
    {
        public long id { get; set; }
        public string? external_order_id { get; set; }
        public string? status { get; set; }
        public bool is_scheduled { get; set; }
        public DateTime? schedule_date { get; set; }
        public double distance { get; set; }
        public double estimated_duration { get; set; }
        public double total_amount { get; set; }
        public double total_payable_amount { get; set; }
        public string? vehicle_name { get; set; }
        public double vehicle_weight { get; set; }
    }

    public class OrderTrackStopRow
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string? address { get; set; }
        public string? near_by_landmark { get; set; }
        public string? pincode { get; set; }
        public string? other_location_text { get; set; }
        public string? unit_number { get; set; }
        public string? sender_name { get; set; }
        public string? sender_number { get; set; }
        public string? city { get; set; }
        public int stop_order { get; set; }
    }

    public class OrderTrackGoodsRow
    {
        public string? goods_type { get; set; }
    }

    public class OrderTrackHistoryRow
    {
        public string? status_from { get; set; }
        public string? status_to { get; set; }
        public DateTime created_date { get; set; }
        public string? changed_by { get; set; }
        public string? change_reason { get; set; }
    }

    public class OrderTrackRawResult
    {
        public OrderTrackMainRow? Main { get; set; }
        public List<OrderTrackStopRow> Stops { get; set; } = new();
        public List<OrderTrackGoodsRow> Goods { get; set; } = new();
        public List<OrderTrackHistoryRow> History { get; set; } = new();
    }

    public interface IOrderTrackRepository
    {
        Task<OrderTrackRawResult?> GetOrderTrackingAsync(string externalOrderId);
    }
}
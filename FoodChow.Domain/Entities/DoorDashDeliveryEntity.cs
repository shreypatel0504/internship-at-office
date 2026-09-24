using System;

namespace FoodChow.Domain.Entities
{
    public class DoorDashDeliveryEntity
    {
        public long id { get; set; }

        public string shop_id { get; set; }

        public string foodchow_order_id { get; set; }

        public string external_quote_id { get; set; }

        public string external_delivery_id { get; set; }

        public string currency { get; set; }

        public string delivery_status { get; set; }

        public decimal? deliveryfee { get; set; }

        public string tracking_url { get; set; }

        public string updated_at { get; set; }

        public string quote_object { get; set; }

        public string create_object { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? updated_date { get; set; }
    }
}
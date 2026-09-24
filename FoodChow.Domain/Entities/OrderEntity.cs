namespace FoodChow.Domain.Entities
{
    public class OrderEntity
    {
        public long shop_id { get; set; }

        public double amount { get; set; }

        public double charges { get; set; }

        public double payment_charges { get; set; }

        public double decimal_point { get; set; }

        public double total_amount { get; set; }

        public string? payment_method { get; set; }

        public string? delivery_method { get; set; }

        public DateTime trans_date { get; set; }

        public string? trans_method { get; set; }

        public string? table_no { get; set; }

        public long user_id { get; set; }

        public long guest_id { get; set; }

        public string? notes { get; set; }

        public long order_status { get; set; }

        public string? ipaddress { get; set; }

        public int device_type { get; set; }

        public string? device_id { get; set; }

        public string? device_token { get; set; }

        public DateTime approved_declined_time { get; set; }

        public DateTime dispatched_time { get; set; }

        public DateTime delivered_time { get; set; }

        public DateTime updated_date { get; set; }

        public double discounted_amount { get; set; }

        public double discount { get; set; }

        public string? couponcode { get; set; }

        public string? delivery_datetime { get; set; }

        public string? order_menu_type { get; set; }

        public string? order_status_time { get; set; }

        public long delivery_partner_id { get; set; }

        public string? v_type { get; set; }

        public string? v_number { get; set; }

        public long token_no { get; set; }

        public string? extra_charge_label { get; set; }
    }

    public class OrderItemEntity
    {
        public long trans_id { get; set; }
        public string order_id { get; set; }
        public long item_id { get; set; }
        public string item_name { get; set; }
        public string item_size { get; set; }
        public double quantity { get; set; }
        public double single_price { get; set; }
        public double with_customize_price { get; set; }
        public double amount { get; set; }
        public string custom_details { get; set; }
        public string item_note { get; set; }
        public string menu_name { get; set; }
    }

}
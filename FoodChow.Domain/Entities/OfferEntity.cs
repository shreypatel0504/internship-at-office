namespace FoodChow.Domain.Entities
{
    public class OfferEntity
    {
        public long id { get; set; }

        public long shop_id { get; set; }

        public long discount { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public int type { get; set; }

        public string? start_date { get; set; }

        public string? end_date { get; set; }

        public int total { get; set; }

        public int claimed { get; set; }

        public int redeemed { get; set; }

        public int available { get; set; }

        public int status { get; set; }

        public DateTime created_date { get; set; }

        public DateTime updated_date { get; set; }
        public string? offer_order_method { get; set; }

        public DateTime start_date_str { get; set; }

        public DateTime end_date_str { get; set; }

        public string? start_time { get; set; }

        public string? end_time { get; set; }

        public string? term_condition { get; set; }

        public string? days { get; set; }
        public string? image_name { get; set; }
    }
}
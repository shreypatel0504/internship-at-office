namespace FoodChow.Application.Entities
{
    public class FoodPreferenceEntity
    {
        public long preference_id { get; set; }
        public long shop_id { get; set; }
        public string preference_name { get; set; } = string.Empty;
        public int is_mandatory { get; set; }
        public int is_active { get; set; }
        public long sold_out_flag { get; set; }

        public string? created_date { get; set; }
        public string? updated_date { get; set; }
    }
}
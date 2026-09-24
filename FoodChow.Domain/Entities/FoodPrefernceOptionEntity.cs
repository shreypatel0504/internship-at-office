namespace FoodChow.Application.Entities
{
    public class FoodPreferenceOptionEntity
    {
        public long preference_option_id { get; set; }
        public long preference_id { get; set; }
        public string option_name { get; set; } = string.Empty;
        public int is_active { get; set; }
        public long status { get; set; }
        public long sold_out_flag { get; set; }

        public string? created_date { get; set; }
        public string? updated_date { get; set; }
    }
}
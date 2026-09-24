namespace FoodChow.Application.DTOs
{
    // food_preferences 

    public class FoodPreferenceDto
    {
        public long PreferenceId { get; set; }
        public long ShopId { get; set; }
        public string PreferenceName { get; set; } = string.Empty;
        public int IsMandatory { get; set; }
        public int IsActive { get; set; }
        public long SoldOutFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class AddFoodPreferenceDto
    {
        public long ShopId { get; set; }
        public string PreferenceName { get; set; } = string.Empty;
        public int IsMandatory { get; set; } = 0;
        public int IsActive { get; set; } = 1;
    }

    public class UpdateFoodPreferenceDto
    {
        public long PreferenceId { get; set; }
        public string PreferenceName { get; set; } = string.Empty;
    }

    // food preference option

    public class PreferenceOptionDto
    {
        public long PreferenceOptionId { get; set; }
        public long PreferenceId { get; set; }
        public string OptionName { get; set; } = string.Empty;
        public int IsActive { get; set; }
        public long SoldOutFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class AddPreferenceOptionDto
    {
        public long PreferenceId { get; set; }
        public string OptionName { get; set; } = string.Empty;
        public int IsActive { get; set; } = 1;
    }

    public class UpdatePreferenceOptionDto
    {
        public long PreferenceOptionId { get; set; }
        public string OptionName { get; set; } = string.Empty;
    }
}

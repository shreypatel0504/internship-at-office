namespace FoodChow.Application.DTOs
{
    public class PosCountryPlanDto
    {
        public long id { get; set; }
        public string country_name { get; set; }
        public string currency { get; set; }
        public decimal plan_amount { get; set; }
    }
}
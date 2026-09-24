namespace FoodChow.Application.DTOs
{
    public class CountryPlanOnlineDto
    {
        public long id { get; set; }
        public string country_name { get; set; }
        public int no_of_orders { get; set; }
        public int no_of_days { get; set; }
        public decimal commission { get; set; }
        public decimal commission_gst { get; set; }
        public decimal platform_fees { get; set; }
        public string currency { get; set; }
        public decimal amount { get; set; }
    }
}
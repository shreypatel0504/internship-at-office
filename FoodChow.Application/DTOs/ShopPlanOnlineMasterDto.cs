namespace FoodChow.Application.DTOs
{
    public class ShopPlanOnlineMasterDto
    {
        public long id { get; set; }
        public long shop_id { get; set; }
        public int no_of_orders { get; set; }
        public int no_of_days { get; set; }
        public string currency { get; set; }
        public decimal amount { get; set; }
        public string current_plan { get; set; }
    }
}
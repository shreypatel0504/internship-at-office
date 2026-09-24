namespace FoodChow.Application.Entities
{
    public class MasterEntity
    {
        public long shop_id { get; set; }
        public string? subdomain { get; set; }
        public string? custom_domain { get; set; }
        public int domain_status { get; set; }

        public string? email_id { get; set; }
        public string? shop_name { get; set; }

        public string? business_name { get; set; }

        public double rate { get; set; }
        public string? charge_lable { get; set; }

        public string? menu_object { get; set; }
        public int menu_status { get; set; }

        public long user_id { get; set; }
    }
}
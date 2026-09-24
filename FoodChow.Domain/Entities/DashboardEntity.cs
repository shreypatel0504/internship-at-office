using System;
using System.Collections.Generic;
using System.Text;
namespace FoodChow.Domain.Entities
{
    public class DashboardEntity
    {
        public long shop_id { get; set; }

        public long order_id { get; set; }

        public string token { get; set; }

        public string device_id { get; set; }

        public string device_type { get; set; }

        public int business_type { get; set; }

        public int payment_status { get; set; }

        public string request_text { get; set; }

        public string timing { get; set; }
        public long pos_user_id { get; set; }

        public string? device_model { get; set; }
       
    }
}
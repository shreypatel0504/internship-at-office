using System;
using System.Collections.Generic;

namespace FoodChow.Domain.Entities
{
  
    public class DeliveryZoneEntity
    {
        public int Id { get; set; }

        public long shop_id { get; set; }

        public int zone_no { get; set; }

        public string type { get; set; }

        public double min_order { get; set; }

        public double delivery_fee { get; set; }

        public string color { get; set; }

        public string delivery_hours { get; set; }

        public string delivery_minute { get; set; }

        public string min_order_freedelivery { get; set; }

        public string radius { get; set; }

        public DateTime created_date { get; set; }

        public DateTime updated_date { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public int zone { get; set; }
    }
    

    public class DeliveryZonePointEntity
    {
        public int id { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public int zone { get; set; }
    }


    public class DeliveryOptionEntity
    {
        public int id { get; set; }

        public int shop_id { get; set; }

        public int option_id { get; set; }

        public int status { get; set; }

        public DateTime created_date { get; set; }

        public DateTime updated_date { get; set; }
    }
}
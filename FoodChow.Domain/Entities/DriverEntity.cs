using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Domain.Entities
{
    public class DriverEntity
    {
        public long id { get; set; }

        public long shop_id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? emailid { get; set; }

        public string? mobile_number { get; set; }

        public string? date_of_birth { get; set; }

        public string? gender { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? country { get; set; }

        public string? status { get; set; }

        public DateTime created_date { get; set; }

        public DateTime updated_date { get; set; }

    }
    public class DriverDocumentEntity
    {
        public long id { get; set; }
        public long driver_id { get; set; }
        public string? document_name { get; set; }
        public string? document_file { get; set; }

    }
    public class DriverVehicleEntity
    {
        public long id { get; set; }
        public long driver_id { get; set; }
        public string? vehicle_type { get; set; }
        public string? vehicle_no { get; set; }
        public string? vehicle_name { get; set; }
    }
    public class DriverBankEntity
    {
        public long id { get; set; }
        public long driver_id { get; set; }
        public string? account_name { get; set; }
        public string? account_number { get; set; }
        public string? ifsc_code { get; set; }
        public string? bank_name { get; set; }
    }
    public class DriverTimingEntity
    {
        public long id { get; set; }
        public long driver_id { get; set; }
        public string? day_name { get; set; }
        public string? start_time { get; set; }
        public string? end_time { get; set; }
    }
   
    public class DriverOrderAssignEntity
    {
        public long shopid { get; set; }

        public string? order_id { get; set; }

        public long driver_id { get; set; }

        public long status { get; set; }

        public DateTime order_bind_date { get; set; }

        public DateTime created_date { get; set; }

        public DateTime updated_date { get; set; }
    }
  
}

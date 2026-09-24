using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Domain.Entities
{
    public class ReservationEntity
    {
        public long res_id { get; set; }
        public long shopid { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public long contact { get; set; }
        public string no_of_person { get; set; } = string.Empty;
        public long total_amount { get; set; }
        public string r_time { get; set; }
    }

    public class ReservationRequestEntity
    {
        public long TR_Id { get; set; }
        public string TR_First_Name { get; set; }
        public string TR_Last_Name { get; set; }
        public string TR_Email { get; set; }
        public string TR_Mobile_Number { get; set; }
        public long TR_No_Guest { get; set; }
        public string TR_Description { get; set; }
        public string TR_Reservation_Date { get; set; }
        public string TR_Reservation_Time { get; set; }
        public string TR_Time_Slot { get; set; }
        public int TR_Accept { get; set; }
        public long TR_Shop_Id { get; set; }
        public long TR_UserId { get; set; }
    }
}

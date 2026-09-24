using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Domain.Entities
{
    public class TableEntity
    {
        public long id { get; set; }
        public long shop_id { get; set; }
        public string table_name { get; set; } = string.Empty;
        public string no_of_people { get; set; } = string.Empty;
        public long category_id { get; set; }
        public int status { get; set; }
    }

    public class ShopDineInTableEntity
    {
        public long id { get; set; }
        public string table_no { get; set; }
        public int no_of_seat { get; set; }
        public long shop_id { get; set; }
        public int status { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? updated_date { get; set; }
    }
}

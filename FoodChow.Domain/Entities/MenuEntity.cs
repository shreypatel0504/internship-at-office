namespace FoodChow.Domain.Entities
{

    public class FoodCategoryEntity
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public string CateName { get; set; } = string.Empty;

        public string? CateImage { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

    public class FoodItemEntity
    {
        public long ItemId { get; set; }
        public long CateId { get; set; }
        public long ShopId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }     
        public int SoldOutFlag { get; set; }
        public int IsManageStock { get; set; }

    }

    public class FoodItemStockEntity
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long SizeId { get; set; }
        public long Stock { get; set; }
        public long ShopId { get; set; }


    }

    public class FoodItemPreferenceEntity
    {
        public long ItemPreferenceId { get; set; }
        public long ItemId { get; set; }
        public long PreferenceId { get; set; }
        public int IsMandatory { get; set; }
        public int IsActive { get; set; }   // must exist
        public long MaximumSelection { get; set; }
    }
    public class FoodIngredientEntity
    {
        public long IngredientId { get; set; }
        public long ShopId { get; set; }
        public string IngredientName { get; set; }
        public int Status { get; set; }
    }

    public class FoodIngredientSizeEntity
    {
        public long Id { get; set; }
        public long ItemIngredientId { get; set; }
        public long SizeId { get; set; }
        public double Price { get; set; }
    }

    public class ShopSizeEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string SizeName { get; set; }
        public int Status { get; set; }
    }

    public class DeliveryMethodEntity
    {
        public long Id { get; set; }
        public string DeliveryMethodName { get; set; }
        public int Status { get; set; }
    }

    public class PosKotTableEntity
    {
        public long Id { get; set; }
        public string KotId { get; set; }
        public long ShopId { get; set; }
        public DateTime? KotStartTime { get; set; }
        public DateTime? KotEndTime { get; set; }
        public string KotStatus { get; set; }
        public string OrderId { get; set; }
        public string PosUserName { get; set; }
        public string OrderType { get; set; }
        public string TableNo { get; set; }
    }
    public class ItemStockSettingEntity
    {
        public long ShopId { get; set; }
        public int IsOrder { get; set; }
    }

    public class MenuObjectEntity
    {
        public int Id { get; set; }

        public long ShopId { get; set; }

        public long UserId { get; set; }

        public string MenuObject { get; set; }

        public int MenuStatus { get; set; }

        public int ShopStatus { get; set; }

        public string Reason { get; set; }
    }

}
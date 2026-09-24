using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<FoodCategoryEntity>> GetCategories(long shopId);
        Task<long> AddCategory(FoodCategoryEntity entity);
        Task<int> UpdateCategory(long id, string name);
        Task<int> DeleteCategory(long id);

        Task<IEnumerable<FoodItemEntity>> GetItems(long shopId);
        Task<long> AddItem(FoodItemEntity entity);
        Task<int> UpdateItem(long itemId, string itemName, string description);
        Task<int> DeleteItem(long id);

        Task<IEnumerable<FoodItemStockEntity>> GetItemStock(long itemId);
        Task<int> UpdateStock(FoodItemStockEntity entity);

        Task<IEnumerable<FoodItemPreferenceEntity>> GetItemPreferences(long itemId);
        Task<int> AddItemPreference(FoodItemPreferenceEntity entity);
        Task<int> RemovePreference(long itemPreferenceId);

        Task<IEnumerable<FoodIngredientEntity>> GetIngredients(long shopId);
        Task<int> AddIngredient(FoodIngredientEntity entity);
        Task<int> UpdateIngredient(FoodIngredientEntity entity);
        Task<int> DeleteIngredient(long id);

        Task<IEnumerable<FoodIngredientSizeEntity>> GetIngredientSizes(long ingredientId);
        Task<int> AddIngredientSize(FoodIngredientSizeEntity entity);

        Task<IEnumerable<ShopSizeEntity>> GetSizes(long shopId);
        Task<int> AddShopSize(ShopSizeEntity entity);

        Task<IEnumerable<DeliveryMethodEntity>> GetDeliveryMethods();
      
        Task<IEnumerable<PosKotTableEntity>> GetPosKotForShop(long shopId);
        Task<IEnumerable<PosKotTableEntity>> GetPosKotByStatus(string status);
        Task<int> UpdatePosKotOrder(string kotId, string status);
        Task<int> CancelPosKot(string kotId);
        Task<IEnumerable<PosKotTableEntity>> GetCancelledPosKot();
        Task<int> UpdatePosKotEndTime(string kotId);

        Task<int> UpdateStockStatusForItem(long itemId, int soldOut);
        Task<ItemStockSettingEntity> GetItemStockSetting(long shopId);
        Task<int> SetItemStockSetting(long shopId, int status);
               
        Task<IEnumerable<FoodItemEntity>> GetItemDetailsByShopIdMasterWithSoldOut(long shopId);       

        Task<FoodItemEntity> GetItemById(long itemId);

        Task<int> MarkSoldOut(long itemId, int flag);

        Task<int> UpdateManageStock(long itemId, int flag);
        Task<IEnumerable<MenuObjectEntity>> GetMenuObjects(long shopId);

        Task<MenuObjectEntity> GetMenuObjectById(long id);

        Task<long> AddMenuObject(MenuObjectEntity entity);

        Task<int> UpdateMenuObject(MenuObjectEntity entity);

        Task<int> DeleteMenuObject(long id);


    }
}
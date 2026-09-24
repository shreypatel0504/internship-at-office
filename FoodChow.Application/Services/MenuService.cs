using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _repo;

        public MenuService(IMenuRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FoodCategoryEntity>> GetAllCategories(long shopId)
            => await _repo.GetCategories(shopId);

        public async Task<long> AddCategory(FoodCategoryEntity e)
            => await _repo.AddCategory(e);

        public Task<int> UpdateCategory(long id, string name)
            => _repo.UpdateCategory(id, name);

        public async Task<int> DeleteCategory(long id)
            => await _repo.DeleteCategory(id);

        public async Task<IEnumerable<FoodItemEntity>> GetAllItems(long shopId)
            => await _repo.GetItems(shopId);

        public async Task<long> AddItem(FoodItemEntity e)
            => await _repo.AddItem(e);

        public Task<int> UpdateItem(long itemId, string itemName, string description)
          => _repo.UpdateItem(itemId, itemName, description);

        public async Task<int> DeleteItem(long id)
            => await _repo.DeleteItem(id);

        public async Task<IEnumerable<FoodItemStockEntity>> GetItemStock(long itemId)
        {
            return await _repo.GetItemStock(itemId);
        }

        public async Task<int> UpdateItemStock(FoodItemStockEntity e)
            => await _repo.UpdateStock(e);

        public async Task<IEnumerable<FoodItemPreferenceEntity>> GetItemPreferences(long itemId)
            => await _repo.GetItemPreferences(itemId);

        public async Task<int> AssignPreference(FoodItemPreferenceEntity e)
            => await _repo.AddItemPreference(e);

        public async Task<int> RemovePreference(long id)
            => await _repo.RemovePreference(id);

        public async Task<IEnumerable<FoodIngredientEntity>> GetIngredients(long shopId)
            => await _repo.GetIngredients(shopId);

        public async Task<int> AddIngredient(FoodIngredientEntity e)
            => await _repo.AddIngredient(e);

        public async Task<int> UpdateIngredient(FoodIngredientEntity e)
            => await _repo.UpdateIngredient(e);

        public async Task<int> DeleteIngredient(long id)
            => await _repo.DeleteIngredient(id);

        public async Task<IEnumerable<FoodIngredientSizeEntity>> GetIngredientSizes(long id)
            => await _repo.GetIngredientSizes(id);

        public async Task<int> AddIngredientSize(FoodIngredientSizeEntity e)
            => await _repo.AddIngredientSize(e);

        public async Task<IEnumerable<ShopSizeEntity>> GetShopSizes(long shopId)
            => await _repo.GetSizes(shopId);

        public async Task<int> AddShopSize(ShopSizeEntity e)
            => await _repo.AddShopSize(e);

        public async Task<IEnumerable<DeliveryMethodEntity>> GetDeliveryMethods()
            => await _repo.GetDeliveryMethods();

        public async Task<IEnumerable<PosKotTableEntity>> GetPosKotForShop(long shopId)
        => await _repo.GetPosKotForShop(shopId);

        public async Task<IEnumerable<PosKotTableEntity>> GetPosKotByStatus(string status)
        => await _repo.GetPosKotByStatus(status);

        public async Task<int> UpdatePosKotOrder(string kotId, string status)
        => await _repo.UpdatePosKotOrder(kotId, status);

        public async Task<int> CancelPosKot(string kotId)
        => await _repo.CancelPosKot(kotId);

        public async Task<IEnumerable<PosKotTableEntity>> GetCancelledPosKot()
        => await _repo.GetCancelledPosKot();

        public async Task<int> UpdatePosKotEndTime(string kotId)
        => await _repo.UpdatePosKotEndTime(kotId);

        public async Task<int> UpdateStockStatusForItem(long itemId, int soldOut)
        => await _repo.UpdateStockStatusForItem(itemId, soldOut);

        public async Task<ItemStockSettingEntity> GetItemStockSetting(long shopId)
        => await _repo.GetItemStockSetting(shopId);

        public async Task<int> SetItemStockSetting(long shopId, int status)
        => await _repo.SetItemStockSetting(shopId, status);

        public async Task<IEnumerable<FoodItemEntity>> GetItemDetailsByShopIdMasterWithSoldOut(long shopId)
        => await _repo.GetItemDetailsByShopIdMasterWithSoldOut(shopId);

        public async Task<int> MarkSoldOut(long itemId, int flag)
        => await _repo.MarkSoldOut(itemId, flag);

        public async Task<int> UpdateManageStock(long itemId, int flag)
        => await _repo.UpdateManageStock(itemId, flag);
        public async Task<IEnumerable<MenuObjectEntity>> GetMenuObjects(long shopId)
        => await _repo.GetMenuObjects(shopId);

        public async Task<MenuObjectEntity> GetMenuObjectById(long id)
        => await _repo.GetMenuObjectById(id);

        public async Task<long> AddMenuObject(MenuObjectEntity entity)
        => await _repo.AddMenuObject(entity);

        public async Task<int> UpdateMenuObject(MenuObjectEntity entity)
        => await _repo.UpdateMenuObject(entity);

        public async Task<int> DeleteMenuObject(long id)
        => await _repo.DeleteMenuObject(id);
    }
}
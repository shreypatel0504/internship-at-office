using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MySqlDalc _dalc;

        public MenuRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<FoodCategoryEntity>> GetCategories(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodCategoryEntity>(
                "USP_GetAllCategories",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<long> AddCategory(FoodCategoryEntity entity)
        {
            var parameters = new
            {
                p_shop_id = entity.ShopId,
                p_cate_name = entity.CateName,
                p_cate_image = entity.CateImage,
                p_status = entity.Status
            };

            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddCategory",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<bool> UpdateCategory(FoodCategoryEntity entity)
        //{
        //    var result = await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_UpdateFoodCategory",
        //        entity,
        //        commandType: CommandType.StoredProcedure);

        //    return result > 0;
        //}

        //public async Task<bool> DeleteCategory(long id)
        //{
        //    var result = await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_DeleteFoodCategory",
        //        new { id },
        //        commandType: CommandType.StoredProcedure);

        //    return result > 0;
        //}



        public async Task<IEnumerable<FoodItemEntity>> GetItems(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodItemEntity>(
                "USP_GetAllMenuItems",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        
        public async Task<long> AddItem(FoodItemEntity entity)
        {
            var parameters = new
            {
                p_cate_id = entity.CateId,
                p_item_name = entity.ItemName,
                p_description = entity.Description,
                p_shop_id = entity.ShopId
            };

            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddMenuItem",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<bool> UpdateItem(FoodItemEntity entity)
        //{
        //    var result = await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_UpdateFoodItem",
        //        entity,
        //        commandType: CommandType.StoredProcedure);

        //    return result > 0;
        //}

        //public async Task<bool> DeleteItem(long itemId)
        //{
        //    var result = await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_DeleteFoodItem",
        //        new { itemId },
        //        commandType: CommandType.StoredProcedure);

        //    return result > 0;
        //}



        public async Task<IEnumerable<FoodItemStockEntity>> GetItemStock(long itemId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodItemStockEntity>(
                "USP_GetItemStock",
                new { p_item_id = itemId },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<bool> UpdateStock(FoodItemStockEntity entity)
        //{
        //    return await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_UpdateItemStock",
        //        new
        //        {p_item_id = e.ItemId, p_stock = e.Stock},
        //        commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<FoodItemPreferenceEntity>> GetItemPreferences(long itemId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodItemPreferenceEntity>(
                "USP_GetItemPreferences",
                new { p_item_id = itemId },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<long> AddItemPreference(FoodItemPreferenceEntity entity)
        //{
        //    return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
        //        "USP_AddItemPreference",
        //        entity,
        //        commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<FoodIngredientEntity>> GetIngredients(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodIngredientEntity>(
                "USP_GetIngredients",
                new { p_shop_id=shopId },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<long> AddIngredient(FoodIngredientEntity entity)
        //{
        //    return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
        //        "USP_AddIngredient",
        //        entity,
        //        commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<ShopSizeEntity>> GetSizes(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<ShopSizeEntity>(
                "USP_GetShopSizes",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeliveryMethodEntity>> GetDeliveryMethods()
        {
            return await _dalc.CreateConnection().QueryAsync<DeliveryMethodEntity>(
                "USP_GetDeliveryMethods",
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateCategory(long id, string name)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCategory",
                new
                {
                    p_id = id,
                    p_name = name
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteCategory(long id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCategory",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateItem(long itemId, string itemName, string description)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateMenuItem",
                new
                {
                    p_item_id = itemId,
                    p_item_name = itemName,
                    p_description = description
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteItem(long id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteMenuItem",
                new { p_item_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateStock(FoodItemStockEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateItemStock",
                new
                {
                    p_item_id = e.ItemId,
                    p_stock = e.Stock
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddItemPreference(FoodItemPreferenceEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                 "USP_AddItemPreference",
                 new
                 {
                     p_item_id = e.ItemId,
                     p_preference_id = e.PreferenceId,
                     p_is_mandatory = e.IsMandatory,
                     p_is_active=e.IsActive,
                     p_maximum_selection=e.MaximumSelection
                 },
                 commandType: CommandType.StoredProcedure);
        }

        public async Task<int> RemovePreference(long itemPreferenceId)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_RemoveItemPreference",
                new { p_item_preference_id = itemPreferenceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddIngredient(FoodIngredientEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                 "USP_AddIngredient",
                 new
                 {
                     p_shop_id = e.ShopId,
                     p_name = e.IngredientName
                 },
                 commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateIngredient(FoodIngredientEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
    "USP_UpdateIngredient",
    new
    {
        p_ingredient_id = e.IngredientId,
        p_ingredient_name = e.IngredientName
    },
    commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteIngredient(long id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteIngredient",
                new { p_ingredient_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FoodIngredientSizeEntity>> GetIngredientSizes(long ingredientId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodIngredientSizeEntity>(
                "USP_GetIngredientSizes",
                new {p_ingredient_id= ingredientId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddIngredientSize(FoodIngredientSizeEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddIngredientSize",
                new
                {
                    p_item_ingredient_id = e.ItemIngredientId,
                    p_size_id = e.SizeId,
                    p_price = e.Price
                },
                commandType: CommandType.StoredProcedure); 
                
        }

        public async Task<int> AddShopSize(ShopSizeEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddShopSize",
                new
                {
                    p_shop_id = e.ShopId,
                    p_size_name = e.SizeName
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PosKotTableEntity>> GetPosKotForShop(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<PosKotTableEntity>(
                "USP_GetPosKotForShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PosKotTableEntity>> GetPosKotByStatus(string status)
        {
            return await _dalc.CreateConnection().QueryAsync<PosKotTableEntity>(
                "USP_GetPosKotOrderByStatus",
                new { p_status = status },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdatePosKotOrder(string kotId, string status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePosKotOrder",
                new
                {
                    p_kot_id = kotId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CancelPosKot(string kotId)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_CancelPosKot",
                new { p_kot_id = kotId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PosKotTableEntity>> GetCancelledPosKot()
        {
            return await _dalc.CreateConnection().QueryAsync<PosKotTableEntity>(
                "USP_GetCancelledPosKot",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdatePosKotEndTime(string kotId)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePosKotEndTime",
                new { p_kot_id = kotId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateStockStatusForItem(long itemId, int soldOut)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateStockStatusForItem",
                new
                {
                    p_item_id = itemId,
                    p_sold_out = soldOut
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ItemStockSettingEntity> GetItemStockSetting(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<ItemStockSettingEntity>(
                "USP_GetItemStockSetting",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SetItemStockSetting(long shopId, int status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_SetItemStockSetting",
                new
                {
                    p_shop_id = shopId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FoodItemEntity>> GetItemDetailsByShopIdMasterWithSoldOut(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodItemEntity>(
                "USP_GetItemDetailsByShopIdMasterWithSoldOut",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        //public async Task<IEnumerable<FoodItemEntity>> GetItems(long shopId)
        //{
        //    return await _dalc.CreateConnection().QueryAsync<FoodItemEntity>(
        //        "USP_GetAllMenuItems",
        //        new { p_shop_id = shopId },
        //        commandType: CommandType.StoredProcedure);
        //}

        public async Task<FoodItemEntity> GetItemById(long itemId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<FoodItemEntity>(
                "USP_GetMenuItemById",
                new { p_item_id = itemId },
                commandType: CommandType.StoredProcedure);
        }
        //public async Task<long> AddItem(FoodItemEntity entity)
        //{
        //    return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
        //        "USP_AddMenuItem",
        //        new
        //        {
        //            p_cate_id = entity.CateId,
        //            p_item_name = entity.ItemName,
        //            p_description = entity.Description,
        //            p_shop_id = entity.ShopId
        //        },
        //        commandType: CommandType.StoredProcedure);
        //}

        //public async Task<int> UpdateItem(FoodItemEntity entity)
        //{
        //    return await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_UpdateMenuItem",
        //        new
        //        {
        //            p_item_id = entity.ItemId,
        //            p_item_name = entity.ItemName,
        //            p_description = entity.Description
        //        },
        //        commandType: CommandType.StoredProcedure);
        //}

        //public async Task<int> DeleteItem(long id)
        //{
        //    return await _dalc.CreateConnection().ExecuteAsync(
        //        "USP_DeleteMenuItem",
        //        new { p_item_id = id },
        //        commandType: CommandType.StoredProcedure);
        //}

        public async Task<int> MarkSoldOut(long itemId, int flag)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_MarkItemSoldOut",
                new
                {
                    p_item_id = itemId,
                    p_flag = flag
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateManageStock(long itemId, int flag)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateManageStock",
                new
                {
                    p_item_id = itemId,
                    p_flag = flag
                },
                commandType: CommandType.StoredProcedure);
        }
        //public async Task<IEnumerable<FoodItemEntity>> GetItems(long shopId)
        //{
        //    return await _dalc.CreateConnection().QueryAsync<FoodItemEntity>(
        //        "USP_GetAllMenuItems",
        //        new { p_shop_id = shopId },
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task<IEnumerable<MenuObjectEntity>> GetMenuObjects(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<MenuObjectEntity>(
                "USP_GetMenuObjectList",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<MenuObjectEntity> GetMenuObjectById(long id)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<MenuObjectEntity>(
                "USP_GetMenuObjectById",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<long> AddMenuObject(MenuObjectEntity entity)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddMenuObject",
                new
                {
                    p_shop_id = entity.ShopId,
                    p_user_id = entity.UserId,
                    p_menu_object = entity.MenuObject,
                    p_menu_status = entity.MenuStatus,
                    p_shop_status = entity.ShopStatus,
                    p_reason = entity.Reason
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateMenuObject(MenuObjectEntity entity)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateMenuObject",
                new
                {
                    p_id = entity.Id,
                    p_menu_object = entity.MenuObject,
                    p_menu_status = entity.MenuStatus,
                    p_shop_status = entity.ShopStatus,
                    p_reason = entity.Reason
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteMenuObject(long id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteMenuObject",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }


    }
}
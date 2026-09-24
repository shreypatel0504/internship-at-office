using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class BulkEditRepository(MySqlDalc dalc) : IBulkEditRepository
    {
        // ================= CATEGORY ===================

        public Task<int> StoreBulkEditCategoryAsync(long shopId, long id, string cateName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_BulkCategoryUpdate",
                new
                {
                    p_shop_id = shopId,
                    p_id = id,
                    p_cate_name = cateName
                });

        // ================= ITEM NAME =================

        public Task<int> StoreBulkItemNameAsync(string itemId, string itemName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_BulkItemNameUpdate",
                new
                {
                    p_item_id = itemId,
                    p_item_name = itemName
                });

        // ================= ITEM PRICE =================

        public async Task<int> StoreBulkItemPriceAsync(string itemId, double price)
        {
            return await dalc.ExecuteQueryAsync(
                @"UPDATE food_item_size
          SET price = @price
          WHERE item_id = @itemId",
                new
                {
                    itemId,
                    price
                });
        }

        // ================= ITEM SIZE PRICE =================

        public async Task<int> StoreBulkItemSizePriceAsync(string itemId, double price, long sizeId)
        {
            return await dalc.ExecuteQueryAsync(
                @"UPDATE food_item_size
          SET price = @price
          WHERE item_id = @itemId
          AND shop_size_id = @sizeId",
                new
                {
                    itemId,
                    price,
                    sizeId
                });
        }

        // ================= VARIANT =================

        public Task<int> StoreBulkEditVariantAsync(
            long id,
            long shopId,
            string sizeName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_BulkItemVariantsUpdate",
                new
                {
                    p_id = id,
                    p_shop_id = shopId,
                    p_size_name = sizeName
                });

        // ================= CHOICES =================

        public Task<int> StoreBulkChoicesNameAsync(
            long preferenceId,
            long shopId,
            string preferenceName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_BulkChoicesNameUpdate",
                new
                {
                    p_preference_id = preferenceId,
                    p_shop_id = shopId,
                    p_preference_name = preferenceName
                });

        public Task<int> StoreBulkChoicesOptionsAsync(
            long preferenceOptionId,
            long preferenceId,
            string optionName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_BulkChoicesOptionsUpdate",
                new
                {
                    p_preference_option_id = preferenceOptionId,
                    p_preference_id = preferenceId,
                    p_option_name = optionName
                });

        // ================= EXTRA CATEGORY =================

        public Task<int> UpdateExtraCategoryAsync(
            long customCatId,
            string catName) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStoreExtraCategory",
                new
                {
                    p_custom_cat_id = customCatId,
                    p_cat_name = catName
                });

        public Task<int> UpdateExtraCategoryOptionAsync(
            long ingredientId,
            string ingredientName,
            int isVeg) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStoreExtraCategoryOption",
                new
                {
                    p_ingredient_id = ingredientId,
                    p_ingredient_name = ingredientName,
                    p_is_veg = isVeg
                });

        public Task<int> UpdateExtraCategoryOptionSizeAsync(
            long ingredientId,
            long sizeId,
            double price) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStoreExtraCategoryOptionSize",
                new
                {
                    p_ingredient_id = ingredientId,
                    p_size_id = sizeId,
                    p_price = price
                });

        public Task<int> UpdateExtraCategoryOptionPriceAsync(
            long ingredientId,
            double price) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStoreExtraCategoryOptionPrice",
                new
                {
                    p_ingredient_id = ingredientId,
                    p_price = price
                });

        // ================= GET DATA =================

        public Task<IEnumerable<dynamic>> GetItemListForBulkEditAsync(long shopId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetItemListForBulkEdit",
                new
                {
                    p_shop_id = shopId
                });

        public Task<IEnumerable<dynamic>> GetItemSizeListForBulkEditAsync(long itemId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetItemSizeListForBulkEdit",
                new
                {
                    p_item_id = itemId
                });

        public Task<IEnumerable<dynamic>> GetAllFoodItemListAsync(long shopId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetAllFoodItemList",
                new
                {
                    p_shop_id = shopId,
                    p_cate_id = "",
                    p_search = "",
                    p_status = 1
                });

        public Task<IEnumerable<dynamic>> GetFoodShopSizeByIdAsync(
            long sizeId,
            long shopId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetFoodShopSizeById",
                new
                {
                    p_size_id = sizeId,
                    p_shop_id = shopId
                });

        // ================= PREFERENCES =================

        public Task<IEnumerable<dynamic>> GetPreferencesListAsync(long shopId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetPreferencesListWithoutCondition",
                new
                {
                    p_shop_id = shopId
                });

        public Task<IEnumerable<dynamic>> GetPreferencesOptionListAsync(long preferenceId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetPreferencesOptionList",
                new
                {
                    p_preference_id = preferenceId
                });

        // ================= CUSTOM CATEGORY =================

        public Task<IEnumerable<dynamic>> GetStoreCustomCategoryAsync(long shopId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetStoreCustomCategory",
                new
                {
                    p_shop_id = shopId
                });

        public Task<IEnumerable<dynamic>> GetStoreCustomCategoryOptionAsync(long customCatId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetStoreCustomCategoryOption",
                new
                {
                    p_custom_cat_id = customCatId
                });

        public Task<IEnumerable<dynamic>> GetStoreCustomCategoryOptionSizeAsync(long ingredientId) =>
            dalc.ExecuteSpListAsync<dynamic>(
                "USP_GetStoreCustomCategoryOptionSize",
                new
                {
                    p_ingredient_id = ingredientId
                });

        // ================= ITEM SIZE =================

        public Task<int> AddItemSizeAsync(
            string itemId,
            string sizeId,
            string price) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_add_item_size",
                new
                {
                    item_id = itemId,
                    size_id = sizeId,
                    price
                });

        public Task<int> UpdateSizeTypeAsync(
            string isSize,
            string itemId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_update_size_type",
                new
                {
                    is_size = isSize,
                    item_id = itemId
                });

        public Task<int> DeleteItemSizeAsync(
            string itemId,
            string sizeId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_delete_item_size",
                new
                {
                    item_id = itemId,
                    size_id = sizeId
                });

        public Task<int> UpdateFoodItemSizeAsync(
            string itemId,
            string sizeId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_update_food_item_size",
                new
                {
                    item_id = itemId,
                    size_id = sizeId
                });

        // ================= PREFERENCE =================

        public Task<int> AddPreferenceAsync(
            string itemId,
            string prefId,
            string isMandatory,
            string maxValue) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_add_preference",
                new
                {
                    item_id = itemId,
                    pref_id = prefId,
                    mandatorycheck = isMandatory,
                    max_value = maxValue
                });

        public Task<int> UpdatePreferenceTypeAsync(
            string isPref,
            string itemId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_update_preference_type",
                new
                {
                    is_pref = isPref,
                    item_id = itemId
                });

        public Task<int> DeletePreferenceAsync(
            string itemId,
            string prefId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_delete_preferece",
                new
                {
                    item_id = itemId,
                    pref_id = prefId
                });

        // ================= DEAL =================

        public Task<int> DeleteDealItemAsync(string itemId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_delete_from_food_deal_item",
                new
                {
                    item_id = itemId
                });

        // ================= CUSTOMIZATION =================

        public Task<int> AddCustomizationAsync(
            string itemId,
            string ingIds,
            string customCatId,
            string isMandatory,
            string selectionType,
            string minValue,
            string maxValue) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_add_customization",
                new
                {
                    item_id = itemId,
                    custom_cat_id = customCatId,
                    ing_ids = ingIds,
                    is_mandatory = isMandatory,
                    selection_type = selectionType,
                    min_values = minValue,
                    max_values = maxValue
                });

        public Task<int> UpdateCustomTypeAsync(
            string isCustom,
            string itemId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_update_custom_type",
                new
                {
                    is_custom = isCustom,
                    item_id = itemId
                });

        public Task<int> DeleteCustomizationAsync(
            string itemId,
            string customId) =>
            dalc.ExecuteSpNonQueryAsync(
                "sp_delete_customization",
                new
                {
                    item_id = itemId,
                    custom_cat_id = customId
                });
    }
}
using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IBulkEditRepository
    {
        // Store
        Task<int> StoreBulkEditCategoryAsync(long shopId, long id, string cateName);
        Task<int> StoreBulkItemNameAsync(string itemId, string itemName);
        Task<int> StoreBulkItemPriceAsync(string itemId, double price);
        Task<int> StoreBulkItemSizePriceAsync(string itemId, double price, long sizeId);
        Task<int> StoreBulkEditVariantAsync(long id, long shopId, string sizeName);
        Task<int> StoreBulkChoicesNameAsync(long preferenceId, long shopId, string preferenceName);
        Task<int> StoreBulkChoicesOptionsAsync(long preferenceOptionId, long preferenceId, string optionName);
        Task<int> UpdateExtraCategoryAsync(long customCatId, string catName);
        Task<int> UpdateExtraCategoryOptionAsync(long ingredientId, string ingredientName, int isVeg);
        Task<int> UpdateExtraCategoryOptionSizeAsync(long ingredientId, long sizeId, double price);
        Task<int> UpdateExtraCategoryOptionPriceAsync(long ingredientId, double price);

        // Get
        Task<IEnumerable<dynamic>> GetItemListForBulkEditAsync(long shopId);
        Task<IEnumerable<dynamic>> GetItemSizeListForBulkEditAsync(long itemId);
        Task<IEnumerable<dynamic>> GetAllFoodItemListAsync(long shopId);
        Task<IEnumerable<dynamic>> GetFoodShopSizeByIdAsync(long sizeId, long shopId);
        Task<IEnumerable<dynamic>> GetPreferencesListAsync(long shopId);
        Task<IEnumerable<dynamic>> GetPreferencesOptionListAsync(long preferenceId);
        Task<IEnumerable<dynamic>> GetStoreCustomCategoryAsync(long shopId);
        Task<IEnumerable<dynamic>> GetStoreCustomCategoryOptionAsync(long customCatId);
        Task<IEnumerable<dynamic>> GetStoreCustomCategoryOptionSizeAsync(long ingredientId);

        // Size / Preference / Customization
        Task<int> AddItemSizeAsync(string itemId, string sizeId, string price);
        Task<int> UpdateSizeTypeAsync(string isSize, string itemId);
        Task<int> DeleteItemSizeAsync(string itemId, string sizeId);
        Task<int> UpdateFoodItemSizeAsync(string itemId, string sizeId);
        Task<int> AddPreferenceAsync(string itemId, string prefId, string isMandatory, string maxValue);
        Task<int> UpdatePreferenceTypeAsync(string isPref, string itemId);
        Task<int> DeletePreferenceAsync(string itemId, string prefId);
        Task<int> DeleteDealItemAsync(string itemId);
        Task<int> AddCustomizationAsync(string itemId, string ingIds, string customCatId, string isMandatory, string selectionType, string minValue, string maxValue);
        Task<int> UpdateCustomTypeAsync(string isCustom, string itemId);
        Task<int> DeleteCustomizationAsync(string itemId, string customId);
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class BulkEditService(IBulkEditRepository repo)
    {
        // ✅ 1 - Add Category
        public async Task<ApiResponse<object>> AddCategoryAsync(BulkCategoryEditDto dto)
        {
            try
            {
                foreach (var t in dto.CategoryList)
                    await repo.StoreBulkEditCategoryAsync(dto.ShopId, t.Id, t.CateName ?? "");

                return ApiResponse<object>.Ok("", "Added Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 2 - Update Category
        public async Task<ApiResponse<object>> UpdateCategoryAsync(BulkCategoryEditDto dto)
        {
            try
            {
                foreach (var t in dto.CategoryList)
                    await repo.StoreBulkEditCategoryAsync(dto.ShopId, t.Id, t.CateName ?? "");

                return ApiResponse<object>.Ok("", "Category Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 3 - Update Item Price
        public async Task<ApiResponse<object>> UpdateItemPriceAsync(BulkEditItemDto dto)
        {
            try
            {
                foreach (var t in dto.ItemList)
                {
                    await repo.StoreBulkItemNameAsync(t.ItemId.ToString(), t.ItemName ?? "");

                    if (t.IsSize == 0)
                        await repo.StoreBulkItemPriceAsync(t.ItemId.ToString(), t.Price);
                    else
                        foreach (var s in t.SizeList)
                            await repo.StoreBulkItemSizePriceAsync(t.ItemId.ToString(), s.Price, s.SizeId);
                }
                return ApiResponse<object>.Ok("", "Item Price Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 4 - Delete Size
        public async Task<ApiResponse<object>> DeleteSizeAsync(string itemId, string sizeId, string btnCount)
        {
            try
            {
                if (btnCount == "1")
                {
                    await repo.UpdateSizeTypeAsync("0", itemId);
                    await repo.UpdateFoodItemSizeAsync(itemId, sizeId);
                }
                else
                {
                    await repo.DeleteItemSizeAsync(itemId, sizeId);
                }
                return ApiResponse<object>.Ok("", "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // ✅ 5 - Get Item List
        public async Task<ApiResponse<object>> GetItemListAsync(long shopId)
        {
            try
            {
                var items = await repo.GetItemListForBulkEditAsync(shopId);
                var itemList = new List<BulkItemPriceDto>();

                foreach (var idx in items)
                {
                    var item = new BulkItemPriceDto
                    {
                        ItemId = idx.item_id,
                        ItemName = idx.item_name,
                        IsSize = idx.is_size_available
                    };

                    var sizes = await repo.GetItemSizeListForBulkEditAsync(idx.item_id);
                    var sizeList = new List<ItemWithSizeDto>();

                    foreach (var s in sizes)
                    {
                        if (s.size_name != "")
                            sizeList.Add(new ItemWithSizeDto
                            {
                                SizeId = s.shop_size_id,
                                SizeName = s.size_name,
                                Price = s.price
                            });
                        else
                            item.Price = s.price;
                    }

                    item.SizeList = sizeList;
                    itemList.Add(item);
                }

                return ApiResponse<object>.Ok(new BulkEditItemDto
                {
                    ShopId = shopId,
                    ItemList = itemList
                });
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }
    }
}
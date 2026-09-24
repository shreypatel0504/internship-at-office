using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkEditController(IBulkEditRepository repo) : ControllerBase
    {
        // ✅ 1 - INSERT
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BulkCategoryEditDto dto)
        {
            try
            {
                foreach (var t in dto.CategoryList)
                    await repo.StoreBulkEditCategoryAsync(dto.ShopId, t.Id, t.CateName ?? "");

                return Ok(new ApiResponse<object> { Success = true, Message = "Added Successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 2 - UPDATE Category
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody] BulkCategoryEditDto dto)
        {
            try
            {
                foreach (var t in dto.CategoryList)
                    await repo.StoreBulkEditCategoryAsync(dto.ShopId, t.Id, t.CateName ?? "");

                return Ok(new ApiResponse<object> { Success = true, Message = "Category Updated Successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 3 - UPDATE Item Price
        [HttpPut("update-item-price")]
        public async Task<IActionResult> UpdateItemPrice([FromBody] BulkEditItemDto dto)
        {
            try
            {
                foreach (var t in dto.ItemList)
                {
                    await repo.StoreBulkItemNameAsync(t.ItemId.ToString(), t.ItemName ?? "");

                    if (t.IsSize == 0)
                    {
                        await repo.StoreBulkItemPriceAsync(
                            t.ItemId.ToString(),
                            t.Price
                        );
                    }
                    else
                    {
                        foreach (var s in t.SizeList)
                        {
                            await repo.StoreBulkItemSizePriceAsync(
                                t.ItemId.ToString(),
                                s.Price,
                                s.SizeId
                            );
                        }
                    }
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Item Price Updated Successfully",
                    Data = ""
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.ToString()
                });
            }
        }

        // ✅ 4 - DELETE Size
        [HttpDelete("delete-size")]
        public async Task<IActionResult> DeleteSize([FromQuery] string item_id, [FromQuery] string size_id, [FromQuery] string btn_count)
        {
            try
            {
                if (btn_count == "1")
                {
                    await repo.UpdateSizeTypeAsync("0", item_id);
                    await repo.UpdateFoodItemSizeAsync(item_id, size_id);
                }
                else
                {
                    await repo.DeleteItemSizeAsync(item_id, size_id);
                }
                return Ok(new ApiResponse<object> { Success = true, Message = "Deleted Successfully", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 5 - GET Item List
        [HttpGet("get-item-list")]
        public async Task<IActionResult> GetItemList([FromQuery] long shopId)
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

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = new BulkEditItemDto { ShopId = shopId, ItemList = itemList }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }
    }
}
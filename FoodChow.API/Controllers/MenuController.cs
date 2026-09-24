using Microsoft.AspNetCore.Mvc;
using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using FoodChow.Infrastructure.DALC;
using Dapper;
using System.Data;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _service;
        private readonly MySqlDalc _dalc;

        public MenuController(MenuService menuService, MySqlDalc dalc)
        {
            _service = menuService;
            _dalc = dalc;
        }

        // ✅ POST /api/menu/UploadCategoryImage
        [HttpPost("UploadCategoryImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadCategoryImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Ok(new { success = false, message = "No file was uploaded." });

                // Only allow image types
                var allowedTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/webp" };
                if (!allowedTypes.Contains(file.ContentType.ToLower()))
                    return Ok(new { success = false, message = "Only image files (jpg, png, gif, webp) are allowed." });

                // Build save path: wwwroot/uploads/categories/
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "categories");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Unique filename: timestamp + original extension
                var extension  = Path.GetExtension(file.FileName);
                var uniqueName = $"{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
                var filePath   = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Relative URL to return to the client
                var fileUrl = $"/uploads/categories/{uniqueName}";

                return Ok(new
                {
                    success  = true,
                    message  = "Category image uploaded successfully.",
                    fileName = uniqueName,
                    fileUrl  = fileUrl
                });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }


        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] FoodCategoryEntity model)
        {
            var result = await _service.AddCategory(model);
            return Ok(result);
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(long id, string name)
        {
            var result = await _service.UpdateCategory(id, name);
            return Ok(result);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var result = await _service.DeleteCategory(id);
            return Ok(result);
        }

        [HttpGet("GetAllCategories/{shopId}")]
        public async Task<IActionResult> GetAllCategories(long shopId)
        {
            var result = await _service.GetAllCategories(shopId);
            return Ok(result);
        }

        //[HttpGet("GetCategoryById/{id}")]
        //public async Task<IActionResult> GetCategoryById(long id)
        //{
        //    var result = await _service.GetCategoryById(id);
        //    return Ok(result);
        //}
        

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] FoodItemEntity model)
        {
            var result = await _service.AddItem(model);
            return Ok(result);
        }

        [HttpPut("UpdateItem")]
        public async Task<IActionResult> UpdateItem(long itemId,string itemName, string description)
        {
            var result = await _service.UpdateItem(itemId, itemName, description);
            return Ok(result);
        }

        [HttpDelete("DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(long itemId)
        {
            var result = await _service.DeleteItem(itemId);
            return Ok(result);
        }

        [HttpGet("GetAllItems/{shopId}")]
        public async Task<IActionResult> GetAllItems(long shopId)
        {
            var result = await _service.GetAllItems(shopId);
            return Ok(result);
        }

        //[HttpGet("GetItemById/{itemId}")]
        //public async Task<IActionResult> GetItemById(long itemId)
        //{
        //    var result = await _service.GetItemById(itemId);
        //    return Ok(result);
        //}

        [HttpPost("UpdateItemStock")]
        public async Task<IActionResult> UpdateItemStock([FromBody] FoodItemStockEntity model)
        {
            var result = await _service.UpdateItemStock(model);
            return Ok(result);
        }

        [HttpGet("stock/{itemId}")]
        public async Task<IActionResult> GetItemStock(long itemId)
        {
            var result = await _service.GetItemStock(itemId);
            return Ok(result);
        }


        [HttpPost("AssignPreference")]
        public async Task<IActionResult> AssignPreference([FromBody] FoodItemPreferenceEntity model)
        {
            var result = await _service.AssignPreference(model);
            return Ok(result);
        }

        [HttpDelete("RemovePreference/{id}")]
        public async Task<IActionResult> RemovePreference(long id)
        {
            var result = await _service.RemovePreference(id);
            return Ok(result);
        }

        [HttpGet("GetItemPreferences/{itemId}")]
        public async Task<IActionResult> GetItemPreferences(long itemId)
        {
            var result = await _service.GetItemPreferences(itemId);
            return Ok(result);
        }

        [HttpPost("AddIngredient")]
        public async Task<IActionResult> AddIngredient([FromBody] FoodIngredientEntity model)
        {
            var result = await _service.AddIngredient(model);
            return Ok(result);
        }

        [HttpPut("UpdateIngredient")]
        public async Task<IActionResult> UpdateIngredient([FromBody] FoodIngredientEntity model)
        {
            var result = await _service.UpdateIngredient(model);
            return Ok(result);
        }

        [HttpDelete("DeleteIngredient/{id}")]
        public async Task<IActionResult> DeleteIngredient(long id)
        {
            var result = await _service.DeleteIngredient(id);
            return Ok(result);
        }

        [HttpGet("GetIngredients/{shopId}")]
        public async Task<IActionResult> GetIngredients(long shopId)
        {
            var result = await _service.GetIngredients(shopId);
            return Ok(result);
        }

        [HttpPost("AddIngredientSize")]
        public async Task<IActionResult> AddIngredientSize([FromBody] FoodIngredientSizeEntity model)
        {
            var result = await _service.AddIngredientSize(model);
            return Ok(result);
        }

        [HttpGet("GetIngredientSizes/{ingredientId}")]
        public async Task<IActionResult> GetIngredientSizes(long ingredientId)
        {
            var result = await _service.GetIngredientSizes(ingredientId);
            return Ok(result);
        }

        [HttpPost("AddShopSize")]
        public async Task<IActionResult> AddShopSize([FromBody] ShopSizeEntity model)
        {
            var result = await _service.AddShopSize(model);
            return Ok(result);
        }

        [HttpGet("GetShopSizes/{shopId}")]
        public async Task<IActionResult> GetShopSizes(long shopId)
        {
            var result = await _service.GetShopSizes(shopId);
            return Ok(result);
        }

        //[HttpGet("GetKotByOrder/{orderId}")]
        //public async Task<IActionResult> GetKotByOrder(string orderId)
        //{
        //    var result = await _service.GetKotByOrder(orderId);
        //    return Ok(result);
        //}

        //[HttpGet("GetAllKot/{shopId}")]
        //public async Task<IActionResult> GetAllKot(long shopId)
        //{
        //    var result = await _service.GetAllKot(shopId);
        //    return Ok(result);
        //}

        [HttpGet("GetDeliveryMethods")]
        public async Task<IActionResult> GetDeliveryMethods()
        {
            var result = await _service.GetDeliveryMethods();
            return Ok(result);
        }
        [HttpGet("GetPoskotForShop")]
        public async Task<IActionResult> GetPoskotForShop(long shopId)
        {
            return Ok(await _service.GetPosKotForShop(shopId));
        }

        [HttpGet("GetPoskotOrderByStatus")]
        public async Task<IActionResult> GetPoskotOrderByStatus(string status)
        {
            return Ok(await _service.GetPosKotByStatus(status));
        }

        [HttpPut("updatePoskotOrder")]
        public async Task<IActionResult> UpdatePoskotOrder(string kotId, string status)
        {
            return Ok(await _service.UpdatePosKotOrder(kotId, status));
        }

        [HttpDelete("CancelPosKot")]
        public async Task<IActionResult> CancelPosKot(string kotId)
        {
            return Ok(await _service.CancelPosKot(kotId));
        }

        [HttpGet("GetCancelledPosKot")]
        public async Task<IActionResult> GetCancelledPosKot()
        {
            return Ok(await _service.GetCancelledPosKot());
        }

        [HttpPut("updatePoskotEndTime")]
        public async Task<IActionResult> UpdatePoskotEndTime(string kotId)
        {
            return Ok(await _service.UpdatePosKotEndTime(kotId));
        }

        [HttpPut("UpdateStockStatusForItem")]
        public async Task<IActionResult> UpdateStockStatusForItem(long itemId, int soldOut)
        {
            return Ok(await _service.UpdateStockStatusForItem(itemId, soldOut));
        }

        [HttpGet("GetItemStockSetting")]
        public async Task<IActionResult> GetItemStockSetting(long shopId)
        {
            return Ok(await _service.GetItemStockSetting(shopId));
        }

        [HttpPost("SetItemStockSetting")]
        public async Task<IActionResult> SetItemStockSetting(long shopId, int status)
        {
            return Ok(await _service.SetItemStockSetting(shopId, status));
        }

        [HttpGet("GetItemDetailsByShopIdMasterWithSoldOut")]
        public async Task<IActionResult> GetItemDetailsByShopIdMasterWithSoldOut(long shopId)
        {
            return Ok(await _service.GetItemDetailsByShopIdMasterWithSoldOut(shopId));
        }

        [HttpPut("MarkSoldOut")]
        public async Task<IActionResult> MarkSoldOut(long itemId, int flag)
        {
            return Ok(await _service.MarkSoldOut(itemId, flag));
        }

        [HttpPut("UpdateManageStock")]
        public async Task<IActionResult> UpdateManageStock(long itemId, int flag)
        {
            return Ok(await _service.UpdateManageStock(itemId, flag));
        }
        [HttpGet("GetMenuObjects/{shopId}")]
        public async Task<IActionResult> GetMenuObjects(long shopId)
        {
            return Ok(await _service.GetMenuObjects(shopId));
        }
        [HttpGet("GetMenuObjectById/{id}")]
        public async Task<IActionResult> GetMenuObjectById(long id)
        {
            return Ok(await _service.GetMenuObjectById(id));
        }
        [HttpPost("AddMenuObject")]
        public async Task<IActionResult> AddMenuObject(
    [FromBody] MenuObjectEntity entity)
        {
            return Ok(await _service.AddMenuObject(entity));
        }
        [HttpPut("UpdateMenuObject")]
        public async Task<IActionResult> UpdateMenuObject(
    [FromBody] MenuObjectEntity entity)
        {
            return Ok(await _service.UpdateMenuObject(entity));
        }
        [HttpDelete("DeleteMenuObject/{id}")]
        public async Task<IActionResult> DeleteMenuObject(long id)
        {
            return Ok(await _service.DeleteMenuObject(id));
        }
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(CategoryService service) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CategoryDto category)
        {
            try
            {
                var result = await service.AddAsync(category);
                return Ok(new ApiResponse<object> { Success = true, Message = "Category added", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategoryDto category)
        {
            try
            {
                var result = await service.UpdateAsync(category);
                return Ok(new ApiResponse<object> { Success = true, Message = "Category updated", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] long shopId)
        {
            try
            {
                var data = await service.GetAllAsync(shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long categoryId, [FromQuery] long shopId)
        {
            try
            {
                var data = await service.GetByIdAsync(categoryId, shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] long categoryId, [FromQuery] long shopId)
        {
            try
            {
                var result = await service.DeleteAsync(categoryId, shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Deleted", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpPost("UploadCategoryImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadCategoryImage(IFormFile file, [FromForm] long categoryId)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new ApiResponse<object> { Success = false, Message = "No file was uploaded." });

                if (categoryId <= 0)
                    return BadRequest(new ApiResponse<object> { Success = false, Message = "Valid categoryId is required." });

                var allowedTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/webp" };
                if (!allowedTypes.Contains(file.ContentType.ToLower()))
                    return BadRequest(new ApiResponse<object> { Success = false, Message = "Only image files (jpg, png, gif, webp) are allowed." });

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "categories");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileExtension = Path.GetExtension(file.FileName);
                var uniqueName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;
                var filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileUrl = "/uploads/categories/" + uniqueName;

                var result = await service.UploadCategoryImage(categoryId, uniqueName, fileUrl);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Category image uploaded successfully.",
                    Data = new { categoryId, fileName = uniqueName, fileUrl }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }
    }
}
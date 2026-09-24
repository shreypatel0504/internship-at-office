using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class CategoryService(ICategoryRepository repo)
    {
        public async Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllAsync(long shopId)
        {
            var list = await repo.GetAllAsync(shopId);
            return ApiResponse<IEnumerable<CategoryDto>>.Ok(list);
        }

        public async Task<ApiResponse<CategoryDto>> GetByIdAsync(long categoryId, long shopId)
        {
            var category = await repo.GetByIdAsync(categoryId, shopId);
            if (category is null)
                return ApiResponse<CategoryDto>.Fail($"Category {categoryId} not found.");
            return ApiResponse<CategoryDto>.Ok(category);
        }

        public async Task<ApiResponse<int>> AddAsync(CategoryDto dto)
        {
            var result = await repo.AddAsync(dto);
            return ApiResponse<int>.Ok(result);
        }

        public async Task<ApiResponse<int>> UpdateAsync(CategoryDto dto)
        {
            var result = await repo.UpdateAsync(dto);
            return ApiResponse<int>.Ok(result);
        }

        public async Task<ApiResponse<int>> DeleteAsync(long categoryId, long shopId)
        {
            var result = await repo.DeleteAsync(categoryId, shopId);
            return ApiResponse<int>.Ok(result);
        }

        
        public async Task<ApiResponse<object>> UploadCategoryImage(long categoryId, string imageName, string imageUrl)
        {
            await repo.UploadCategoryImage(categoryId, imageName, imageUrl);
            return ApiResponse<object>.Ok(new { categoryId, imageName, imageUrl }, "Category image uploaded successfully.");
        }
    }
}
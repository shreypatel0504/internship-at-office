using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(long shopId);
        Task<CategoryDto?> GetByIdAsync(long categoryId, long shopId);
        Task<int> AddAsync(CategoryDto dto);
        Task<int> UpdateAsync(CategoryDto dto);
        Task<int> DeleteAsync(long categoryId, long shopId);
        Task UploadCategoryImage(long categoryId, string imageName, string imageUrl);
    }
}
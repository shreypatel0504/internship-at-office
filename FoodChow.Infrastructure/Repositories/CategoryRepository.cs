using Dapper;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;
using System.Data;

namespace FoodChow.Infrastructure.Repositories
{
    public class CategoryRepository(MySqlDalc dalc) : ICategoryRepository
    {
        public async Task<IEnumerable<CategoryDto>> GetAllAsync(long shopId)
        {
            return await dalc.CreateConnection().QueryAsync<CategoryDto>(
                "USP_GetAllCategories",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<CategoryDto?> GetByIdAsync(long categoryId, long shopId)
        {
            return await dalc.CreateConnection().QueryFirstOrDefaultAsync<CategoryDto>(
                "USP_GetCategoryById",
                new { category_id = categoryId, shop_id = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> AddAsync(CategoryDto dto)
        {
            return await dalc.CreateConnection().ExecuteAsync(
                "USP_AddCategory",
                new
                {
                    shop_id = dto.ShopId,
                    category_name = dto.CategoryName,
                    image_name = dto.ImageName,
                    image_url = dto.ImageUrl,        // 👈 added
                    is_active = dto.IsActive
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(CategoryDto dto)
        {
            return await dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCategory",
                new
                {
                    category_id = dto.CategoryId,
                    shop_id = dto.ShopId,
                    category_name = dto.CategoryName,
                    image_name = dto.ImageName,
                    image_url = dto.ImageUrl,        // 👈 added
                    is_active = dto.IsActive
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteAsync(long categoryId, long shopId)
        {
            return await dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCategory",
                new { category_id = categoryId, shop_id = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UploadCategoryImage(long categoryId, string imageName, string imageUrl)
        {
            await dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateCategoryImage",
                new { category_id = categoryId, image_name = imageName, image_url = imageUrl },  
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
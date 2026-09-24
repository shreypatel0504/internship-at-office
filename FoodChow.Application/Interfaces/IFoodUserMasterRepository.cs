using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IFoodUserMasterRepository
    {
        Task<IEnumerable<FoodUserMasterDto>> GetAllAsync(long shopId);
        Task<FoodUserMasterDto?> GetByIdAsync(long id, long shopId);
        Task<FoodUserMasterDto?> GetByEmailAsync(string email, long shopId);
        Task<long> RegisterAsync(RegisterUserDto dto);
        Task<int> UpdateAsync(UpdateUserDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
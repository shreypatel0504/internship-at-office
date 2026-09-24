using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IRestaurantProfileRepository
    {
        Task<RestaurantProfileDto?> GetByShopIdAsync(long shopId);
        Task<long> AddAsync(AddRestaurantProfileDto dto);
        Task<int> UpdateAsync(UpdateRestaurantProfileDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
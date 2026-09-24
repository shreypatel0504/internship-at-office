using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IShopRepository
    {
        Task<ShopDetailsDto?> GetShopDetailsAsync(int shopId);
    }
}

using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class ShopService
    {
        private readonly IShopRepository _repo;

        public ShopService(IShopRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<ShopDetailsDto>> GetShopDetailsAsync(int shopId)
        {
            if (shopId <= 0)
                return ApiResponse<ShopDetailsDto>.Fail("Invalid shop_id.");

            var shop = await _repo.GetShopDetailsAsync(shopId);

            if (shop is null)
                return ApiResponse<ShopDetailsDto>.Fail($"Shop {shopId} not found.");

            return ApiResponse<ShopDetailsDto>.Ok(shop);
        }
    }
}

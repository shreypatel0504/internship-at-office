using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly MySqlDalc _dalc;

        public ShopRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public Task<ShopDetailsDto?> GetShopDetailsAsync(int shopId) =>
            _dalc.ExecuteSpSingleAsync<ShopDetailsDto>(
                "SP_GetShopDetails",
                new { shop_id = shopId }
            );
    }
}

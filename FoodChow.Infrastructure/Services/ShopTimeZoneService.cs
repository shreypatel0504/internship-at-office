using FoodChow.Application.Interfaces;

namespace FoodChow.Infrastructure.Services
{
    public class ShopTimeZoneService : IShopTimeZoneService
    {
        public Task<DateTime> GetShopLocalTimeAsync(long shopId)
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }
}
using FoodChow.Application.Interfaces;

namespace FoodChow.Infrastructure.Services
{
    public class ShopCurrencyService : IShopCurrencyService
    {
        public Task<string> GetShopCurrencyByIdAsync(string shopId)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
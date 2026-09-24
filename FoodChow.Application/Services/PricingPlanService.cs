using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class PricingPlanService
    {
        private readonly IPricingPlanRepository repo;

        public PricingPlanService(IPricingPlanRepository repo)
        {
            this.repo = repo;
        }

        // ================= COUNTRY POS =================
        public Task<int> AddCountryPlanPosAsync(PosCountryPlanDto dto)
            => repo.AddCountryPlanPosAsync(dto);

        public Task<int> UpdateCountryPlanPosAsync(PosCountryPlanDto dto)
            => repo.UpdateCountryPlanPosAsync(dto);

        public Task<IEnumerable<dynamic>> GetCountryPlanPosAsync(string country)
            => repo.GetCountryPlanPosAsync(country);

        // ================= COUNTRY ONLINE =================
        public Task<int> AddCountryPlanOnlineAsync(CountryPlanOnlineDto dto)
            => repo.AddCountryPlanOnlineAsync(dto);

        public Task<int> UpdateCountryPlanOnlineAsync(CountryPlanOnlineDto dto)
            => repo.UpdateCountryPlanOnlineAsync(dto);

        public Task<IEnumerable<dynamic>> GetCountryPlanOnlineAsync(string country)
            => repo.GetCountryPlanOnlineAsync(country);

        // ================= SHOP MASTER =================
        public Task<int> AddShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto)
            => repo.AddShopPlanOnlineMasterAsync(dto);

        public Task<int> UpdateShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto)
            => repo.UpdateShopPlanOnlineMasterAsync(dto);

        // ================= DETAILS =================
        public Task<IEnumerable<dynamic>> GetPricingPlanDetailsAsync(string shopId)
            => repo.GetPricingPlanDetailsAsync(shopId);
    }
}
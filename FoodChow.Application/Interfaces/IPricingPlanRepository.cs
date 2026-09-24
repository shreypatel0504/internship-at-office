using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IPricingPlanRepository
    {
        // COUNTRY POS
        Task<int> AddCountryPlanPosAsync(PosCountryPlanDto dto);
        Task<int> UpdateCountryPlanPosAsync(PosCountryPlanDto dto);
        Task<IEnumerable<dynamic>> GetCountryPlanPosAsync(string country);

        // COUNTRY ONLINE
        Task<int> AddCountryPlanOnlineAsync(CountryPlanOnlineDto dto);
        Task<int> UpdateCountryPlanOnlineAsync(CountryPlanOnlineDto dto);
        Task<IEnumerable<dynamic>> GetCountryPlanOnlineAsync(string country);

        // SHOP MASTER
        Task<int> AddShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto);
        Task<int> UpdateShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto);

        // DETAILS
        Task<IEnumerable<dynamic>> GetPricingPlanDetailsAsync(string shopId);
    }
}
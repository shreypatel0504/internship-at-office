using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class PricingPlanRepository : IPricingPlanRepository
    {
        private readonly MySqlDalc dalc;

        public PricingPlanRepository(MySqlDalc dalc)
        {
            this.dalc = dalc;
        }

        // ================= COUNTRY POS =================
        public Task<int> AddCountryPlanPosAsync(PosCountryPlanDto dto)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "add_foodchow_country_plan_all_pos",
                new
                {
                    country_name = dto.country_name,
                    currency = dto.currency,
                    plan_amount = dto.plan_amount,
                    created_date = DateTime.Now
                });
        }

        public Task<int> UpdateCountryPlanPosAsync(PosCountryPlanDto dto)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "update_foodchow_country_plan_all_pos",
                new
                {
                    id = dto.id,
                    country_name = dto.country_name,
                    currency = dto.currency,
                    plan_amount = dto.plan_amount,
                    created_date = DateTime.Now
                });
        }

        public Task<IEnumerable<dynamic>> GetCountryPlanPosAsync(string country)
            => dalc.ExecuteSpListAsync<dynamic>(
                "get_foodchow_country_plan_all_pos",
                new { country_name = country }
            );

        // ================= COUNTRY ONLINE =================
        public Task<int> AddCountryPlanOnlineAsync(CountryPlanOnlineDto dto)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "add_foodchow_country_plan_all_online",
                new
                {
                    country_name = dto.country_name,
                    no_of_orders = dto.no_of_orders,
                    no_of_days = dto.no_of_days,
                    commission = dto.commission,
                    commission_gst = dto.commission_gst,
                    platform_fees = dto.platform_fees,
                    currency = dto.currency,
                    amount = dto.amount,
                    created_date = DateTime.Now
                });
        }

        public Task<int> UpdateCountryPlanOnlineAsync(CountryPlanOnlineDto dto)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "update_foodchow_country_plan_all_online",
                new
                {
                    id = dto.id,
                    country_name = dto.country_name,
                    no_of_orders = dto.no_of_orders,
                    no_of_days = dto.no_of_days,
                    commission = dto.commission,
                    commission_gst = dto.commission_gst,
                    platform_fees = dto.platform_fees,
                    currency = dto.currency,
                    amount = dto.amount,
                    created_date = DateTime.Now
                });
        }
        public Task<IEnumerable<dynamic>> GetCountryPlanOnlineAsync(string country)
            => dalc.ExecuteSpListAsync<dynamic>(
                "get_foodchow_country_plan_all_online",
                new { country_name = country }
            );

        // ================= SHOP MASTER =================
        public Task<int> AddShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "add_foodchow_shop_plan_all_online_master",
                new
                {
                    shop_id = dto.shop_id,
                    no_of_orders = dto.no_of_orders,
                    no_of_days = dto.no_of_days,
                    currency = dto.currency,
                    amount = dto.amount,
                    current_plan = dto.current_plan,
                    created_date = DateTime.Now
                });
        }

        public Task<int> UpdateShopPlanOnlineMasterAsync(ShopPlanOnlineMasterDto dto)
    => dalc.ExecuteSpNonQueryAsync(
        "update_foodchow_shop_plan_all_online_master",
        new
        {
            id = dto.id,
            shop_id = dto.shop_id,
            no_of_orders = dto.no_of_orders,
            no_of_days = dto.no_of_days,
            currency = dto.currency,
            amount = dto.amount,
            current_plan = dto.current_plan,
            created_date = DateTime.Now
        });

        // ================= DETAILS =================
        public Task<IEnumerable<dynamic>> GetPricingPlanDetailsAsync(string shopId)
            => dalc.ExecuteSpListAsync<dynamic>(
                "USP_get_foodchowpricingplandetailsExist",
                new { shop_id = shopId }
            );
    }
}
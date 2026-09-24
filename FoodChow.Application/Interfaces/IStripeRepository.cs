using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IStripeRepository
    {
        Task<long> StripeCharges(StripeTransactionEntity entity);
        Task<int> StripeRefund(string chargeId);

        Task<long> CreateStripeConnectAccount(StripeConnectAccountEntity entity);
        Task<IEnumerable<StripeConnectAccountEntity>> CheckStripeAccount(string shopId);

        Task<IEnumerable<StripePlatformEntity>> GetStripePlatform();

        Task<IEnumerable<StripeTransactionEntity>> GetTodayReport();
        Task<IEnumerable<StripeTransactionEntity>> GetWeeklyReport();
        Task<IEnumerable<StripeTransactionEntity>> GetMonthlyReport();
        Task<IEnumerable<StripeTransactionEntity>> GetYearlyReport();

        Task<int> UpdateStripeAccountStatus(string shopId, int status);

        Task<IEnumerable<ShopStripeEntity>> GetShopStripe(string shopId);

        Task<IEnumerable<StripeCountryEntity>> GetSupportedCountries();
    }
}
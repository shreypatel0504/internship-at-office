using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class StripeService
    {
        private readonly IStripeRepository _repo;

        public StripeService(IStripeRepository repo)
        {
            _repo = repo;
        }

        public Task<long> StripeCharges(StripeTransactionEntity e) => _repo.StripeCharges(e);
        public Task<int> StripeRefund(string id) => _repo.StripeRefund(id);

        public Task<long> CreateStripeConnectAccount(StripeConnectAccountEntity e)
            => _repo.CreateStripeConnectAccount(e);

        public Task<IEnumerable<StripeConnectAccountEntity>> CheckStripeAccount(string shopId)
            => _repo.CheckStripeAccount(shopId);

        public Task<IEnumerable<StripePlatformEntity>> GetStripePlatform()
            => _repo.GetStripePlatform();

        public Task<IEnumerable<StripeTransactionEntity>> GetTodayReport()
            => _repo.GetTodayReport();

        public Task<IEnumerable<StripeTransactionEntity>> GetWeeklyReport()
            => _repo.GetWeeklyReport();

        public Task<IEnumerable<StripeTransactionEntity>> GetMonthlyReport()
            => _repo.GetMonthlyReport();

        public Task<IEnumerable<StripeTransactionEntity>> GetYearlyReport()
            => _repo.GetYearlyReport();

        public async Task<int> UpdateStripeAccountStatus(string shopId, int status)
        {
            return await _repo.UpdateStripeAccountStatus(shopId, status);
        }
    }
}
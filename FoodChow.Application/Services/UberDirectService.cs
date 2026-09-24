using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class UberDirectService
    {
        private readonly IUberDirectRepository _repo;

        public UberDirectService(IUberDirectRepository repo)
        {
            _repo = repo;
        }

        public Task<long> SaveIntegration(UberDirectIntegrationEntity e)
            => _repo.SaveIntegration(e);

        public Task<UberDirectIntegrationEntity> GetIntegration(long id)
            => _repo.GetIntegration(id);

        public Task<long> CreateQuote(UberDirectQuoteEntity e)
            => _repo.CreateQuote(e);

        public Task<UberDirectQuoteEntity> GetQuote(string id)
            => _repo.GetQuote(id);

        public Task<long> CreateDelivery(UberDirectQuoteEntity e)
            => _repo.CreateDelivery(e);

        public Task<UberDirectQuoteEntity> GetDelivery(string id)
            => _repo.GetDelivery(id);

        public Task<int> UpdateDeliveryStatus(string id, string status)
            => _repo.UpdateDeliveryStatus(id, status);

        public Task<string> GetTrackingUrl(string orderId)
            => _repo.GetTrackingUrl(orderId);

        public Task<long> AddQuote(UberDirectQuoteEntity e)
           => _repo.AddQuote(e);

        public Task<int> AddDelivery(UberDirectQuoteEntity e)
            => _repo.AddDelivery(e);

        public Task<int> CancelDelivery(string id)
            => _repo.CancelDelivery(id);

        public Task<int> SaveWebhook(UberDirectQuoteEntity e)
            => _repo.SaveWebhook(e);
    }
}
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IUberDirectRepository
    {
        Task<long> SaveIntegration(UberDirectIntegrationEntity e);
        Task<UberDirectIntegrationEntity> GetIntegration(long shopId);

        Task<long> CreateQuote(UberDirectQuoteEntity e);
        Task<UberDirectQuoteEntity> GetQuote(string quoteId);

        Task<long> CreateDelivery(UberDirectQuoteEntity e);
        Task<UberDirectQuoteEntity> GetDelivery(string deliveryId);

        Task<int> UpdateDeliveryStatus(string deliveryId, string status);

        Task<string> GetTrackingUrl(string orderId);

        Task<long> AddQuote(UberDirectQuoteEntity entity);

        Task<int> AddDelivery(UberDirectQuoteEntity entity);

        Task<int> CancelDelivery(string deliveryId);    
        
        Task<int> SaveWebhook(UberDirectQuoteEntity entity);
    }
}
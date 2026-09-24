using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IOfferRepository
    {
        Task SaveOffer(OfferEntity model);

        Task SaveOfferNew(OfferEntity model);

        Task<dynamic> GetAllOffers(long shopId, int flag, string currtime);

        Task<dynamic> GetAllOffersNew(long shopId);

        Task ChangeOfferStatus(long id, int status);

        Task UpdateOffer(OfferEntity model);

        Task UpdateOfferNew(OfferEntity model);

        Task<dynamic> GetLastOfferImage(long shopId);

        Task UploadRestaurantImage(long shopId, string image);
        Task UploadOfferImage(long id, string image_name);
        Task<dynamic> GetOfferById(long id);
        Task DeleteOffer(long id);
        Task<dynamic> GetActiveOffers(long shopId);
        Task<dynamic> GetExpiredOffers(long shopId);
        Task<dynamic> GetOffersByDate(long shopId, DateTime start, DateTime end);
        Task UpdateOfferTiming(long id,DateTime startDateTime,DateTime endDateTime,DateTime startDate,DateTime endDate,string startTime,string endTime,string days);
    }
}
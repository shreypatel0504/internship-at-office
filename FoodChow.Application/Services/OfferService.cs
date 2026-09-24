using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class OfferService
    {
        private readonly IOfferRepository _repo;

        public OfferService(IOfferRepository repo)
        {
            _repo = repo;
        }

        public async Task SaveOffer(OfferEntity model)
            => await _repo.SaveOffer(model);

        public async Task SaveOfferNew(OfferEntity model)
            => await _repo.SaveOfferNew(model);

        public async Task UploadOfferImage(long shopId, string image)
            => await _repo.UploadOfferImage(shopId, image);

        public async Task<dynamic> GetAllOffers(long shopId,int flag,string currtime)
        {
            return await _repo.GetAllOffers(shopId,flag,currtime);
        }

        public async Task<dynamic> GetAllOffersNew(long shopId)
            => await _repo.GetAllOffersNew(shopId);

        public async Task ChangeOfferStatus(long id, int status)
            => await _repo.ChangeOfferStatus(id, status);

        public async Task UpdateOffer(OfferEntity model)
            => await _repo.UpdateOffer(model);

        public async Task UpdateOfferNew(OfferEntity model)
            => await _repo.UpdateOfferNew(model);

        public async Task<dynamic> GetLastOfferImage(long shopId)
            => await _repo.GetLastOfferImage(shopId);

        public async Task UploadRestaurantImage(long shopId, string image)
            => await _repo.UploadRestaurantImage(shopId, image);

        public async Task DeleteOffer(long id)
        {
            await _repo.DeleteOffer(id);
        }

        public async Task<dynamic> GetActiveOffers(long shopId)
        {
            return await _repo.GetActiveOffers(shopId);
        }

        public async Task<dynamic> GetExpiredOffers(long shopId)
        {
            return await _repo.GetExpiredOffers(shopId);
        }
        public async Task<dynamic> GetOfferById(long id)
        {
            return await _repo.GetOfferById(id);
        }

        public async Task<dynamic> GetOffersByDate(long shopId,DateTime start,DateTime end)
        {
            return await _repo.GetOffersByDate(shopId,start,end);
        }

        public async Task UpdateOfferTiming(long id,DateTime startDateTime,DateTime endDateTime,DateTime startDate,DateTime endDate,string startTime,string endTime,string days)
        {
            await _repo.UpdateOfferTiming(id,startDateTime,endDateTime,startDate,endDate,startTime,endTime,days);
        }
    }
}
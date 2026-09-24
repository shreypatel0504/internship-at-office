using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class RestaurantReferEarnService
    {
        private readonly IRestaurantReferEarnRepository _repo;

        public RestaurantReferEarnService(
            IRestaurantReferEarnRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetReferredRestaurants()
            => await _repo.GetReferredRestaurants();

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetOwnReferredRestaurantsByShopId(string id)
            => await _repo.GetOwnReferredRestaurantsByShopId(id);

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetReferredRestaurantsByShopId(string id)
            => await _repo.GetReferredRestaurantsByShopId(id);

        public async Task<long>
            AddReferredRestaurant(ReferredRestaurantEntity e)
            => await _repo.AddReferredRestaurant(e);

        public async Task<int>
            DeleteReferredRestaurant(int id)
            => await _repo.DeleteReferredRestaurant(id);

        public async Task<int>
            DeleteCashback(string shopId)
            => await _repo.DeleteCashback(shopId);

        public async Task<long>
            AddClaimRequestByOwner(ClaimRequestOwnerEntity e)
            => await _repo.AddClaimRequestByOwner(e);

        public async Task<IEnumerable<ClaimRequestOwnerEntity>>
            GetClaimRequestByOwner(string shopId)
            => await _repo.GetClaimRequestByOwner(shopId);

        public async Task<int>
            SendReferralMailForUser(string email)
            => await _repo.SendReferralMailForUser(email);

        public async Task<int>
            SendWhatsAppMessageForRefferdRestaurant(string shopId)
            => await _repo.SendWhatsAppMessageForRefferdRestaurant(shopId);
    }
}
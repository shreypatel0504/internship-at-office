using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IRestaurantReferEarnRepository
    {
        Task<IEnumerable<ReferredRestaurantEntity>> GetReferredRestaurants();

        Task<IEnumerable<ReferredRestaurantEntity>>
            GetOwnReferredRestaurantsByShopId(string shopId);

        Task<IEnumerable<ReferredRestaurantEntity>>
            GetReferredRestaurantsByShopId(string shopId);

        Task<long> AddReferredRestaurant(ReferredRestaurantEntity entity);

        Task<int> DeleteReferredRestaurant(int id);

        Task<int> DeleteCashback(string shopId);

        Task<long> AddClaimRequestByOwner(ClaimRequestOwnerEntity entity);

        Task<IEnumerable<ClaimRequestOwnerEntity>>
            GetClaimRequestByOwner(string shopId);

        Task<int> SendReferralMailForUser(string email);

        Task<int> SendWhatsAppMessageForRefferdRestaurant(string shopId);
    }
}
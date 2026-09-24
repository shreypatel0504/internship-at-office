using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class RestaurantTreeService
    {
        private readonly IRestaurantTreeRepository _repo;

        public RestaurantTreeService(IRestaurantTreeRepository repo)
        {
            _repo = repo;
        }

        public Task<long> AddRestaurantShoptree(RestaurantTreeEntity e)
            => _repo.AddRestaurantShoptree(e);

        public Task<int> UpdateRestaurantShoptree(RestaurantTreeEntity e)
            => _repo.UpdateRestaurantShoptree(e);

        public Task<int> UpdateRestaurantShoptreeStatus(long id, int status)
            => _repo.UpdateRestaurantShoptreeStatus(id, status);

        public Task<int> UpdateRestaurantShoptreeImage(long id, string image)
            => _repo.UpdateRestaurantShoptreeImage(id, image);

        public Task<int> DeleteRestaurantShoptree(long id)
            => _repo.DeleteRestaurantShoptree(id);

        public Task<IEnumerable<RestaurantTreeEntity>> GetRestaurantShoptree(string shopId)
            => _repo.GetRestaurantShoptree(shopId);

        public Task<IEnumerable<RestaurantOverviewEntity>> GetRestaurantOverView(long shopId)
            => _repo.GetRestaurantOverView(shopId);

        public Task<IEnumerable<ShopOfferDealEntity>> GetShopOffersAndDeals(long shopId)
            => _repo.GetShopOffersAndDeals(shopId);

        public Task<IEnumerable<RecommendedItemEntity>> GetRecommendedAndTopSellingItemsByShop(int shopId)
            => _repo.GetRecommendedAndTopSellingItemsByShop(shopId);


        public Task<long> AddUserWhatsAppSubscribe(UserWhatsAppSubscribeEntity e)
        => _repo.AddUserWhatsAppSubscribe(e);

        public Task<long> AddFoodShopFaqDetails(FoodShopFaqEntity e)
        => _repo.AddFoodShopFaqDetails(e);

        public Task<IEnumerable<FaqCategoryEntity>> GetFaqCategories()
        => _repo.GetFaqCategories();

        public Task<IEnumerable<FoodShopFaqEntity>> GetFoodShopFaqDetails(string shopId)
        => _repo.GetFoodShopFaqDetails(shopId);

        public Task<int> UpdateFoodShopFaqDetails(FoodShopFaqEntity e)
        => _repo.UpdateFoodShopFaqDetails(e);

        public Task<int> UpdateFoodShopFaqStatus(int id, int status)
        => _repo.UpdateFoodShopFaqStatus(id, status);

        public Task<int> DeleteFoodShopFaq(int id)
        => _repo.DeleteFoodShopFaq(id);

        public Task<IEnumerable<TestimonialEntity>> GetRestaurantTestimonials(string shopId)
        => _repo.GetRestaurantTestimonials(shopId);
        public Task<long> AddFeedBack(FoodFeedbackEntity e)
        => _repo.AddFeedBack(e);

        public Task<IEnumerable<RestaurantJobEntity>>
        GetRestaurantJobRequirement(string shopId)
        => _repo.GetRestaurantJobRequirement(shopId);

        public Task<WidgetSettingEntity>
        GetRestaurantWebSiteColor(long shopId)
        => _repo.GetRestaurantWebSiteColor(shopId);

        public Task<int>
        ChangeWebSiteColor(long shopId, string color)
        => _repo.ChangeWebSiteColor(shopId, color);

        public Task<IEnumerable<RestaurantOverviewEntity>>
        GetRestaurantOverViewForWeb(long shopId)
        => _repo.GetRestaurantOverViewForWeb(shopId);

        public Task<string>
        SendWhatsAppMessageForSubscribeUserAutoChat(string shopId)
        => _repo.SendWhatsAppMessageForSubscribeUserAutoChat(shopId);

    }
}
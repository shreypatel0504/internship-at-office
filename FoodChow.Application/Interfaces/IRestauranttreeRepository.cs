using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IRestaurantTreeRepository
    {
        Task<long> AddRestaurantShoptree(RestaurantTreeEntity entity);
        Task<int> UpdateRestaurantShoptree(RestaurantTreeEntity entity);
        Task<int> UpdateRestaurantShoptreeStatus(long id, int status);
        Task<int> UpdateRestaurantShoptreeImage(long id, string image);
        Task<int> DeleteRestaurantShoptree(long id);

        Task<IEnumerable<RestaurantTreeEntity>> GetRestaurantShoptree(string shopId);
        Task<IEnumerable<RestaurantOverviewEntity>> GetRestaurantOverView(long shopId);
        Task<IEnumerable<ShopOfferDealEntity>> GetShopOffersAndDeals(long shopId);
        Task<IEnumerable<RecommendedItemEntity>> GetRecommendedAndTopSellingItemsByShop(int shopId);

        Task<long> AddUserWhatsAppSubscribe(UserWhatsAppSubscribeEntity entity);

        Task<long> AddFoodShopFaqDetails(FoodShopFaqEntity entity);

        Task<IEnumerable<FaqCategoryEntity>> GetFaqCategories();

        Task<IEnumerable<FoodShopFaqEntity>> GetFoodShopFaqDetails(string shopId);

        Task<int> UpdateFoodShopFaqDetails(FoodShopFaqEntity entity);

        Task<int> UpdateFoodShopFaqStatus(int id, int status);

        Task<int> DeleteFoodShopFaq(int id);

        Task<IEnumerable<TestimonialEntity>> GetRestaurantTestimonials(string shopId);
        Task<long> AddFeedBack(FoodFeedbackEntity entity);

        Task<IEnumerable<RestaurantJobEntity>>
        GetRestaurantJobRequirement(string shopId);

        Task<WidgetSettingEntity>
        GetRestaurantWebSiteColor(long shopId);

        Task<int>
        ChangeWebSiteColor(long shopId, string color);

        Task<IEnumerable<RestaurantOverviewEntity>>
        GetRestaurantOverViewForWeb(long shopId);

        Task<string>
        SendWhatsAppMessageForSubscribeUserAutoChat(string shopId);
    }
}
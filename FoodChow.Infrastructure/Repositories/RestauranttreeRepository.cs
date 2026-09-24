using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class RestaurantTreeRepository : IRestaurantTreeRepository
    {
        private readonly MySqlDalc _dalc;

        public RestaurantTreeRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<long> AddRestaurantShoptree(RestaurantTreeEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddRestaurantShoptree",
                new
                {
                    p_shop_id = e.ShopId,
                    p_label = e.Label,
                    p_icon_class = e.IconClass,
                    p_icon_path = e.IconPath,
                    p_link_url = e.LinkUrl,
                    p_display_position = e.DisplayPosition
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateRestaurantShoptree(RestaurantTreeEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateRestaurantShoptree",
                new
                {
                    p_id = e.Id,
                    p_label = e.Label,
                    p_link_url = e.LinkUrl,
                    p_display_position = e.DisplayPosition
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateRestaurantShoptreeStatus(long id, int status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateRestaurantShoptreeStatus",
                new { p_id = id, p_status = status },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateRestaurantShoptreeImage(long id, string image)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateRestaurantShoptreeImage",
                new { p_id = id, p_icon_path = image },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteRestaurantShoptree(long id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteRestaurantShoptree",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RestaurantTreeEntity>> GetRestaurantShoptree(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<RestaurantTreeEntity>(
                "USP_GetRestaurantShoptree",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RestaurantOverviewEntity>> GetRestaurantOverView(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<RestaurantOverviewEntity>(
                "USP_GetRestaurantOverView",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ShopOfferDealEntity>> GetShopOffersAndDeals(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<ShopOfferDealEntity>(
                "USP_GetShopOffersAndDeals",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<RecommendedItemEntity>>
GetRecommendedAndTopSellingItemsByShop(int shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<RecommendedItemEntity>(
                "USP_GetRecommendedAndTopSellingItemsByShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddUserWhatsAppSubscribe(UserWhatsAppSubscribeEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddUserWhatsAppSubscribe",
                new
                {
                    p_shop_id = e.ShopId,
                    p_mobile_no = e.MobileNo,
                    p_cust_name = e.CustName,
                    p_country_code = e.CountryCode
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddFoodShopFaqDetails(FoodShopFaqEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddFoodShopFaqDetails",
                new
                {
                    p_shop_id = e.ShopId,
                    p_label = e.Label,
                    p_description = e.Description,
                    p_faq_category_id = e.FaqCategoryId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FaqCategoryEntity>> GetFaqCategories()
        {
            return await _dalc.CreateConnection().QueryAsync<FaqCategoryEntity>(
                "USP_GetFaqCategories",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FoodShopFaqEntity>>
        GetFoodShopFaqDetails(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodShopFaqEntity>(
                "USP_GetFoodShopFaqDetails",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateFoodShopFaqDetails(FoodShopFaqEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateFoodShopFaqDetails",
                new
                {
                    p_id = e.Id,
                    p_label = e.Label,
                    p_description = e.Description,
                    p_faq_category_id = e.FaqCategoryId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateFoodShopFaqStatus(int id, int status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateFoodShopFaqStatus",
                new
                {
                    p_id = id,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteFoodShopFaq(int id)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteFoodShopFaq",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TestimonialEntity>>
        GetRestaurantTestimonials(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<TestimonialEntity>(
                "USP_GetRestaurantTestimonials",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<long> AddFeedBack(FoodFeedbackEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddFeedBack",
                new
                {
                    p_shop_id = e.ShopId,
                    p_name = e.Name,
                    p_mobile_no = e.MobileNo,
                    p_email_id = e.EmailId,
                    p_experience = e.Experience,
                    p_subject = e.Subject,
                    p_message = e.Message
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<RestaurantJobEntity>>GetRestaurantJobRequirement(string shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<RestaurantJobEntity>(
                "USP_GetRestaurantJobRequirement",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<WidgetSettingEntity>GetRestaurantWebSiteColor(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WidgetSettingEntity>(
                "USP_GetRestaurantWebSiteColor",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> ChangeWebSiteColor(long shopId, string color)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_ChangeWebSiteColor",
                new
                {
                    p_shop_id = shopId,
                    p_color = color
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RestaurantOverviewEntity>>GetRestaurantOverViewForWeb(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<RestaurantOverviewEntity>(
                "USP_GetRestaurantOverViewForWeb",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> SendWhatsAppMessageForSubscribeUserAutoChat(string shopId)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<string>(
                "USP_SendWhatsAppMessageForSubscribeUserAutoChat",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
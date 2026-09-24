using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class MarketingMaterialRepository : IMarketingMaterialRepository
    {
        private readonly MySqlDalc _dalc;

        public MarketingMaterialRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<MarketingEntity>> GetMarketing(long shopId)
            => await _dalc.CreateConnection().QueryAsync<MarketingEntity>(
                "USP_GetMarketing",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddMarketing(MarketingEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddMarketing",
                new
                {
                    p_shop_id = e.ShopId,
                    p_from_email = e.FromEmail,
                    p_from_name = e.FromName,
                    p_to_email = e.ToEmail,
                    p_to_name = e.ToName,
                    p_message = e.Message,
                    p_attachment = e.Attachment,
                    p_subject = e.Subject,
                    p_debit_id = e.DebitId,
                    p_is_subscribe = e.IsSubscribe
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateMarketing(MarketingEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateMarketing",
                new
                {
                    p_id = e.Id,
                    p_from_email = e.FromEmail,
                    p_from_name = e.FromName,
                    p_to_email = e.ToEmail,
                    p_to_name = e.ToName,
                    p_message = e.Message,
                    p_attachment = e.Attachment,
                    p_subject = e.Subject,
                    p_debit_id = e.DebitId,
                    p_is_subscribe = e.IsSubscribe
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteMarketing(long id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteMarketing",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<BannerEntity>> GetBanners(long shopId)
            => await _dalc.CreateConnection().QueryAsync<BannerEntity>(
                "USP_GetBanners",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddBanner(BannerEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddBanner",
                new
                {
                    p_shop_id = e.ShopId,
                    p_banner_image = e.BannerImage
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<SeoEntity> GetSeo(long shopId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<SeoEntity>(
                "USP_GetSeo",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> SaveSeo(SeoEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveSeo",
                new
                {
                    p_shop_id = e.ShopId,
                    p_title = e.Title,
                    p_description = e.Description
                },
                commandType: CommandType.StoredProcedure);

        public async Task<WidgetEntity> GetWidget(long shopId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WidgetEntity>(
                "USP_GetWidget",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> SaveWidget(WidgetEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveWidget",
                new
                {
                    p_shop_id = e.ShopId,
                    p_color_picker = e.ColorPicker,
                    p_website_color = e.WebsiteColor
                },
                commandType: CommandType.StoredProcedure);
    }
}
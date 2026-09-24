using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class WidgetSettingsRepository : IWidgetSettingsRepository
    {
        private readonly MySqlDalc _dalc;

        public WidgetSettingsRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<SeoConfigEntity> GetSeoConfig(long shopId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<SeoConfigEntity>(
                "USP_GetSeoConfig",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> SaveSeoConfig(SeoConfigEntity e)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveSeoConfig",
                new
                {
                    p_shop_id = e.ShopId,
                    p_title = e.Title,
                    p_description = e.Description
                },
                commandType: CommandType.StoredProcedure);

        public async Task<WidgetSettingEntity> GetWidgetSettings(long shopId)
            => await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WidgetSettingEntity>(
                "USP_GetWidgetSettings",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int> SaveWidgetSettings(WidgetSettingEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveWidgetSettings",
                new
                {
                    p_shop_id = e.ShopId,
                    p_email_required = e.EmailRequired,
                    p_email_compulsary = e.EmailCompulsary,
                    p_color_picker = e.ColorPicker,
                    p_widget_setting = e.WidgetSetting,
                    p_website_color = e.WebsiteColor
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ChangeWebsiteColor(long shopId, string color)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_ChangeWebsiteColor",
                new
                {
                    p_shop_id = shopId,
                    p_color = color
                },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<VideoHelpEntity>> GetVideoHelp()
            => await _dalc.CreateConnection().QueryAsync<VideoHelpEntity>(
                "USP_GetVideoHelp",
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<VideoHelpEntity>> GetVideoHelpBySection(string section)
            => await _dalc.CreateConnection().QueryAsync<VideoHelpEntity>(
                "USP_GetVideoHelpBySection",
                new { p_section = section },
                commandType: CommandType.StoredProcedure);

        public async Task<int> AddVideoHelp(VideoHelpEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddVideoHelp",
                new
                {
                    p_section = e.Section,
                    p_video_link = e.VideoLink,
                    p_mobile_video_link = e.MobileVideoLink
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateVideoHelp(VideoHelpEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateVideoHelp",
                new
                {
                    p_id = e.Id,
                    p_section = e.Section,
                    p_video_link = e.VideoLink,
                    p_mobile_video_link = e.MobileVideoLink,
                    p_status = e.Status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteVideoHelp(int id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteVideoHelp",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<WidgetSettingEntity> GetStoreWidgetSettings(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<WidgetSettingEntity>(
                "USP_GetStoreWidgetSettings",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateWidgetSettingsGlobal(long shopId, string websiteColor)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateWidgetSettingsGlobal",
                new
                {
                    p_shop_id = shopId,
                    p_website_color = websiteColor
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> CheckStoreCustomDomain(long shopId)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<bool>(
                "USP_CheckStoreCustomDomain",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateFoodchowVideoHelpStatus(int id, int status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateFoodchowVideoHelpStatus",
                new
                {
                    p_id = id,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
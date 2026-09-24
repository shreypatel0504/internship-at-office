using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IWidgetSettingsRepository
    {
        Task<SeoConfigEntity> GetSeoConfig(long shopId);
        Task<int> SaveSeoConfig(SeoConfigEntity entity);

        Task<WidgetSettingEntity> GetWidgetSettings(long shopId);
        Task<int> SaveWidgetSettings(WidgetSettingEntity entity);
        Task<int> ChangeWebsiteColor(long shopId, string color);

        Task<IEnumerable<VideoHelpEntity>> GetVideoHelp();
        Task<IEnumerable<VideoHelpEntity>> GetVideoHelpBySection(string section);
        Task<int> AddVideoHelp(VideoHelpEntity entity);
        Task<int> UpdateVideoHelp(VideoHelpEntity entity);
        Task<int> DeleteVideoHelp(int id);
        Task<WidgetSettingEntity> GetStoreWidgetSettings(long shopId);
        Task<int> UpdateWidgetSettingsGlobal(long shopId, string websiteColor);
        Task<bool> CheckStoreCustomDomain(long shopId);
        Task<int> UpdateFoodchowVideoHelpStatus(int id, int status);
    }
}
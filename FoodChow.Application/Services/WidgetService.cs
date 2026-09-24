using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class WidgetSettingsService
    {
        private readonly IWidgetSettingsRepository _repo;

        public WidgetSettingsService(IWidgetSettingsRepository repo)
        {
            _repo = repo;
        }

        public Task<SeoConfigEntity> GetSeoConfig(long id)
            => _repo.GetSeoConfig(id);

        public Task<int> SaveSeoConfig(SeoConfigEntity e)
            => _repo.SaveSeoConfig(e);

        public Task<WidgetSettingEntity> GetWidgetSettings(long id)
            => _repo.GetWidgetSettings(id);

        public Task<int> SaveWidgetSettings(WidgetSettingEntity e)
            => _repo.SaveWidgetSettings(e);

        public Task<int> ChangeWebsiteColor(long id, string color)
            => _repo.ChangeWebsiteColor(id, color);

        public Task<IEnumerable<VideoHelpEntity>> GetVideoHelp()
            => _repo.GetVideoHelp();

        public Task<IEnumerable<VideoHelpEntity>> GetVideoHelpBySection(string section)
            => _repo.GetVideoHelpBySection(section);

        public Task<int> AddVideoHelp(VideoHelpEntity e)
            => _repo.AddVideoHelp(e);

        public Task<int> UpdateVideoHelp(VideoHelpEntity e)
            => _repo.UpdateVideoHelp(e);

        public Task<int> DeleteVideoHelp(int id)
            => _repo.DeleteVideoHelp(id);

        public Task<WidgetSettingEntity> GetStoreWidgetSettings(long shopId)
            => _repo.GetStoreWidgetSettings(shopId);

        public Task<int> UpdateWidgetSettingsGlobal(long shopId, string websiteColor)
            => _repo.UpdateWidgetSettingsGlobal(shopId, websiteColor);

        public Task<bool> CheckStoreCustomDomain(long shopId)
            => _repo.CheckStoreCustomDomain(shopId);

        public Task<int> UpdateFoodchowVideoHelpStatus(int id, int status)
            => _repo.UpdateFoodchowVideoHelpStatus(id, status);
    }
}
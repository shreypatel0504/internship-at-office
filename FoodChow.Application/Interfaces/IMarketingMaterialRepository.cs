using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IMarketingMaterialRepository
    {
        Task<IEnumerable<MarketingEntity>> GetMarketing(long shopId);
        Task<long> AddMarketing(MarketingEntity e);
        Task<int> UpdateMarketing(MarketingEntity e);
        Task<int> DeleteMarketing(long id);

        Task<IEnumerable<BannerEntity>> GetBanners(long shopId);
        Task<long> AddBanner(BannerEntity e);

        Task<SeoEntity> GetSeo(long shopId);
        Task<int> SaveSeo(SeoEntity e);

        Task<WidgetEntity> GetWidget(long shopId);
        Task<int> SaveWidget(WidgetEntity e);
    }
}
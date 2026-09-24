using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class MarketingMaterialService
    {
        private readonly IMarketingMaterialRepository _repo;

        public MarketingMaterialService(IMarketingMaterialRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<MarketingEntity>> GetMarketing(long shopId)
            => _repo.GetMarketing(shopId);

        public Task<long> AddMarketing(MarketingEntity e)
            => _repo.AddMarketing(e);

        public Task<int> UpdateMarketing(MarketingEntity e)
            => _repo.UpdateMarketing(e);

        public Task<int> DeleteMarketing(long id)
            => _repo.DeleteMarketing(id);

        public Task<IEnumerable<BannerEntity>> GetBanners(long shopId)
            => _repo.GetBanners(shopId);

        public Task<long> AddBanner(BannerEntity e)
            => _repo.AddBanner(e);

        public Task<SeoEntity> GetSeo(long shopId)
            => _repo.GetSeo(shopId);

        public Task<int> SaveSeo(SeoEntity e)
            => _repo.SaveSeo(e);
    }
}
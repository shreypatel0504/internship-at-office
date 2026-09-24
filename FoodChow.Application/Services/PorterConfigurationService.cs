using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class PorterConfigurationService
    {
        private readonly IPorterConfigurationRepository repo;

        public PorterConfigurationService(IPorterConfigurationRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<PorterConfigurationDto>> Get(long shopId)
        {
            return await repo.Get(shopId);
        }

        public async Task<PorterConfigurationDto?> GetById(long id, long shopId)
        {
            return await repo.GetById(id, shopId);
        }

        public async Task<long> Add(AddPorterConfigurationDto dto)
        {
            return await repo.Add(dto);
        }

        public async Task<bool> Update(UpdatePorterConfigurationDto dto)
        {
            return await repo.Update(dto);
        }

        public async Task<bool> Delete(long id, long shopId)
        {
            return await repo.Delete(id, shopId);
        }
    }
}
using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IPorterConfigurationRepository
    {
        Task<IEnumerable<PorterConfigurationDto>> Get(long shopId);

        Task<PorterConfigurationDto?> GetById(long id, long shopId);

        Task<long> Add(AddPorterConfigurationDto dto);

        Task<bool> Update(UpdatePorterConfigurationDto dto);

        Task<bool> Delete(long id, long shopId);
    }
}
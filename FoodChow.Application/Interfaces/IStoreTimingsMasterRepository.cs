using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IStoreTimingsMasterRepository
    {
        Task<IEnumerable<StoreTimingsMasterDto>> GetAllAsync(long shopId);
        Task<StoreTimingsMasterDto?> GetByShopsync(long id, long shopId);
        Task<long> AddAsync(AddStoreTimingsMasterDto dto);
        Task<int> UpdateAsync(UpdateStoreTimingsMasterDto dto);
        Task<int> DeleteAsync(long id, long shopId);
        Task<int> BulkAddAsync(AddStoreTimingsMasterDto dto);
        Task<int> BulkUpdateAsync(UpdateStoreTimingsMasterDto dto);
    }
}
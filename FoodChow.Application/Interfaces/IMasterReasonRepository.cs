using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IMasterReasonRepository
    {
        Task<IEnumerable<MasterReasonDto>> GetAllAsync();

        Task<MasterReasonDto?> GetByIdAsync(long reasonId);

        Task<long> AddAsync(CreateMasterReasonDto dto);

        Task<int> UpdateAsync(UpdateMasterReasonDto dto);

        Task<int> DeleteAsync(long reasonId);
    }
}
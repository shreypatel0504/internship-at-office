using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IKdsTerminalsSettingRepository
    {
        // ✅ Add
        Task<long> AddAsync(AddKdsTerminalSettingDto dto);

        // ✅ Update
        Task<bool> UpdateAsync(UpdateKdsTerminalSettingDto dto);

        // ✅ Delete
        Task<bool> DeleteAsync(long id, long shopId);

        // ✅ Get All
        Task<IEnumerable<KdsTerminalsSettingResponseDto>> GetAllAsync(long shopId);

        // ✅ Get By Id
        Task<KdsTerminalsSettingResponseDto?> GetByIdAsync(long id, long shopId);
    }
}
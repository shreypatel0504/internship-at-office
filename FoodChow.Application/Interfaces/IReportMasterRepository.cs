using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IReportMasterRepository
    {
        Task<IEnumerable<ReportMasterDto>> GetAllAsync(long shopId);
        Task<ReportMasterDto?> GetByIdAsync(long id, long shopId);
        Task<IEnumerable<ReportMasterDto>> GetByFilterAsync(ReportFilterDto filter);
        Task<long> AddAsync(AddReportMasterDto dto);
        Task<int> UpdateAsync(UpdateReportMasterDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
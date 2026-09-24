using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class ReportMasterRepository(MySqlDalc dalc) : IReportMasterRepository
    {
        // ✅ Get All
        public Task<IEnumerable<ReportMasterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<ReportMasterDto>(
                "USP_GetAllReports",
                new { p_shop_id = shopId });

        // ✅ Get By Id
        public Task<ReportMasterDto?> GetByIdAsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<ReportMasterDto>(
                "USP_GetReportById",
                new { p_id = id, p_shop_id = shopId });

        // ✅ Get By Filter
        public Task<IEnumerable<ReportMasterDto>> GetByFilterAsync(ReportFilterDto filter) =>
            dalc.ExecuteSpListAsync<ReportMasterDto>(
                "USP_GetReportByFilter", new
                {
                    p_shop_id = filter.ShopId,
                    p_report_type = filter.ReportType ?? string.Empty,
                    p_from_date = filter.FromDate,
                    p_to_date = filter.ToDate
                });

        // ✅ Add
        public Task<long> AddAsync(AddReportMasterDto dto) =>
            dalc.ExecuteSpScalarAsync<long>(
                "USP_AddReport", new
                {
                    p_shop_id = dto.ShopId,
                    p_report_name = dto.ReportName ?? string.Empty,
                    p_report_type = dto.ReportType ?? string.Empty,
                    p_report_format = dto.ReportFormat ?? string.Empty,
                    p_from_date = dto.FromDate,
                    p_to_date = dto.ToDate,
                    p_status = dto.Status ?? "Pending",
                    p_file_path = dto.FilePath ?? string.Empty,
                    p_is_active = dto.IsActive
                });

        // ✅ Update
        public Task<int> UpdateAsync(UpdateReportMasterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateReport", new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_report_name = dto.ReportName ?? string.Empty,
                    p_report_type = dto.ReportType ?? string.Empty,
                    p_report_format = dto.ReportFormat ?? string.Empty,
                    p_from_date = dto.FromDate,
                    p_to_date = dto.ToDate,
                    p_status = dto.Status ?? string.Empty,
                    p_file_path = dto.FilePath ?? string.Empty,
                    p_is_active = dto.IsActive
                });

        // ✅ Delete
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteReport",
                new { p_id = id, p_shop_id = shopId });
    }
}
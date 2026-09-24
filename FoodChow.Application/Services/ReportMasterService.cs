using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class ReportMasterService(IReportMasterRepository repo)
    {
        // ✅ Get All
        public async Task<ApiResponse<IEnumerable<ReportMasterDto>>> GetAllAsync(long shopId)
        {
            try
            {
                if (shopId <= 0)
                    return ApiResponse<IEnumerable<ReportMasterDto>>.Fail("Invalid shop_id.");

                var list = await repo.GetAllAsync(shopId);
                return ApiResponse<IEnumerable<ReportMasterDto>>.Ok(list);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<ReportMasterDto>>.Fail(ex.Message); }
        }

        // ✅ Get By Id
        public async Task<ApiResponse<ReportMasterDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<ReportMasterDto>.Fail("Invalid id.");

                var report = await repo.GetByIdAsync(id, shopId);
                if (report is null)
                    return ApiResponse<ReportMasterDto>.Fail("Report not found.");

                return ApiResponse<ReportMasterDto>.Ok(report);
            }
            catch (Exception ex) { return ApiResponse<ReportMasterDto>.Fail(ex.Message); }
        }

        // ✅ Get By Filter
        public async Task<ApiResponse<IEnumerable<ReportMasterDto>>> GetByFilterAsync(ReportFilterDto filter)
        {
            try
            {
                if (filter.ShopId <= 0)
                    return ApiResponse<IEnumerable<ReportMasterDto>>.Fail("Invalid shop_id.");

                var list = await repo.GetByFilterAsync(filter);
                return ApiResponse<IEnumerable<ReportMasterDto>>.Ok(list);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<ReportMasterDto>>.Fail(ex.Message); }
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddReportMasterDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.ReportName))
                    return ApiResponse<long>.Fail("Report name is required.");

                var newId = await repo.AddAsync(dto);
                return ApiResponse<long>.Ok(newId, "Report added successfully.");
            }
            catch (Exception ex) { return ApiResponse<long>.Fail(ex.Message); }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateReportMasterDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (string.IsNullOrWhiteSpace(dto.ReportName))
                    return ApiResponse<bool>.Fail("Report name is required.");

                await repo.UpdateAsync(dto);
                return ApiResponse<bool>.Ok(true, "Report updated successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }

        // ✅ Delete
        public async Task<ApiResponse<bool>> DeleteAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                await repo.DeleteAsync(id, shopId);
                return ApiResponse<bool>.Ok(true, "Report deleted successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }
    }
}
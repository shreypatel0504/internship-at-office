using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class KdsTerminalsSettingService
    {
        private readonly IKdsTerminalsSettingRepository repo;

        public KdsTerminalsSettingService(IKdsTerminalsSettingRepository repo)
        {
            this.repo = repo;
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddKdsTerminalSettingDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop id.");

                if (string.IsNullOrWhiteSpace(dto.TerminalName))
                    return ApiResponse<long>.Fail("Terminal name is required.");

                var id = await repo.AddAsync(dto);

                return ApiResponse<long>.Ok(
                    id,
                    "KDS terminal setting added successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<long>.Fail(ex.Message);
            }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateKdsTerminalSettingDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                await repo.UpdateAsync(dto);

                return ApiResponse<bool>.Ok(
                    true,
                    "KDS terminal setting updated successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }

        // ✅ Delete
        public async Task<ApiResponse<bool>> DeleteAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                await repo.DeleteAsync(id, shopId);

                return ApiResponse<bool>.Ok(
                    true,
                    "KDS terminal setting deleted successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }

        // ✅ Get All
        public async Task<ApiResponse<IEnumerable<KdsTerminalsSettingResponseDto>>> GetAllAsync(long shopId)
        {
            try
            {
                var data = await repo.GetAllAsync(shopId);

                return ApiResponse<IEnumerable<KdsTerminalsSettingResponseDto>>.Ok(
                    data,
                    "Success"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<KdsTerminalsSettingResponseDto>>
                    .Fail(ex.Message);
            }
        }

        // ✅ Get By Id
        public async Task<ApiResponse<KdsTerminalsSettingResponseDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                var data = await repo.GetByIdAsync(id, shopId);

                if (data == null)
                    return ApiResponse<KdsTerminalsSettingResponseDto>
                        .Fail("Data not found.");

                return ApiResponse<KdsTerminalsSettingResponseDto>.Ok(
                    data,
                    "Success"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<KdsTerminalsSettingResponseDto>
                    .Fail(ex.Message);
            }
        }
    }
}
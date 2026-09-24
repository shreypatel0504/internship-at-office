using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class StoreTimingsMasterService(IStoreTimingsMasterRepository repo)
    {
        // ✅ Get All
        public async Task<ApiResponse<IEnumerable<StoreTimingsMasterDto>>> GetAllAsync(long shopId)
        {
            try
            {
                if (shopId <= 0)
                    return ApiResponse<IEnumerable<StoreTimingsMasterDto>>.Fail("Invalid shop_id.");

                var list = await repo.GetAllAsync(shopId);
                return ApiResponse<IEnumerable<StoreTimingsMasterDto>>.Ok(list);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<StoreTimingsMasterDto>>.Fail(ex.Message); }
        }

        // ✅ Get By Id
        public async Task<ApiResponse<StoreTimingsMasterDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<StoreTimingsMasterDto>.Fail("Invalid id.");

                var timing = await repo.GetByShopsync(id, shopId);
                if (timing is null)
                    return ApiResponse<StoreTimingsMasterDto>.Fail("Store timing not found.");

                return ApiResponse<StoreTimingsMasterDto>.Ok(timing);
            }
            catch (Exception ex) { return ApiResponse<StoreTimingsMasterDto>.Fail(ex.Message); }
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddStoreTimingsMasterDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.DaysName))
                    return ApiResponse<long>.Fail("Day name is required.");

                var newId = await repo.AddAsync(dto);
                return ApiResponse<long>.Ok(newId, "Store timing added successfully.");
            }
            catch (Exception ex) { return ApiResponse<long>.Fail(ex.Message); }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateStoreTimingsMasterDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (dto.ShopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.DaysName))
                    return ApiResponse<bool>.Fail("Day name is required.");

                await repo.UpdateAsync(dto);
                return ApiResponse<bool>.Ok(true, "Store timing updated successfully.");
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

                if (shopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                await repo.DeleteAsync(id, shopId);
                return ApiResponse<bool>.Ok(true, "Store timing deleted successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }

        // ✅ Bulk Save (Add or Update)
        public async Task<ApiResponse<bool>> BulkSaveAsync(BulkStoreTimingsDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<bool>.Fail("Invalid shop_id.");

                if (dto.TimingsList is null || !dto.TimingsList.Any())
                    return ApiResponse<bool>.Fail("Timings list is required.");

                var existing = await repo.GetAllAsync(dto.ShopId);

                if (existing.Any())
                {
                    foreach (var t in dto.TimingsList)
                    {
                        var match = existing.FirstOrDefault(e =>
                            e.DaysName?.ToLower() == t.DaysName?.ToLower());

                        if (match is not null)
                        {
                            await repo.BulkUpdateAsync(new UpdateStoreTimingsMasterDto
                            {
                                Id = match.Id,
                                ShopId = dto.ShopId,
                                DaysName = t.DaysName,
                                OpenTime1 = t.OpenTime1,
                                CloseTime1 = t.CloseTime1,
                                OpenTime2 = t.OpenTime2,
                                CloseTime2 = t.CloseTime2,
                                OpenTime3 = t.OpenTime3,
                                CloseTime3 = t.CloseTime3,
                                CloseDay = t.CloseDay,
                                HrsDay = t.HrsDay,
                                IsActive = t.IsActive
                            });
                        }
                        else
                        {
                            t.ShopId = dto.ShopId;
                            await repo.BulkAddAsync(t);
                        }
                    }
                    return ApiResponse<bool>.Ok(true, "Store timings updated successfully.");
                }
                else
                {
                    foreach (var t in dto.TimingsList)
                    {
                        t.ShopId = dto.ShopId;
                        await repo.BulkAddAsync(t);
                    }
                    return ApiResponse<bool>.Ok(true, "Store timings added successfully.");
                }
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class StoreTimingsMasterRepository(MySqlDalc dalc)
        : IStoreTimingsMasterRepository
    {
        // =========================
        // GET ALL
        // =========================
        public Task<IEnumerable<StoreTimingsMasterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<StoreTimingsMasterDto>(
                "USP_GetAllStoreTimings",
                new
                {
                    p_shop_id = shopId
                });

        // =========================
        // GET BY ID
        // =========================
        public Task<StoreTimingsMasterDto?> GetByShopsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<StoreTimingsMasterDto>(
                "USP_GetStoreTimingsById",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // =========================
        // ADD
        // =========================
        public Task<long> AddAsync(AddStoreTimingsMasterDto dto) =>
    dalc.ExecuteSpScalarAsync<long>(
        "USP_AddStoreTimings",
       new
       {
           p_shop_id = dto.ShopId,
           p_days_name = dto.DaysName,
           p_open_time1 = dto.OpenTime1,
           p_close_time1 = dto.CloseTime1,
           p_open_time2 = dto.OpenTime2,
           p_close_time2 = dto.CloseTime2,
           p_open_time3 = dto.OpenTime3,
           p_close_time3 = dto.CloseTime3,
           p_is_close_day= dto.CloseDay,
           p_is_24hrs_day = dto.HrsDay,
           p_created_by = dto.ShopId
       });

        // =========================
        // UPDATE
        // =========================
        public Task<int> UpdateAsync(UpdateStoreTimingsMasterDto dto) =>
     dalc.ExecuteSpNonQueryAsync(
         "USP_UpdateStoreTimings",
         new
         {
             p_id = dto.Id,           
             p_shop_id = dto.ShopId,
             p_days_name = dto.DaysName ?? string.Empty,
             p_open_time1 = dto.OpenTime1,
             p_close_time1 = dto.CloseTime1,
             p_open_time2 = dto.OpenTime2,
             p_close_time2 = dto.CloseTime2,
             p_open_time3 = dto.OpenTime3,
             p_close_time3 = dto.CloseTime3,
             p_is_close_day = dto.CloseDay,     
             p_is_24hrs_day = dto.HrsDay,
             p_is_active = dto.IsActive
         });

        // =========================
        // DELETE
        // =========================
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteStoreTimings",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // =========================
        // BULK ADD
        // =========================
        public Task<int> BulkAddAsync(AddStoreTimingsMasterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_AddStoreTimings",
               new
               {
                   p_shop_id = dto.ShopId,
                   p_days_name = dto.DaysName ?? string.Empty,

                   p_open_time1 = dto.OpenTime1,
                   p_close_time1 = dto.CloseTime1,

                   p_open_time2 = dto.OpenTime2,
                   p_close_time2 = dto.CloseTime2,

                   p_open_time3 = dto.OpenTime3,
                   p_close_time3 = dto.CloseTime3,

                   p_is_close_day= dto.CloseDay,
                   p_is_24hrs_day = dto.HrsDay,

                   p_created_by = dto.ShopId
               });

        // =========================
        // BULK UPDATE
        // =========================
        public Task<int> BulkUpdateAsync(UpdateStoreTimingsMasterDto dto) =>
    dalc.ExecuteSpNonQueryAsync(
        "USP_UpdateStoreTimings",
        new
        {
            p_id = dto.Id,           
            p_shop_id = dto.ShopId,
            p_days_name = dto.DaysName ?? string.Empty,
            p_open_time1 = dto.OpenTime1,
            p_close_time1 = dto.CloseTime1,
            p_open_time2 = dto.OpenTime2,
            p_close_time2 = dto.CloseTime2,
            p_open_time3 = dto.OpenTime3,
            p_close_time3 = dto.CloseTime3,
            p_is_close_day = dto.CloseDay,     
            p_is_24hrs_day = dto.HrsDay,       
            p_created_by = dto.ShopId
        });
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using FoodChow.Infrastructure.DALC;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTimingsMasterController(
        StoreTimingsMasterService service,
        MySqlDalc dalc) : ControllerBase
    {
        // Helper — TimeSpan? to string (HH:mm:ss for MySQL TIME)
        private static string T(TimeSpan? t) =>
            t.HasValue ? t.Value.ToString(@"hh\:mm\:ss") : "00:00:00";

        // ✅ Format TimeSpan? → "HH:mm:ss" for MySQL TIME type
        private static string FormatTime(TimeSpan? t) =>
            t.HasValue ? t.Value.ToString(@"hh\:mm\:ss") : "00:00:00";

        // ✅ 1 - GET ALL
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] long shopId)
        {
            try
            {
                var result = await service.GetAllAsync(shopId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 2 - GET BY ID
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                var result = await service.GetByIdAsync(id, shopId);
                if (!result.Success) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 3 - ADD
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddStoreTimingsMasterDto dto)
        {
            try
            {
                var result = await service.AddAsync(dto);
                if (!result.Success) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 4 - UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStoreTimingsMasterDto dto)
        {
            try
            {
                var result = await service.UpdateAsync(dto);
                if (!result.Success) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 5 - DELETE
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                var result = await service.DeleteAsync(id, shopId);
                if (!result.Success) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 6 - BULK SAVE
        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSaveAsync([FromBody] BulkStoreTimingsDto dto)
        {
            try
            {
                foreach (var t in dto.TimingsList)
                {
                    await dalc.ExecuteSpNonQueryAsync("USP_AddStoreTimings", new
                    {
                        p_shop_id = t.ShopId,
                        p_days_name = t.DaysName ?? string.Empty,
                        p_open_time1 = FormatTime(t.OpenTime1),
                        p_close_time1 = FormatTime(t.CloseTime1),
                        p_open_time2 = FormatTime(t.OpenTime2),
                        p_close_time2 = FormatTime(t.CloseTime2),
                        p_open_time3 = FormatTime(t.OpenTime3),
                        p_close_time3 = FormatTime(t.CloseTime3),
                        p_is_close_day = t.CloseDay,
                        p_is_24hrs_day = t.HrsDay,
                        p_created_by = dto.ShopId
                    });
                }
                return Ok(new ApiResponse<bool> { Success = true, Message = "Timings saved successfully.", Data = true });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<bool> { Success = false, Message = ex.Message, Data = false });
            }
        }

        // ✅ 7 - POST Save Store Timing
        [HttpPost("SaveStoreTiming")]
        public async Task<IActionResult> SaveStoreTiming([FromBody] BulkStoreTimingsDto timings)
        {
            try
            {
                var existing = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimings",
                    new { p_shop_id = timings.ShopId });

                if (existing.Any())
                {
                    var existingList = existing.ToList();
                    for (int k = 0; k < existingList.Count && k < timings.TimingsList.Count; k++)
                    {
                        var t = timings.TimingsList[k];
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            p_is_24hrs_day = t.HrsDay
                        });
                    }
                }
                else
                {
                    foreach (var t in timings.TimingsList)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            p_is_24hrs_day = t.HrsDay
                        });
                    }
                }
                return Ok(new ApiResponse<object> { Success = true, Message = "Data Updated Successfully!", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 8 - POST Save Store Timing DineIn
        [HttpPost("SaveStoreTimingDineIn")]
        public async Task<IActionResult> SaveStoreTimingDineIn([FromBody] BulkStoreTimingsDto timings)
        {
            try
            {
                var existing = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsDineIn",
                    new { p_shop_id = timings.ShopId });

                if (existing.Any())
                {
                    var existingList = existing.ToList();
                    for (int k = 0; k < existingList.Count && k < timings.TimingsList.Count; k++)
                    {
                        var t = timings.TimingsList[k];
                        var id = Convert.ToInt64(((IDictionary<string, object>)existingList[k])["id"]);
                        await dalc.ExecuteSpNonQueryAsync("USP_UpdateFoodShopTimings_dinein", new
                        {
                            id = id,
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            C24hrs_day = t.HrsDay,
                            created_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                }
                else
                {
                    foreach (var t in timings.TimingsList)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings_dinein", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            p_is_24hrs_day = t.HrsDay
                        });
                    }
                }
                return Ok(new ApiResponse<object> { Success = true, Message = "Data Updated Successfully!", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 9 - POST Save Store Timing Delivery
        [HttpPost("SaveStoreTimingDelivery")]
        public async Task<IActionResult> SaveStoreTimingDelivery([FromBody] BulkStoreTimingsDto timings)
        {
            try
            {
                var existing = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsDelivery",
                    new { p_shop_id = timings.ShopId });

                if (existing.Any())
                {
                    var existingList = existing.ToList();
                    for (int k = 0; k < existingList.Count && k < timings.TimingsList.Count; k++)
                    {
                        var t = timings.TimingsList[k];
                        var id = Convert.ToInt64(((IDictionary<string, object>)existingList[k])["id"]);
                        await dalc.ExecuteSpNonQueryAsync("USP_UpdateFoodShopTimings_delivery", new
                        {
                            id = id,
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            C24hrs_day = t.HrsDay,
                            created_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                }
                else
                {
                    foreach (var t in timings.TimingsList)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings_delivery", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            p_is_24hrs_day = t.HrsDay
                        });
                    }
                }
                return Ok(new ApiResponse<object> { Success = true, Message = "Data Updated Successfully!", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 10 - POST Save Store Timing Pickup
        [HttpPost("SaveStoreTimingPickup")]
        public async Task<IActionResult> SaveStoreTimingPickup([FromBody] BulkStoreTimingsDto timings)
        {
            try
            {
                var existing = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsPickup",
                    new { p_shop_id = timings.ShopId });

                if (existing.Any())
                {
                    var existingList = existing.ToList();
                    for (int k = 0; k < existingList.Count && k < timings.TimingsList.Count; k++)
                    {
                        var t = timings.TimingsList[k];
                        var id = Convert.ToInt64(((IDictionary<string, object>)existingList[k])["id"]);
                        await dalc.ExecuteSpNonQueryAsync("USP_UpdateFoodShopTimings_pickup", new
                        {
                            id = id,
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            C24hrs_day = t.HrsDay,
                            created_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                }
                else
                {
                    foreach (var t in timings.TimingsList)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings_pickup", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = T(t.OpenTime1),
                            close_time1 = T(t.CloseTime1),
                            open_time2 = T(t.OpenTime2),
                            close_time2 = T(t.CloseTime2),
                            open_time3 = T(t.OpenTime3),
                            close_time3 = T(t.CloseTime3),
                            p_is_close_day = t.CloseDay,
                            p_is_24hrs_day = t.HrsDay
                        });
                    }
                }
                return Ok(new ApiResponse<object> { Success = true, Message = "Data Updated Successfully!", Data = "" });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = "" });
            }
        }

        // ✅ 11 - GET Shop Timings
        [HttpGet("GetShopTimings")]
        public async Task<IActionResult> GetShopTimings([FromQuery] long shop_id)
        {
            try
            {
                var data = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimings",
                    new { p_shop_id = shop_id });
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 12 - GET Shop Timings DineIn
        [HttpGet("GetShopTimingsDineIn")]
        public async Task<IActionResult> GetShopTimingsDineIn([FromQuery] long shop_id)
        {
            try
            {
                var data = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsDineIn",
                    new { p_shop_id = shop_id });
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 13 - GET Shop Timings Delivery
        [HttpGet("GetShopTimingsDelivery")]
        public async Task<IActionResult> GetShopTimingsDelivery([FromQuery] long shop_id)
        {
            try
            {
                var data = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsDelivery",
                    new { p_shop_id = shop_id });
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 14 - GET Shop Timings Pickup
        [HttpGet("GetShopTimingsPickup")]
        public async Task<IActionResult> GetShopTimingsPickup([FromQuery] long shop_id)
        {
            try
            {
                var data = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimingsPickup",
                    new { p_shop_id = shop_id });
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 15 - GET Update Store PreOrder Status
       
        [HttpGet("UpdateStorePreOrderStatus")]
        public async Task<IActionResult> UpdateStorePreOrderStatus(
    [FromQuery] long shop_id,
    [FromQuery] long pre_order_status)
        {
            try
            {
                var data = await dalc.ExecuteSpNonQueryAsync(
                    "USP_UpdateStorePreOrderStatus",
                    new
                    {
                        p_shop_id = shop_id,
                        p_pre_order_status = pre_order_status
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
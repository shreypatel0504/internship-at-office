using Dapper;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Application.Services;
using FoodChow.Infrastructure.DALC;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantProfileController(
        RestaurantProfileService service,
        IRestaurantProfileRepository repo,
        MySqlDalc dalc) : ControllerBase
    {
     
        // ✅ 1 - GET BY SHOP ID
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] long shopId)
        {
            try
            {
                var result = await service.GetByShopIdAsync(shopId);
                if (!result.Success) return NotFound(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 2 - ADD
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddRestaurantProfileDto dto)
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

        // ✅ 3 - UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRestaurantProfileDto dto)
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

        // ✅ 4 - DELETE
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

        // ✅ 5 - POST Save Owner Information
        [HttpPost("SaveOwnerInformation")]
        public async Task<IActionResult> SaveOwnerInformation([FromBody] ShopOwnerInfoDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Please Enter Valid Parameter", Data = null });

                await dalc.ExecuteSpNonQueryAsync("USP_UpdateFoodShopOwnerInfo_SP", new
                {
                    shop_id = dto.ShopId,
                    first_name = dto.FirstName ?? string.Empty,
                    last_name = dto.LastName ?? string.Empty,
                    other_email = dto.OwnerEmail ?? string.Empty,
                    phoneno = dto.PhoneNo ?? string.Empty,
                    promo_code = dto.PromoCode ?? string.Empty,
                    CountryCode = dto.CountryCode ?? string.Empty
                });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "Data Updated Successfully..." });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 6 - GET Restaurant Information
        [HttpGet("GetRestaurantInformation")]
        public async Task<IActionResult> GetRestaurantInformation([FromQuery] long shop_id)
        {
            try
            {
                if (shop_id <= 0)
                    return Ok(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Please Enter Valid Parameter",
                        Data = null
                    });

                var shopInfo = await dalc.ExecuteSpSingleAsync<dynamic>(
                         "USP_GetShopDetailsById",
                         new
                         {
                             p_shop_id = shop_id
                         });

                if (shopInfo is null)
                    return Ok(new ApiResponse<object>
                    {
                        Success = true,
                        Message = "Success",
                        Data = "Data Not Found..."
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = shopInfo
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

        // ✅ 7 - GET Shop Types And Cuisine
        [HttpGet("GetShopTypesAndCuisine")]
        public async Task<IActionResult> GetShopTypesAndCuisine()
        {
            try
            {
                var shopTypes = await dalc.ExecuteSpListAsync<dynamic>("USP_GetAllShopType");
                var cuisineTypes = await dalc.ExecuteSpListAsync<dynamic>("USP_GetCuisineTypeList");
                var businessTypes = await dalc.ExecuteSpListAsync<dynamic>("USP_GetStoreBusinessType");

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = new
                    {
                        shopTypes,
                        cuisineTypes,
                        businessTypes
                    }
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }
           [HttpPost("UpdateShopAddressTest")]
        public IActionResult Test([FromBody] object dto)
        {
            return Ok(dto);
        }

        // ✅ 8 - POST Update Shop Profile
        [HttpPost("UpdateShopProfile")]
        public async Task<IActionResult> UpdateShopProfile([FromBody] ShopInfoDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Please Enter Valid Parameter", Data = null });

                await dalc.ExecuteSpNonQueryAsync("update_shop_details", new
                {
                    shop_id = dto.ShopId,
                    shop_name = dto.ShopName ?? string.Empty,
                    email_id = dto.EmailId ?? string.Empty,
                    mobileno = dto.MobileNo ?? string.Empty,
                    CountryCode = dto.CountryCode ?? string.Empty,
                    timezone = dto.Timezone ?? string.Empty,
                    subdomain = dto.Subdomain ?? string.Empty,
                    shoplogo = dto.ShopLogo ?? string.Empty,
                    type_id = dto.BusinessTypeId ?? string.Empty,
                    cuisine_type = dto.CuisineType ?? string.Empty,
                    shop_type = dto.ShopType ?? string.Empty,
                    insta_url = dto.InstaUrl ?? string.Empty,
                    updated_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "Data Updated Successfully..." });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 9 - GET Restaurant Address
        [HttpGet("GetRestaurantAddress")]
        public async Task<IActionResult> GetRestaurantAddress([FromQuery] long shop_id)
        {
            try
            {
                if (shop_id <= 0)
                {
                    return Ok(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Invalid shop_id",
                        Data = null
                    });
                }

                using var conn = dalc.CreateConnection();

                var query = @"
            SELECT fs.*, fsadd.*
            FROM food_shop fs
            INNER JOIN food_shop_address fsadd
                ON fs.food_shop_address_id = fsadd.id
            WHERE fs.shop_id = @ShopId";

                var address = await conn.QueryFirstOrDefaultAsync<dynamic>(
                    query,
                    new { ShopId = shop_id });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = address
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

        // ✅ 10 - POST Update Shop Address
        [HttpPost("UpdateShopAddress")]
        public async Task<IActionResult> UpdateShopAddress([FromBody] ShopAddressDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Please Enter Valid Parameter", Data = null });

                await dalc.ExecuteSpNonQueryAsync("USP_UpdateAddress", new
                {
                    Id = dto.Id,
                    Address = dto.Address ?? string.Empty,
                    Country = dto.Country ?? string.Empty,
                    State = dto.State ?? string.Empty,
                    City = dto.City ?? string.Empty,
                    Area = dto.Area ?? string.Empty,
                    Pincode = dto.Pincode ?? string.Empty,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                    Address1 = dto.Address1 ?? string.Empty,
                    HouseNo = dto.HouseNo ?? string.Empty
                });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "Data Updated Successfully..." });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 11 - GET Shop Timings
        [HttpGet("GetShopTimings")]
        public async Task<IActionResult> GetShopTimings([FromQuery] long shop_id)
        {
            try
            {
                if (shop_id <= 0)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Please Enter Valid Parameter", Data = null });

                var result = await dalc.ExecuteSpListAsync<ShopTimeDto>(
                    "USP_GetShopTimings",
                    new { p_shop_id = shop_id });

                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = result });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ 12 - POST Update Shop Timings
        [HttpPost("UpdateShopTimings")]
        public async Task<IActionResult> UpdateShopTimings([FromBody] ShopTimingsModelDto timings)
        {
            try
            {
                if (timings.ShopId <= 0)
                    return Ok(new ApiResponse<object> { Success = false, Message = "Please Enter Valid Parameter", Data = null });

                var existing = await dalc.ExecuteSpListAsync<dynamic>(
                    "USP_GetShopTimings",
                    new { p_shop_id = timings.ShopId });

                if (existing.Any())
                {
                    foreach (var t in timings.LstShopTimings)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_UpdateFoodShopTimings", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = t.OpenTime1 ?? string.Empty,
                            close_time1 = t.CloseTime1 ?? string.Empty,
                            open_time2 = t.OpenTime2 ?? string.Empty,
                            close_time2 = t.CloseTime2 ?? string.Empty,
                            open_time3 = t.OpenTime3 ?? string.Empty,
                            close_time3 = t.CloseTime3 ?? string.Empty,
                            p_is_close_day = t.CloseDay,
                            C24hrs_day = t.HrsDay,
                            created_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                    return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "Data Updated Successfully..." });
                }
                else
                {
                    foreach (var t in timings.LstShopTimings)
                    {
                        await dalc.ExecuteSpNonQueryAsync("USP_AddToFoodShopTimings", new
                        {
                            shop_id = t.ShopId,
                            days_name = t.DaysName ?? string.Empty,
                            open_time1 = t.OpenTime1 ?? string.Empty,
                            close_time1 = t.CloseTime1 ?? string.Empty,
                            open_time2 = t.OpenTime2 ?? string.Empty,
                            close_time2 = t.CloseTime2 ?? string.Empty,
                            open_time3 = t.OpenTime3 ?? string.Empty,
                            close_time3 = t.CloseTime3 ?? string.Empty,
                            p_is_close_day = t.CloseDay,
                            C24hrs_day = t.HrsDay
                        });
                    }
                    return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = "Data Saved Successfully..." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
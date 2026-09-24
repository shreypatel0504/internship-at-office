using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingPlanController(IPricingPlanRepository repo) : ControllerBase
    {
        // ===================== COUNTRY POS =====================

        [HttpPost("country-pos/add")]
        public async Task<IActionResult> AddCountryPos(PosCountryPlanDto dto)
        {
            try
            {
                var res = await repo.AddCountryPlanPosAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "POS Country Plan Added",
                    Data = res
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

        [HttpPut("country-pos/update")]
        public async Task<IActionResult> UpdateCountryPos(PosCountryPlanDto dto)
        {
            try
            {
                var res = await repo.UpdateCountryPlanPosAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "POS Country Plan Updated",
                    Data = res
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

        [HttpGet("country-pos/get")]
        public async Task<IActionResult> GetCountryPos(string countryName)
        {
            try
            {
                var res = await repo.GetCountryPlanPosAsync(countryName);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = res
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

        // ===================== COUNTRY ONLINE =====================

        [HttpPost("country-online/add")]
        public async Task<IActionResult> AddCountryOnline(CountryPlanOnlineDto dto)
        {
            try
            {
                var res = await repo.AddCountryPlanOnlineAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Online Country Plan Added",
                    Data = res
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

        [HttpPut("country-online/update")]
        public async Task<IActionResult> UpdateCountryOnline(CountryPlanOnlineDto dto)
        {
            try
            {
                var res = await repo.UpdateCountryPlanOnlineAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Online Country Plan Updated",
                    Data = res
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

        [HttpGet("country-online/get")]
        public async Task<IActionResult> GetCountryOnline(string countryName)
        {
            try
            {
                var res = await repo.GetCountryPlanOnlineAsync(countryName);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = res
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

        // ===================== SHOP MASTER =====================

        [HttpPost("shop-master/add")]
        public async Task<IActionResult> AddShopMaster(ShopPlanOnlineMasterDto dto)
        {
            try
            {
                var res = await repo.AddShopPlanOnlineMasterAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Shop Plan Added",
                    Data = res
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

        [HttpPut("shop-master/update")]
        public async Task<IActionResult> UpdateShopMaster(ShopPlanOnlineMasterDto dto)
        {
            try
            {
                var res = await repo.UpdateShopPlanOnlineMasterAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Shop Plan Updated",
                    Data = res
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

        // ===================== DETAILS =====================

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(string shopId)
        {
            try
            {
                var res = await repo.GetPricingPlanDetailsAsync(shopId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = res
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
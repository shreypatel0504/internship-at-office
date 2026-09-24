using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PaymentConfigurationController(IPaymentConfigurationRepository repo) : ControllerBase
    {
        // ✅ ADD
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePaymentConfigurationDto dto)
        {
            try
            {
                var newId = await repo.AddAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment configuration added",
                    Data = newId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentConfigurationDto dto)
        {
            try
            {
                var result = await repo.UpdateAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment configuration updated",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ GET ALL BY SHOP
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int shopId)
        {
            try
            {
                var data = await repo.GetByShopIdAsync(shopId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ GET BY ID
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id, [FromQuery] int shopId)
        {
            try
            {
                var data = await repo.GetByIdAsync(id, shopId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ GET ACTIVE
        [HttpGet("get-active")]
        public async Task<IActionResult> GetActive([FromQuery] int shopId)
        {
            try
            {
                var data = await repo.GetActiveByShopIdAsync(shopId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ DELETE
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int shopId)
        {
            try
            {
                var result = await repo.DeleteAsync(id, shopId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment configuration deleted",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // ✅ EXISTS CHECK
        [HttpGet("exists")]
        public async Task<IActionResult> Exists([FromQuery] int shopId, [FromQuery] string providerName)
        {
            try
            {
                var result = await repo.ExistsAsync(shopId, providerName);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
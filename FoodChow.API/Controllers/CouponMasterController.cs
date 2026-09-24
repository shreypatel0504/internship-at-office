using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponMasterController(ICouponMasterRepository repo) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CouponMasterDto coupon)
        {
            try
            {
                var result = await repo.AddAsync(coupon);
                return Ok(new ApiResponse<object> { Success = true, Message = "Coupon added", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CouponMasterDto coupon)
        {
            try
            {
                var result = await repo.UpdateAsync(coupon);
                return Ok(new ApiResponse<object> { Success = true, Message = "Coupon updated", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] long shopId)
        {
            try
            {
                var data = await repo.GetAllAsync(shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                var data = await repo.GetByIdAsync(id, shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Success", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] long shopId)
        {
            try
            {
                var result = await repo.DeleteAsync(id, shopId);
                return Ok(new ApiResponse<object> { Success = true, Message = "Deleted", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }
    }
}
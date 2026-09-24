using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiniaPaymentController(IAffiniaPaymentRepository repo) : ControllerBase
    {
        // ========================= ADD =========================
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePaymentDto dto)
        {
            try
            {
                var newId = await repo.CreatePaymentAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment added",
                    Data = newId
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.ToString()
                });
            }
        }

        // ========================= UPDATE =========================
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAffiniaPaymentDto dto)
        {
            try
            {
                var result = await repo.UpdatePaymentAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment updated",
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

        // ========================= GET BY ID =========================
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(
            [FromQuery] long id,
            [FromQuery] long shopId)
        {
            try
            {
                var data = await repo.GetPaymentByIdAsync(id, shopId);

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

        // ========================= DELETE =========================
        [HttpDelete("delete")]
        public async Task<ApiResponse<object>> DeletePaymentAsync(long id, long shopId)
        {
            try
            {
                var result = await repo.DeletePaymentAsync(id, shopId);

                return new ApiResponse<object>
                {
                    Success = result > 0,
                    Message = result > 0 ? "Deleted Successfully" : "Delete Failed",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
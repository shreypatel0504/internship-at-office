using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReportMasterController(ReportMasterService service) : ControllerBase
    {
        // ✅ GET ALL
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

        // ✅ GET BY ID
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

        // ✅ GET BY FILTER
        [HttpPost("get-by-filter")]
        public async Task<IActionResult> GetByFilter([FromBody] ReportFilterDto filter)
        {
            try
            {
                var result = await service.GetByFilterAsync(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ ADD
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddReportMasterDto dto)
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

        // ✅ UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateReportMasterDto dto)
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

        // ✅ DELETE
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
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodUserMasterController(FoodUserMasterService service) : ControllerBase
    {
        // ✅ GET ALL
        [HttpGet("get")]
        //[Authorize]
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
        //[Authorize]
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

        // ✅ REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                var result = await service.RegisterAsync(dto);
                if (!result.Success) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object> { Success = false, Message = ex.Message, Data = null });
            }
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            try
            {
                var result = await service.LoginAsync(dto);
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
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
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
       // [Authorize]
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
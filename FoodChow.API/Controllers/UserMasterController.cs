using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController(IUserMasterRepository repo) : ControllerBase
    {
        // =========================
        // 1 - CHECK MOBILE EXISTS
        // =========================
        [HttpGet("check-user-mobile")]
        public async Task<IActionResult> CheckUserMobile([FromQuery] string mobileNo)
        {
            try
            {
                var data = await repo.CheckUserExistsAsync(mobileNo);

                return Ok(new ApiResponse<object>
                {
                    Success = data != null,
                    Message = data != null ? "User Exists" : "User Not Found",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 2 - CHECK EMAIL EXISTS
        // =========================
        [HttpGet("check-user-email")]
        public async Task<IActionResult> CheckUserEmail([FromQuery] string email)
        {
            try
            {
                var data = await repo.CheckUserEmailExistsAsync(email);

                return Ok(new ApiResponse<object>
                {
                    Success = data != null,
                    Message = data != null ? "User Exists" : "User Not Found",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 3 - LOGIN (MOBILE)
        // =========================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserMasterDTO dto)
        {
            try
            {
                var data = await repo.PerformUserLoginAsync(dto.MobileNo, dto.Password);

                return Ok(new ApiResponse<object>
                {
                    Success = data != null,
                    Message = data != null ? "Login Success" : "Invalid Credentials",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 4 - SOCIAL LOGIN
        // =========================
        [HttpPost("social-login")]
        public async Task<IActionResult> SocialLogin([FromBody] UserMasterDTO dto)
        {
            try
            {
                var data = await repo.PerformSocialLoginAsync(dto.Email, dto.Role);

                return Ok(new ApiResponse<object>
                {
                    Success = data != null,
                    Message = data != null ? "Login Success" : "Login Failed",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 5 - SIGNUP
        // =========================
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserMasterDTO dto)
        {
            try
            {
                await repo.PerformUserSignupAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Signup Successfully",
                    Data = ""
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 6 - UPDATE TOKEN
        // =========================
        [HttpPut("update-token")]
        public async Task<IActionResult> UpdateToken(
            [FromQuery] long userId,
            [FromQuery] string deviceType,
            [FromQuery] string deviceId,
            [FromQuery] string deviceToken)
        {
            try
            {
                await repo.UpdateUserTokenAsync(userId, deviceType, deviceId, deviceToken);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Token Updated Successfully",
                    Data = ""
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =========================
        // 7 - GET BY ID
        // =========================
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long userId)
        {
            try
            {
                var data = await repo.GetUserByIdAsync(userId);

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
                    Data = ""
                });
            }
        }

        // =========================
        // 8 - DELETE USER
        // =========================
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] long userId)
        {
            try
            {
                await repo.DeleteUserAsync(userId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "User Deleted Successfully",
                    Data = ""
                });
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }
    }
}
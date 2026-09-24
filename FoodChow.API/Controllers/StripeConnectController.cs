using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeConnectController(IStripeConnectRepository repo) : ControllerBase
    {
        // =====================================
        // 1 - CREATE STRIPE CONNECT ACCOUNT
        // =====================================
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] StripeConnectDTO dto)
        {
            try
            {
                var id = await repo.CreateStripeConnectAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Stripe Connect Account Created Successfully",
                    Data = id
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

        // =====================================
        // 2 - UPDATE STRIPE CONNECT
        // =====================================
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StripeConnectDTO dto)
        {
            try
            {
                await repo.UpdateStripeConnectAsync(dto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Stripe Connect Updated Successfully",
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

        // =====================================
        // 3 - GET BY SHOP ID
        // =====================================
        [HttpGet("get-by-shop")]
        public async Task<IActionResult> GetByShop([FromQuery] long shopId)
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
                return Ok(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = ""
                });
            }
        }

        // =====================================
        // 4 - GET BY ID
        // =====================================
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] long stripeConnectId)
        {
            try
            {
                var data = await repo.GetByIdAsync(stripeConnectId);

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

        // =====================================
        // 5 - UPDATE STATUS
        // =====================================
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(
            [FromQuery] long stripeConnectId,
            [FromQuery] string status,
            [FromQuery] long updatedBy)
        {
            try
            {
                await repo.UpdateStatusAsync(
                    stripeConnectId,
                    status,
                    updatedBy);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Status Updated Successfully",
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

        // =====================================
        // 6 - SAVE STRIPE ACCOUNT ID
        // =====================================
        [HttpPut("save-account-id")]
        public async Task<IActionResult> SaveAccountId(
            [FromQuery] long shopId,
            [FromQuery] string stripeAccountId)
        {
            try
            {
                await repo.SaveStripeAccountIdAsync(
                    shopId,
                    stripeAccountId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Stripe Account ID Saved Successfully",
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

        // =====================================
        // 7 - SAVE STRIPE CUSTOMER ID
        // =====================================
        [HttpPut("save-customer-id")]
        public async Task<IActionResult> SaveCustomerId(
            [FromQuery] long shopId,
            [FromQuery] string stripeCustomerId)
        {
            try
            {
                await repo.SaveStripeCustomerIdAsync(
                    shopId,
                    stripeCustomerId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Stripe Customer ID Saved Successfully",
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

        // =====================================
        // 8 - DELETE
        // =====================================
        [HttpDelete("delete-connect")]
        public async Task<IActionResult> DeleteConnect(
            [FromQuery] long stripeConnectId)
        {
            try
            {
                await repo.DeleteAsync(stripeConnectId);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Deleted Successfully",
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
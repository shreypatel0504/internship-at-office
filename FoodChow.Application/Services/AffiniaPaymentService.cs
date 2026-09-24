using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class AffiniaPaymentService
    {
        private readonly IAffiniaPaymentRepository _repo;

        public AffiniaPaymentService(IAffiniaPaymentRepository repo)
        {
            _repo = repo;
        }

        // ========================= CREATE PAYMENT =========================
        public async Task<ApiResponse<object>> CreatePaymentAsync(CreatePaymentDto dto)
        {
            try
            {
                var result = await _repo.CreatePaymentAsync(dto);

                if (result <= 0)
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Payment creation failed",
                        Data = null
                    };
                }

                return new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment created successfully",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        // ========================= GET PAYMENT BY ID =========================
        public async Task<ApiResponse<object>> GetPaymentByIdAsync(long paymentId, long shopId)
        {
            try
            {
                var result = await _repo.GetPaymentByIdAsync(paymentId, shopId);

                if (result == null)
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Payment not found",
                        Data = null
                    };
                }

                return new ApiResponse<object>
                {
                    Success = true,
                    Message = "Success",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        // ========================= UPDATE PAYMENT STATUS =========================
        public async Task<ApiResponse<object>> UpdatePaymentAsync(UpdateAffiniaPaymentDto dto)
        {
            try
            {
                var result = await _repo.UpdatePaymentAsync(dto);

                if (result <= 0)
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Payment update failed",
                        Data = null
                    };
                }

                return new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment updated successfully",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<object>> DeletePaymentAsync(long paymentId, long shopId)
        {
            try
            {
                var result = await _repo.DeletePaymentAsync(paymentId, shopId);

                if (result <= 0)
                {
                    return new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Payment delete failed",
                        Data = null
                    };
                }

                return new ApiResponse<object>
                {
                    Success = true,
                    Message = "Payment deleted successfully",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        
         }
    }
}
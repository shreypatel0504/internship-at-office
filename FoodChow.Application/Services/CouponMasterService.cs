using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class CouponMasterService(ICouponMasterRepository repo)
    {
        public async Task<ApiResponse<IEnumerable<CouponMasterDto>>> GetAllAsync(long shopId)
        {
            var list = await repo.GetAllAsync(shopId);
            return ApiResponse<IEnumerable<CouponMasterDto>>.Ok(list);
        }

        public async Task<ApiResponse<CouponMasterDto>> GetByIdAsync(long id, long shopId)
        {
            var coupon = await repo.GetByIdAsync(id, shopId);
            if (coupon is null)
                return ApiResponse<CouponMasterDto>.Fail($"Coupon {id} not found.");
            return ApiResponse<CouponMasterDto>.Ok(coupon);
        }

        public async Task<ApiResponse<int>> AddAsync(CouponMasterDto dto)
        {
            var result = await repo.AddAsync(dto);
            return ApiResponse<int>.Ok(result);
        }

        public async Task<ApiResponse<int>> UpdateAsync(CouponMasterDto dto)
        {
            var result = await repo.UpdateAsync(dto);
            return ApiResponse<int>.Ok(result);
        }

        public async Task<ApiResponse<int>> DeleteAsync(long id, long shopId)
        {
            var result = await repo.DeleteAsync(id, shopId);
            return ApiResponse<int>.Ok(result);
        }
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class CouponMasterRepository(MySqlDalc dalc) : ICouponMasterRepository
    {
        // ✅ GET ALL
        public Task<IEnumerable<CouponMasterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<CouponMasterDto>(
                "USP_get_coupon_master",
                new
                {
                    p_shop_id = shopId
                });

        // ✅ GET BY ID
        public Task<CouponMasterDto?> GetByIdAsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<CouponMasterDto>(
                "USP_get_coupon_master_by_id",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

        // ✅ ADD
        public Task<int> AddAsync(CouponMasterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_add_coupon_master",
                new
                {
                    p_shop_id = dto.ShopId,
                    p_name = dto.Name,
                    p_description = dto.Description,
                    p_minimum_order_amount = dto.MinimumOrderAmount,
                    p_coupon_code = dto.CouponCode,
                    p_discount = dto.Discount,
                    p_discount_in = dto.DiscountIn,
                    p_expiry_date = dto.ExpiryDate,
                    p_is_active = dto.IsActive
                });

        // ✅ UPDATE
        public Task<int> UpdateAsync(CouponMasterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_update_coupon_master",
                new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_name = dto.Name,
                    p_description = dto.Description,
                    p_minimum_order_amount = dto.MinimumOrderAmount,
                    p_coupon_code = dto.CouponCode,
                    p_discount = dto.Discount,
                    p_discount_in = dto.DiscountIn,
                    p_expiry_date = dto.ExpiryDate,
                    p_is_active = dto.IsActive
                });

        // ✅ DELETE
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_delete_coupon_master",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });
    }
}
using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface ICouponMasterRepository
    {
        Task<IEnumerable<CouponMasterDto>> GetAllAsync(long shopId);
        Task<CouponMasterDto?> GetByIdAsync(long id, long shopId);
        Task<int> AddAsync(CouponMasterDto dto);
        Task<int> UpdateAsync(CouponMasterDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IAffiniaPaymentRepository
    {
        Task<long> CreatePaymentAsync(CreatePaymentDto dto);

        Task<AffiniaPaymentDto?> GetPaymentByIdAsync(long id, long shopId);

        Task<int> UpdatePaymentAsync(UpdateAffiniaPaymentDto dto);

        Task<int> DeletePaymentAsync(long id, long shopId);
    }
}
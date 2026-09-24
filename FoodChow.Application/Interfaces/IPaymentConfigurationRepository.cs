using FoodChow.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Application.Interfaces
{
    public interface IPaymentConfigurationRepository
    {
        Task<IEnumerable<PaymentConfigurationDto>> GetByShopIdAsync(int shopId);

        Task<PaymentConfigurationDto?> GetByIdAsync(int id, int shopId);

        Task<IEnumerable<PaymentConfigurationDto>> GetActiveByShopIdAsync(int shopId);

        Task<long> AddAsync(CreatePaymentConfigurationDto dto);

        Task<int> UpdateAsync(UpdatePaymentConfigurationDto dto);

        Task<int> DeleteAsync(int id, int shopId);

        Task<bool> ExistsAsync(int shopId, string providerName);
    }
}
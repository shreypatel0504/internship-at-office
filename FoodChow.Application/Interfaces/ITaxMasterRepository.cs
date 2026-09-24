using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface ITaxMasterRepository
    {
        Task<IEnumerable<TaxMasterDto>> GetAllAsync(long shopId);
        Task<TaxMasterDto?> GetByIdAsync(long id, long shopId);
        Task<long> AddAsync(AddTaxMasterDto dto);
        Task<int> UpdateAsync(UpdateTaxMasterDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
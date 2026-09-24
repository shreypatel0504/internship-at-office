using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IPrinterRepository
    {
        Task<IEnumerable<PrinterDto>> GetAllAsync(long shopId);
        Task<PrinterDto?> GetByIdAsync(long id, long shopId);
        Task<long> AddAsync(AddPrinterDto dto);
        Task<int> UpdateAsync(UpdatePrinterDto dto);
        Task<int> DeleteAsync(long id, long shopId);
    }
}
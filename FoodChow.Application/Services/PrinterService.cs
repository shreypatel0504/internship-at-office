using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class PrinterService(IPrinterRepository repo)
    {
        // ✅ Get All
        public async Task<ApiResponse<IEnumerable<PrinterDto>>> GetAllAsync(long shopId)
        {
            try
            {
                var list = await repo.GetAllAsync(shopId);
                return ApiResponse<IEnumerable<PrinterDto>>.Ok(list);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<PrinterDto>>.Fail(ex.Message); }
        }

        // ✅ Get By Id
        public async Task<ApiResponse<PrinterDto>> GetByIdAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0) return ApiResponse<PrinterDto>.Fail("Invalid id.");

                var printer = await repo.GetByIdAsync(id, shopId);
                if (printer is null) return ApiResponse<PrinterDto>.Fail("Printer not found.");

                return ApiResponse<PrinterDto>.Ok(printer);
            }
            catch (Exception ex) { return ApiResponse<PrinterDto>.Fail(ex.Message); }
        }

        // ✅ Add
        public async Task<ApiResponse<long>> AddAsync(AddPrinterDto dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<long>.Fail("Invalid shop_id.");

                if (string.IsNullOrWhiteSpace(dto.PrinterName))
                    return ApiResponse<long>.Fail("Printer name is required.");

                var newId = await repo.AddAsync(dto);
                return ApiResponse<long>.Ok(newId, "Printer added successfully.");
            }
            catch (Exception ex) { return ApiResponse<long>.Fail(ex.Message); }
        }

        // ✅ Update
        public async Task<ApiResponse<bool>> UpdateAsync(UpdatePrinterDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                if (string.IsNullOrWhiteSpace(dto.PrinterName))
                    return ApiResponse<bool>.Fail("Printer name is required.");

                await repo.UpdateAsync(dto);
                return ApiResponse<bool>.Ok(true, "Printer updated successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }

        // ✅ Delete
        public async Task<ApiResponse<bool>> DeleteAsync(long id, long shopId)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<bool>.Fail("Invalid id.");

                await repo.DeleteAsync(id, shopId);
                return ApiResponse<bool>.Ok(true, "Printer deleted successfully.");
            }
            catch (Exception ex) { return ApiResponse<bool>.Fail(ex.Message); }
        }
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class PrinterRepository(MySqlDalc dalc) : IPrinterRepository
    {
        // ✅ Get All
        public Task<IEnumerable<PrinterDto>> GetAllAsync(long shopId) =>
            dalc.ExecuteSpListAsync<PrinterDto>(
                "USP_GetAllPrinters",
                new { p_shop_id = shopId });

        // ✅ Get By Id
        public Task<PrinterDto?> GetByIdAsync(long id, long shopId) =>
            dalc.ExecuteSpSingleAsync<PrinterDto>(
                "USP_GetPrinterById",
                new { p_id = id, p_shop_id = shopId });

        // ✅ Add
        public Task<long> AddAsync(AddPrinterDto dto) =>
            dalc.ExecuteSpScalarAsync<long>(
                "USP_AddPrinter", new
                {
                    p_shop_id = dto.ShopId,
                    p_printer_name = dto.PrinterName ?? string.Empty,
                    p_printer_ip = dto.PrinterIp ?? string.Empty,
                    p_printer_port = dto.PrinterPort,
                    p_printer_type = dto.PrinterType ?? string.Empty,
                    p_paper_size = dto.PaperSize ?? string.Empty,
                    p_is_default = dto.IsDefault,
                    p_is_active = dto.IsActive
                });

        // ✅ Update
        public Task<int> UpdateAsync(UpdatePrinterDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_UpdatePrinter", new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_printer_name = dto.PrinterName ?? string.Empty,
                    p_printer_ip = dto.PrinterIp ?? string.Empty,
                    p_printer_port = dto.PrinterPort,
                    p_printer_type = dto.PrinterType ?? string.Empty,
                    p_paper_size = dto.PaperSize ?? string.Empty,
                    p_is_default = dto.IsDefault,
                    p_is_active = dto.IsActive
                });

        // ✅ Delete
        public Task<int> DeleteAsync(long id, long shopId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_DeletePrinter",
                new { p_id = id, p_shop_id = shopId });
    }
}
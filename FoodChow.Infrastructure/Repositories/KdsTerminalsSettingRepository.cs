using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class KdsTerminalsSettingRepository(MySqlDalc dalc)
        : IKdsTerminalsSettingRepository
    {
        // ✅ Add
        public async Task<long> AddAsync(AddKdsTerminalSettingDto dto)
        {
            await dalc.ExecuteSpNonQueryAsync(
                "USP_add_kds_terminal_setting",
                new
                {
                    p_shop_id = dto.ShopId,
                    p_terminal_name = dto.TerminalName,
                    p_terminal_code = dto.TerminalCode,
                    p_ip_address = dto.IpAddress,
                    p_port = dto.Port,
                    p_is_active = dto.IsActive
                });

            return 1;
        }

        // ✅ Update
        public async Task<bool> UpdateAsync(UpdateKdsTerminalSettingDto dto)
        {
            await dalc.ExecuteSpNonQueryAsync(
                "USP_update_kds_terminal_setting",
                new
                {
                    p_id = dto.Id,
                    p_shop_id = dto.ShopId,
                    p_terminal_name = dto.TerminalName,
                    p_printer_name = dto.PrinterName,
                    p_ip_address = dto.IpAddress,
                    p_port_no = dto.PortNo,
                    p_is_active = dto.IsActive                                                                                                  
                });

            return true;
        }

        // ✅ Delete
        public async Task<bool> DeleteAsync(long id, long shopId)
        {
            await dalc.ExecuteSpNonQueryAsync(
                "USP_delete_kds_terminal_setting",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

            return true;
        }

        // ✅ Get All
        public async Task<IEnumerable<KdsTerminalsSettingResponseDto>> GetAllAsync(long shopId)
        {
            return await dalc.ExecuteSpListAsync<KdsTerminalsSettingResponseDto>(
                "USP_get_kds_terminal_setting",
                new
                {
                    p_shop_id = shopId
                });
        }

        // ✅ Get By Id
        public async Task<KdsTerminalsSettingResponseDto?> GetByIdAsync(long id, long shopId)
        {
            var data = await dalc.ExecuteSpListAsync<KdsTerminalsSettingResponseDto>(
                "USP_get_kds_terminal_setting_by_id",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });

            return data.FirstOrDefault();
        }
    }
}
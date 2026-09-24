using Dapper;
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class MasterReasonRepository(MySqlDalc dalc) : IMasterReasonRepository
    {
        // ✅ Get All
        public Task<IEnumerable<MasterReasonDto>> GetAllAsync() =>
            dalc.ExecuteSpListAsync<MasterReasonDto>(
                "USP_get_master_reason"
            );

        // ✅ Get By Id
        public Task<MasterReasonDto?> GetByIdAsync(long reasonId) =>
            dalc.ExecuteSpSingleAsync<MasterReasonDto>(
                "USP_get_master_reason_by_id",
                new
                {
                    p_reason_id = reasonId
                }
            );

        // ✅ Add
        public async Task<long> AddAsync(CreateMasterReasonDto dto)
        {
            Console.WriteLine("NAME: " + dto.ReasonName);
            Console.WriteLine("DESC: " + dto.ReasonDescription);
            Console.WriteLine("STATUS: " + dto.Status);

            var parameters = new DynamicParameters();

            parameters.Add("p_reason_name", dto.ReasonName);
            parameters.Add("p_reason_description", dto.ReasonDescription);
            parameters.Add("p_status", dto.Status);

            return await dalc.ExecuteSpScalarAsync<long>(
                "USP_add_master_reason",
                parameters
            );
        }

        // ✅ Update
        public Task<int> UpdateAsync(UpdateMasterReasonDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_update_master_reason",
                new
                {
                    p_reason_id = dto.ReasonId,
                    p_reason_name = dto.ReasonName ?? string.Empty,
                    p_reason_description = dto.ReasonDescription ?? string.Empty,
                    p_status = dto.Status
                }
            );

        // ✅ Delete
        public Task<int> DeleteAsync(long reasonId) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_delete_master_reason",
                new
                {
                    p_reason_id = reasonId
                }
            );
    }
}
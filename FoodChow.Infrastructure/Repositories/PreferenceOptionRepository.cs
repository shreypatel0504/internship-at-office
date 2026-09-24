using System.Data;
using Dapper;
using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class PreferenceOptionRepository : IPreferenceOptionRepository
    {
        private readonly MySqlDalc _dalc;

        public PreferenceOptionRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<FoodPreferenceOptionEntity>> GetAll(long preferenceId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodPreferenceOptionEntity>(
                "USP_GetPreferenceOptions",
                new { p_preference_id = preferenceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<FoodPreferenceOptionEntity> GetById(long optionId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<FoodPreferenceOptionEntity>(
                "USP_GetPreferenceOptionById",
                new { p_option_id = optionId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> Add(FoodPreferenceOptionEntity model)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddPreferenceOption",
                new
                {
                    p_preference_id = model.preference_id,
                    p_option_name = model.option_name,
                    p_is_active = model.is_active
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Update(FoodPreferenceOptionEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePreferenceOption",
                new
                {
                    p_option_id = model.preference_option_id,
                    p_option_name = model.option_name
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(long optionId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeletePreferenceOption",
                new { p_option_id = optionId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
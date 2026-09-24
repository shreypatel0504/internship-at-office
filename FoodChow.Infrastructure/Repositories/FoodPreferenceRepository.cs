using System.Data;
using Dapper;
using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class FoodPreferenceRepository : IFoodPreferenceRepository
    {
        private readonly MySqlDalc _dalc;

        public FoodPreferenceRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<FoodPreferenceEntity>> GetAllPreferences(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodPreferenceEntity>(
                "USP_GetAllFoodPreferences",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<FoodPreferenceEntity> GetPreferenceById(long preferenceId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<FoodPreferenceEntity>(
                "USP_GetFoodPreferenceById",
                new { p_preference_id = preferenceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddPreference(FoodPreferenceEntity model)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddFoodPreference",
                new
                {
                    p_shop_id = model.shop_id,
                    p_preference_name = model.preference_name,
                    p_is_mandatory = model.is_mandatory,
                    p_is_active = model.is_active
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdatePreference(FoodPreferenceEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateFoodPreference",
                new
                {
                    p_preference_id = model.preference_id,
                    p_preference_name = model.preference_name,
                    p_is_mandatory = model.is_mandatory
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task ChangePreferenceStatus(long preferenceId, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_ChangeFoodPreferenceStatus",
                new
                {
                    p_preference_id = preferenceId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FoodPreferenceOptionEntity>> GetPreferenceOptions(long preferenceId)
        {
            return await _dalc.CreateConnection().QueryAsync<FoodPreferenceOptionEntity>(
                "USP_GetPreferenceOptions",
                new { p_preference_id = preferenceId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddPreferenceOption(FoodPreferenceOptionEntity model)
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

        public async Task UpdatePreferenceOption(FoodPreferenceOptionEntity model)
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

        public async Task DeletePreferenceOption(long optionId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeletePreferenceOption",
                new { p_option_id = optionId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> MapPreferenceToItem(
            long itemId,
            long preferenceId,
            int isMandatory,
            long maximumSelection)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_MapPreferenceToItem",
                new
                {
                    p_item_id = itemId,
                    p_preference_id = preferenceId,
                    p_is_mandatory = isMandatory,
                    p_maximum_selection = maximumSelection
                },
                commandType: CommandType.StoredProcedure);
        }
    }


}
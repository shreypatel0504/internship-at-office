using FoodChow.Application.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IFoodPreferenceRepository
    {
        Task<IEnumerable<FoodPreferenceEntity>> GetAllPreferences(long shopId);

        Task<FoodPreferenceEntity> GetPreferenceById(long preferenceId);

        Task<long> AddPreference(FoodPreferenceEntity model);

        Task UpdatePreference(FoodPreferenceEntity model);

        Task ChangePreferenceStatus(long preferenceId, int status);

        Task<IEnumerable<FoodPreferenceOptionEntity>> GetPreferenceOptions(long preferenceId);

        Task<long> AddPreferenceOption(FoodPreferenceOptionEntity model);

        Task UpdatePreferenceOption(FoodPreferenceOptionEntity model);

        Task DeletePreferenceOption(long optionId);

        Task<long> MapPreferenceToItem(
            long itemId,
            long preferenceId,
            int isMandatory,
            long maximumSelection);
    }
}
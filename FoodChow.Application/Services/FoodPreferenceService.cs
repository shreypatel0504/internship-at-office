using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class FoodPreferenceService
    {
        private readonly IFoodPreferenceRepository _repository;

        public FoodPreferenceService(IFoodPreferenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodPreferenceEntity>> GetAllPreferences(long shopId)
            => await _repository.GetAllPreferences(shopId);

        public async Task<FoodPreferenceEntity> GetPreferenceById(long id)
            => await _repository.GetPreferenceById(id);

        public async Task<long> AddPreference(FoodPreferenceEntity model)
            => await _repository.AddPreference(model);

        public async Task UpdatePreference(FoodPreferenceEntity model)
            => await _repository.UpdatePreference(model);

        public async Task ChangePreferenceStatus(long id, int status)
            => await _repository.ChangePreferenceStatus(id, status);

        public async Task<IEnumerable<FoodPreferenceOptionEntity>> GetPreferenceOptions(long id)
            => await _repository.GetPreferenceOptions(id);

        public async Task<long> AddPreferenceOption(FoodPreferenceOptionEntity model)
            => await _repository.AddPreferenceOption(model);

        public async Task UpdatePreferenceOption(FoodPreferenceOptionEntity model)
            => await _repository.UpdatePreferenceOption(model);

        public async Task DeletePreferenceOption(long id)
            => await _repository.DeletePreferenceOption(id);

        public async Task<long> MapPreferenceToItem(
            long itemId,
            long preferenceId,
            int isMandatory,
            long maxSelection)
            => await _repository.MapPreferenceToItem(
                itemId,
                preferenceId,
                isMandatory,
                maxSelection);
    }
}
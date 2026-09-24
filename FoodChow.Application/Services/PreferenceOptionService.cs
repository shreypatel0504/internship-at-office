using FoodChow.Application.Entities;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class PreferenceOptionService
    {
        private readonly IPreferenceOptionRepository _repository;

        public PreferenceOptionService(IPreferenceOptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodPreferenceOptionEntity>> GetAll(long preferenceId)
            => await _repository.GetAll(preferenceId);

        public async Task<FoodPreferenceOptionEntity> GetById(long id)
            => await _repository.GetById(id);

        public async Task<long> Add(FoodPreferenceOptionEntity model)
            => await _repository.Add(model);

        public async Task Update(FoodPreferenceOptionEntity model)
            => await _repository.Update(model);

        public async Task Delete(long id)
            => await _repository.Delete(id);
    }
}
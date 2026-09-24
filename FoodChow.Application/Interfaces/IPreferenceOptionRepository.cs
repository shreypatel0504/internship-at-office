using FoodChow.Application.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IPreferenceOptionRepository
    {
        Task<IEnumerable<FoodPreferenceOptionEntity>> GetAll(long preferenceId);

        Task<FoodPreferenceOptionEntity> GetById(long optionId);

        Task<long> Add(FoodPreferenceOptionEntity model);

        Task Update(FoodPreferenceOptionEntity model);

        Task Delete(long optionId);
    }
}
using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class MasterReasonService
    {
        private readonly IMasterReasonRepository _repository;

        public MasterReasonService(IMasterReasonRepository repository)
        {
            _repository = repository;
        }

        // Get All
        public async Task<IEnumerable<MasterReasonDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Get By Id
        public async Task<MasterReasonDto?> GetByIdAsync(long reasonId)
        {
            return await _repository.GetByIdAsync(reasonId);
        }

        // Add
        public async Task<long> AddAsync(CreateMasterReasonDto dto)
        {
            return await _repository.AddAsync(dto);
        }

        // Update
        public async Task<int> UpdateAsync(UpdateMasterReasonDto dto)
        {
            return await _repository.UpdateAsync(dto);
        }

        // Delete
        public async Task<bool> DeleteAsync(long reasonId)
        {
            var result = await _repository.DeleteAsync(reasonId);

            return result > 0;
        }
    }
}
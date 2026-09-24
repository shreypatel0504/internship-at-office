using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Application.Services
{
    public class DeliveryZoneService
    {
        private readonly IDeliveryZoneRepository _repo;

        public DeliveryZoneService(IDeliveryZoneRepository repo)
        {
            _repo = repo;
        }

        public Task SaveDeliveryZone(DeliveryZoneEntity model)
            => _repo.SaveDeliveryZone(model);

        public Task<IEnumerable<DeliveryZoneEntity>> GetAllStoreZone(long shopId)
            => _repo.GetAllStoreZone(shopId);

        public Task DeleteZoneByZoneId(long shopId, int zoneId)
            => _repo.DeleteZoneByZoneId(shopId, zoneId);

        public Task<IEnumerable<DeliveryZoneEntity>> GetZoneDetailsByZoneName(string zoneNo, long shopId)
            => _repo.GetZoneDetailsByZoneName(zoneNo, shopId);

        public Task UpdateZoneDetails(DeliveryZoneEntity model)
            => _repo.UpdateZoneDetails(model);

        public Task InsertDeliveryOption(int shopId, int optionId, int status)
            => _repo.InsertDeliveryOption(shopId, optionId, status);

        public Task UpdateDeliveryOption(int shopId, int optionId, int status)
            => _repo.UpdateDeliveryOption(shopId, optionId, status);

        public Task<IEnumerable<DeliveryOptionEntity>> GetDeliveryOptions(int shopId)
            => _repo.GetDeliveryOptions(shopId);
    }
}
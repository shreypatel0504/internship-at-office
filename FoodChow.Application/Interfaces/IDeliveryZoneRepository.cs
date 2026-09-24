using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Application.Interfaces
{
    public interface IDeliveryZoneRepository
    {
        Task SaveDeliveryZone(DeliveryZoneEntity model);

        Task<IEnumerable<DeliveryZoneEntity>> GetAllStoreZone(long shopId);

        Task DeleteZoneByZoneId(long shopId, int zoneId);

        Task<IEnumerable<DeliveryZoneEntity>> GetZoneDetailsByZoneName(string zoneNo, long shopId);

        Task UpdateZoneDetails(DeliveryZoneEntity model);

        Task InsertDeliveryOption(int shopId, int optionId, int status);

        Task UpdateDeliveryOption(int shopId, int optionId, int status);

        Task<IEnumerable<DeliveryOptionEntity>> GetDeliveryOptions(int shopId);
    }
}
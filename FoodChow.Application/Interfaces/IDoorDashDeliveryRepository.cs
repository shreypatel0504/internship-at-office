using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Application.Interfaces
{
    public interface IDoorDashDeliveryRepository
    {
        Task Add(DoorDashDeliveryEntity model);

        Task UpdateByDeliveryId(DoorDashDeliveryEntity model);

        Task<IEnumerable<DoorDashDeliveryEntity>> Get(int orderId, int shopId);

        Task UpdateStatus(int orderId, int shopId, string status);

        Task UpdateStatusByExternalId(
            string externalId,
            string status,
            string trackingUrl,
            decimal? deliveryFee
        );
    }
}
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodChow.Application.Services
{
    public class DoorDashDeliveryService
    {
        private readonly IDoorDashDeliveryRepository _repo;

        public DoorDashDeliveryService(IDoorDashDeliveryRepository repo)
        {
            _repo = repo;
        }

        public Task Add(DoorDashDeliveryEntity model)
            => _repo.Add(model);

        public Task UpdateByDeliveryId(DoorDashDeliveryEntity model)
            => _repo.UpdateByDeliveryId(model);

        public Task<IEnumerable<DoorDashDeliveryEntity>> Get(int orderId, int shopId)
            => _repo.Get(orderId, shopId);

        public Task UpdateStatus(int orderId, int shopId, string status)
            => _repo.UpdateStatus(orderId, shopId, status);

        public Task UpdateStatusByExternalId(string externalId,string status,string trackingUrl,decimal? deliveryFee)
            => _repo.UpdateStatusByExternalId(externalId,status,trackingUrl,deliveryFee);
    }
}
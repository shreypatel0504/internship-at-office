using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Application.Services
{
    public class ReservationRequestService
    {
        private readonly IReservationRequestRepository _repo;

        public ReservationRequestService(IReservationRequestRepository repo)
        {
            _repo = repo;
        }

        public Task Add(ReservationRequestEntity m) => _repo.Add(m);
        public Task<IEnumerable<ReservationRequestEntity>> GetAll(long shopId) => _repo.GetAll(shopId);
        public Task<ReservationRequestEntity> Get(long id) => _repo.GetById(id);
        public Task UpdateStatus(long id, int status) => _repo.UpdateStatus(id, status);
        public Task Delete(long id) => _repo.Delete(id);
    }
}

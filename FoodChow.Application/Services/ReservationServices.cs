using FoodChow.Domain.Entities;
using FoodChow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;   // ✅ ADD THIS

namespace FoodChow.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _repo;

        public ReservationService(IReservationRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ReservationEntity>> GetAll(long shopId) => _repo.GetAll(shopId);
        public Task<ReservationEntity> Get(long id) => _repo.GetById(id);
        public Task UpdateStatus(long id, int status) => _repo.UpdateStatus(id, status);
        public Task Delete(long id) => _repo.Delete(id);

        // ✅ ADD THIS METHOD
        public async Task CreateFromRequest(ReservationRequestEntity req)
        {
            await _repo.Create(new ReservationEntity
            {
                shopid = req.TR_Shop_Id,
                name = req.TR_First_Name + " " + req.TR_Last_Name,
                contact = long.Parse(req.TR_Mobile_Number),
                r_time = req.TR_Reservation_Time
            });
        }
    }
}
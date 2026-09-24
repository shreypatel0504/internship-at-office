using FoodChow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Application.Interfaces
{
    public interface IReservationRequestRepository
    {
        Task Add(ReservationRequestEntity m);
        Task<IEnumerable<ReservationRequestEntity>> GetAll(long shopId);
        Task<ReservationRequestEntity> GetById(long id);
        Task UpdateStatus(long id, int status);
        Task Delete(long id);
    }
}

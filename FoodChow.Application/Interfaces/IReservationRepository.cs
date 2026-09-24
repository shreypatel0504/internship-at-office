using FoodChow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<ReservationEntity>> GetAll(long shopId);
        Task<ReservationEntity> GetById(long id);
        Task UpdateStatus(long id, int status);
        Task Delete(long id);
        Task Create(ReservationEntity m);
    }

}

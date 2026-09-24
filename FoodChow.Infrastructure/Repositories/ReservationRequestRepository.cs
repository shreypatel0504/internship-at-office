using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class ReservationRequestRepository : IReservationRequestRepository
    {
        private readonly MySqlDalc _dalc;

        public ReservationRequestRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public Task Add(ReservationRequestEntity m)
        {
            return _dalc.CreateConnection().ExecuteAsync("sp_add_reservation_request", new
            {
                p_first_name = m.TR_First_Name,
                p_last_name = m.TR_Last_Name,
                p_email = m.TR_Email,
                p_mobile = m.TR_Mobile_Number,
                p_guest = m.TR_No_Guest,
                p_desc = m.TR_Description,
                p_date = m.TR_Reservation_Date,
                p_time = m.TR_Reservation_Time,
                p_slot = m.TR_Time_Slot,
                p_shop_id = m.TR_Shop_Id,
                p_user_id = m.TR_UserId
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ReservationRequestEntity>> GetAll(long shopId)
        {
            return _dalc.CreateConnection().QueryAsync<ReservationRequestEntity>(
                "sp_get_reservation_requests",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<ReservationRequestEntity> GetById(long id)
        {
            return _dalc.CreateConnection().QueryFirstOrDefaultAsync<ReservationRequestEntity>(
                "sp_get_reservation_request_by_id",
                new { p_id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task UpdateStatus(long id, int status)
        {
            return _dalc.CreateConnection().ExecuteAsync(
                "sp_update_reservation_request_status",
                new { p_id = id, p_status = status },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task Delete(long id)
        {
            return _dalc.CreateConnection().ExecuteAsync(
                "sp_delete_reservation_request",
                new { p_id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

using Dapper;
using System.Data;
using FoodChow.Domain.Entities;
using FoodChow.Application.Interfaces;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MySqlDalc _dalc;

        public ReservationRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }
        public async Task<IEnumerable<ReservationEntity>> GetAll(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<ReservationEntity>(
                "sp_get_reservations",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<ReservationEntity> GetById(long id)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<ReservationEntity>(
                "sp_get_reservation_by_id",
                new { p_id = id },
                commandType: CommandType.StoredProcedure
            ) ?? new ReservationEntity();
        }

        public async Task Delete(long id)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "sp_delete_reservation",
                new { p_id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateStatus(long id, int status)
        {
            // TEMP FIX (since no status column exists)
            await _dalc.CreateConnection().ExecuteAsync(
                "UPDATE table_reservation SET total_amount = @status WHERE res_id = @id",
                new { id, status }
            );
        }

        public Task Create(ReservationEntity m)
        {
            return _dalc.CreateConnection().ExecuteAsync("sp_add_reservation", new
            {
                p_shopid = m.shopid,
                p_name = m.name,
                p_contact = m.contact,
                p_time = m.r_time
            }, commandType: CommandType.StoredProcedure);
        }
    }

    
}
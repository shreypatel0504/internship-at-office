using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class DeliveryZoneRepository : IDeliveryZoneRepository
    {
        private readonly MySqlDalc _dalc;

        public DeliveryZoneRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task SaveDeliveryZone(DeliveryZoneEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_Shop_Zone",
                new
                {
                    id = model.shop_id,
                    zone = model.zone_no,
                    shape = model.type,
                    amt = model.min_order,
                    fee = model.delivery_fee,
                    col = model.color,
                    delivery_hours = model.delivery_hours,
                    delivery_minute = model.delivery_minute,
                    min_order_freedelivery = model.min_order_freedelivery,
                    radius = model.radius,
                    created_date = model.created_date,
                    updated_date = model.updated_date
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DeliveryZoneEntity>> GetAllStoreZone(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<DeliveryZoneEntity>(
                "USP_Get_Latlng",
                new { shopid = shopId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteZoneByZoneId(long shopId, int zoneId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_Delete_zone",
                new
                {
                    shopid = shopId,
                    zoneid = zoneId
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DeliveryZoneEntity>> GetZoneDetailsByZoneName(string zoneNo, long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<DeliveryZoneEntity>(
                "USP_CheckZoneAvailableOrNotWD",
                new
                {
                    zone_no = zoneNo,
                    shop_id = shopId
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateZoneDetails(DeliveryZoneEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_EditZoneData_ByShopAdmin",
                new
                {
                    Id = model.Id,
                    shop_id = model.shop_id,
                    zone_no = model.zone_no,
                    min_order = model.min_order,
                    delivery_fee = model.delivery_fee,
                    delivery_hours = model.delivery_hours,
                    delivery_minute = model.delivery_minute,
                    min_order_freedelivery = model.min_order_freedelivery,
                    created_date = model.created_date,
                    updated_date = model.updated_date
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task InsertDeliveryOption(int shopId, int optionId, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "sp_insert_food_delivery_option_settings",
                new
                {
                    p_shop_id = shopId,
                    p_option_id = optionId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateDeliveryOption(int shopId, int optionId, int status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "sp_update_food_delivery_option_settings",
                new
                {
                    p_shop_id = shopId,
                    p_option_id = optionId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DeliveryOptionEntity>> GetDeliveryOptions(int shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<DeliveryOptionEntity>(
                "sp_get_food_delivery_option_settings",
                new
                {
                    p_shop_id = shopId
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
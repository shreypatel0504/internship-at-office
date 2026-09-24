using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class DoorDashDeliveryRepository : IDoorDashDeliveryRepository
    {
        private readonly MySqlDalc _dalc;

        public DoorDashDeliveryRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }
        public async Task Add(DoorDashDeliveryEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "usp_insert_doordashdeliverydetails",
                new
                {
                    p_quote_id = model.external_quote_id,
                    p_shop_id = model.shop_id,
                    p_currency = model.currency,
                    p_status = model.delivery_status,
                    p_delivery_fee = model.deliveryfee,
                    p_updated_at = model.updated_at,
                    p_quote_object = model.quote_object
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task UpdateByDeliveryId(DoorDashDeliveryEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "usp_update_doordashdelivery_by_deliveryid",
                new
                {
                    p_order_id = model.foodchow_order_id,
                    p_delivery_status = model.delivery_status,
                    p_external_id = model.external_delivery_id,
                    p_quote_id = model.external_quote_id,
                    p_tracking_url = model.tracking_url,
                    p_shop_id = model.shop_id,
                    p_create_object = model.create_object
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<DoorDashDeliveryEntity>> Get(int orderId, int shopId)
        {
            return await _dalc.CreateConnection().QueryAsync<DoorDashDeliveryEntity>(
                "usp_get_doordashdeliverydetails",
                new
                {
                    p_order_id = orderId,
                    p_shop_id = shopId
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task UpdateStatus(int orderId, int shopId, string status)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "usp_update_status_doordashdeliverydetails",
                new
                {
                    p_order_id = orderId,
                    p_shop_id = shopId,
                    p_delivery_status = status
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task UpdateStatusByExternalId(string externalId,string status,string trackingUrl,decimal? deliveryFee)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "update_doordashdeliverydetails_status_by_external_id",
                new
                {
                    p_external_id = externalId,
                    p_delivery_status = status,
                    p_tracking_url = trackingUrl,
                    p_delivery_fee = deliveryFee
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly MySqlDalc _dalc;
        public DashboardRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<dynamic> CheckOrderTimingSettings(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_CheckOrderTimingSettings",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }


        public async Task<dynamic> GetStoreShopOffer(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetStoreShopOffer",
                new
                {
                    shop_id = shopId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateOnlineShopTiming(long shopId, string timing)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "Usp_UpdateOnlineShopTiming_Rms",
                new
                {
                    shop_id = shopId,
                    timing = timing
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetCouponDetails(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "GetCouponDetailsByShopID",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetShopTimings(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetShopTimings",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetLatLng(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_Get_Latlng",
                new { shopid = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetFoodPlanDetails(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodPlanDetails",
                new { shpid = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetStoreAllOrderCount(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetStoreAllOrderCount",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetItemTotalCount(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "GetItemTotalCountShopWise",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetReservationList(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "GetReservationListAllstatus_RMS",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetDashboardDetails(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetDashboardDetails",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetDeliveryMethodId(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GETDeliveryMethodId",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task SetStoreBusinessType(long shopId, int businessType)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_SetStoreBusinessType",
                new
                {
                    shop_id = shopId,
                    type_id = businessType
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetStoreBusinessType(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetStoreBusinessType",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateToken(DashboardEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "add_rms_device_login_list",
                new
                {
                    shop_id = model.shop_id,
                    device_type = model.device_type,
                    device_id = model.device_id,
                    device_token = model.token,
                    send_notification = 1,
                    device_model = "Android",
                    last_login_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                commandType: CommandType.StoredProcedure);
                    
        }
        public async Task UpdateTokenPOS(DashboardEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_ShopUpdateToken_multiPOS",
                new
                {
                    pos_user_id = model.pos_user_id,
                    device_id = model.device_id,
                    device_token = model.token,
                    device_model = model.device_model,
                    last_update = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                commandType: CommandType.StoredProcedure);

            await _dalc.CreateConnection().ExecuteAsync(
                "add_pos_device_login_list",
                new
                {
                    pos_user_id = model.pos_user_id,
                    shop_id = model.shop_id,
                    device_type = model.device_type,
                    device_id = model.device_id,
                    device_token = model.token,
                    send_notification = 1,
                    device_model = model.device_model,
                    last_login_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetStoreStatus(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetStoreStatus",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveShopRequestForPublish(long shopId)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveShopRequestForPublish",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetStoreDetails(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetStoreDetailsWithAddress",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetShopRequestData(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetShopRequestData",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveShopDeleteRequest(long shopId, string requestText)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveShopDataDeleteRequest",
                new
                {
                    shop_id = shopId,
                    created_date = DateTime.Now
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetDecimalPoint(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "GetDecimalPoint",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdatePaymentStatus(long shopId, string orderId, string paymentMethod)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdatePaymentStatus",
                new
                {
                    shopId = shopId,
                    orderId = orderId,
                    paymentMethod = paymentMethod
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<dynamic> GetShopDetails(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetShopDetailsById",
                new { shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetFoodItems(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_GetFoodItemByShopId",
                new { shpId = shopId },
                commandType: CommandType.StoredProcedure);
        }


    }
}
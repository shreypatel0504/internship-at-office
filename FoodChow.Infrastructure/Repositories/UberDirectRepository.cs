using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class UberDirectRepository : IUberDirectRepository
    {
        private readonly MySqlDalc _dalc;

        public UberDirectRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<long> SaveIntegration(UberDirectIntegrationEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_SaveUberDirectIntegration",
                new
                {
                    p_shop_id = e.ShopId,
                    p_api_key = e.ApiKey,
                    p_api_secret = e.ApiSecret,
                    p_country = e.Country,
                    p_type = e.Type,
                    p_baseurl = e.BaseUrl,
                    p_delivery_process = e.DeliveryProcess,
                    p_order_time = e.OrderTime,
                    p_signing_secret = e.SigningSecret,
                    p_webhooksecret = e.WebhookSecret
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<UberDirectIntegrationEntity> GetIntegration(long shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<UberDirectIntegrationEntity>(
                "USP_GetUberDirectIntegration",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> CreateQuote(UberDirectQuoteEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_CreateUberQuote",
                new
                {
                    p_shop_id = e.ShopId,
                    p_kind = e.Kind,
                    p_quote_id = e.QuoteId,
                    p_deliveryfees = e.DeliveryFees,
                    p_currency_type = e.CurrencyType,
                    p_quote_object = e.QuoteObject,
                    p_order_id = e.OrderId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<UberDirectQuoteEntity> GetQuote(string quoteId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<UberDirectQuoteEntity>(
                "USP_GetUberQuote",
                new { p_quote_id = quoteId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> CreateDelivery(UberDirectQuoteEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_CreateUberDelivery",
                new
                {
                    p_order_id = e.OrderId,
                    p_delivery_id = e.DeliveryId,
                    p_tracking_url = e.TrackingUrl,
                    p_status = e.Status,
                    p_delivery_object = e.DeliveryObject
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<UberDirectQuoteEntity> GetDelivery(string deliveryId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<UberDirectQuoteEntity>(
                "USP_GetUberDelivery",
                new { p_delivery_id = deliveryId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateDeliveryStatus(string deliveryId, string status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateUberDeliveryStatus",
                new
                {
                    p_delivery_id = deliveryId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> GetTrackingUrl(string orderId)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<string>(
                "USP_GetTrackingUrl",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> AddQuote(UberDirectQuoteEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddUberQuote",
                new
                {
                    p_shop_id = e.ShopId,
                    p_kind = e.Kind,
                    p_quote_id = e.QuoteId,
                    p_deliveryfees = e.DeliveryFees,
                    p_currency_type = e.CurrencyType,
                    p_quote_object = e.QuoteObject,
                    p_order_id = e.OrderId
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddDelivery(UberDirectQuoteEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_AddUberDelivery",
                new
                {
                    p_quote_id = e.QuoteId,
                    p_delivery_id = e.DeliveryId,
                    p_tracking_url = e.TrackingUrl,
                    p_status = e.Status,
                    p_delivery_object = e.DeliveryObject
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> CancelDelivery(string deliveryId)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_CancelUberDelivery",
                new { p_delivery_id = deliveryId },
                commandType: CommandType.StoredProcedure);
        }

     
        public async Task<int> SaveWebhook(UberDirectQuoteEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveUberWebhook",
                new
                {
                    p_delivery_id = e.DeliveryId,
                    p_status = e.Status,
                    p_delivery_object = e.DeliveryObject
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
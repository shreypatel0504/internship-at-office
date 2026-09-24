using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class YocoPaymentRepository : IYocoPaymentRepository
    {
        private readonly MySqlDalc _dalc;

        public YocoPaymentRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<int> SaveCredential(YocoCredentialEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveYocoCredential",
                new
                {
                    p_shop_id = e.ShopId,
                    p_secret_key = e.SecretKey,
                    p_public_key = e.PublicKey,
                    p_webhook_id = e.WebhookId,
                    p_webhook_secret = e.WebhookSecret
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<YocoCredentialEntity> GetCredential(string shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<YocoCredentialEntity>(
                "USP_GetYocoCredential",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<long> CreateCheckout(YocoOrderPaymentEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_CreateYocoCheckout",
                new
                {
                    p_shop_id = e.ShopId,
                    p_order_id = e.OrderId,
                    p_amount = e.Amount,
                    p_checkout_id = e.CheckoutId,
                    p_status = e.Status,
                    p_checkout_response = e.CheckoutResponse
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> RefundPayment(YocoOrderPaymentEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_RefundYocoPayment",
                new
                {
                    p_order_id = e.OrderId,
                    p_refund_id = e.RefundId,
                    p_refund_response = e.RefundResponse,
                    p_status = e.Status
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<YocoOrderPaymentEntity> GetPaymentStatus(string orderId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<YocoOrderPaymentEntity>(
                "USP_GetYocoPaymentStatus",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SavePaymentError(YocoPaymentErrorEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_SaveYocoPaymentError",
                new
                {
                    p_shop_id = e.ShopId,
                    p_order_id = e.OrderId,
                    p_amount = e.Amount,
                    p_error = e.Error,
                    p_message = e.Message,
                    p_description = e.Description
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<long> AddYocoCredential(YocoCredentialEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddYocoCredential",
                new
                {
                    p_shop_id = e.ShopId,
                    p_secret_key = e.SecretKey,
                    p_public_key = e.PublicKey,
                    p_webhook_id = e.WebhookId,
                    p_webhook_secret = e.WebhookSecret
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateYocoCredential(YocoCredentialEntity e)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_UpdateYocoCredential",
                new
                {
                    p_shop_id = e.ShopId,
                    p_secret_key = e.SecretKey,
                    p_public_key = e.PublicKey,
                    p_webhook_id = e.WebhookId,
                    p_webhook_secret = e.WebhookSecret
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<YocoCredentialEntity> GetYocoCredential(string shopId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<YocoCredentialEntity>(
                "USP_GetYocoCredential",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<long> OrderCheckoutByYoco(YocoOrderPaymentEntity e)
        {
            return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_OrderCheckoutByYoco",
                new
                {
                    p_shop_id = e.ShopId,
                    p_order_id = e.OrderId,
                    p_amount = e.Amount,
                    p_checkoutId = e.CheckoutId,
                    p_status = e.Status,
                    p_checkout_response = e.CheckoutResponse
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> ReceiveYocoWebhook(string checkoutId,string paymentId,string status)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_ReceiveYocoWebhook",
                new
                {
                    p_checkoutId = checkoutId,
                    p_payment_id = paymentId,
                    p_status = status
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<int> YocoPaymentRefund(string orderId,string refundId,string response)
        {
            return await _dalc.CreateConnection().ExecuteAsync(
                "USP_YocoPaymentRefund",
                new
                {
                    p_order_id = orderId,
                    p_refund_id = refundId,
                    p_refund_response = response
                },
                commandType: CommandType.StoredProcedure);
        }
        public async Task<YocoOrderPaymentEntity> GetYocoOrderPaymentDetails(string orderId)
        {
            return await _dalc.CreateConnection().QueryFirstOrDefaultAsync<YocoOrderPaymentEntity>(
                "USP_GetYocoOrderPaymentDetails",
                new { p_order_id = orderId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
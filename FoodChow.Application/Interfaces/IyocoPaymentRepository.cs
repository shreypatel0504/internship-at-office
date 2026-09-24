using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IYocoPaymentRepository
    {
        Task<int> SaveCredential(YocoCredentialEntity e);
        Task<YocoCredentialEntity> GetCredential(string shopId);

        Task<long> CreateCheckout(YocoOrderPaymentEntity e);
        Task<int> RefundPayment(YocoOrderPaymentEntity e);
        Task<YocoOrderPaymentEntity> GetPaymentStatus(string orderId);

        Task<int> SavePaymentError(YocoPaymentErrorEntity e);
        Task<long> AddYocoCredential(YocoCredentialEntity e);
        Task<int> UpdateYocoCredential(YocoCredentialEntity e);
        Task<YocoCredentialEntity> GetYocoCredential(string shopId);

        Task<long> OrderCheckoutByYoco(YocoOrderPaymentEntity e);
        Task<int> ReceiveYocoWebhook(string checkoutId, string paymentId, string status);
        Task<int> YocoPaymentRefund(string orderId, string refundId, string response);
        Task<YocoOrderPaymentEntity> GetYocoOrderPaymentDetails(string orderId);
    }
}
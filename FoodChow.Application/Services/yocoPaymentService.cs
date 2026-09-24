using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class YocoPaymentService
    {
        private readonly IYocoPaymentRepository _repo;

        public YocoPaymentService(IYocoPaymentRepository repo)
        {
            _repo = repo;
        }

        public Task<int> SaveCredential(YocoCredentialEntity e)
            => _repo.SaveCredential(e);

        public Task<YocoCredentialEntity> GetCredential(string shopId)
            => _repo.GetCredential(shopId);

        public Task<long> CreateCheckout(YocoOrderPaymentEntity e)
            => _repo.CreateCheckout(e);

        public Task<int> RefundPayment(YocoOrderPaymentEntity e)
            => _repo.RefundPayment(e);

        public Task<YocoOrderPaymentEntity> GetPaymentStatus(string orderId)
            => _repo.GetPaymentStatus(orderId);

        public Task<int> SavePaymentError(YocoPaymentErrorEntity e)
            => _repo.SavePaymentError(e);
        public Task<long> AddYocoCredential(YocoCredentialEntity e)
      => _repo.AddYocoCredential(e);

        public Task<int> UpdateYocoCredential(YocoCredentialEntity e)
            => _repo.UpdateYocoCredential(e);

        public Task<YocoCredentialEntity> GetYocoCredential(string shopId)
            => _repo.GetYocoCredential(shopId);

        public Task<long> OrderCheckoutByYoco(YocoOrderPaymentEntity e)
            => _repo.OrderCheckoutByYoco(e);

        public Task<int> ReceiveYocoWebhook(string c, string p, string s)
            => _repo.ReceiveYocoWebhook(c, p, s);

        public Task<int> YocoPaymentRefund(string o, string r, string rs)
            => _repo.YocoPaymentRefund(o, r, rs);

        public Task<YocoOrderPaymentEntity> GetYocoOrderPaymentDetails(string orderId)
            => _repo.GetYocoOrderPaymentDetails(orderId);
    }
}

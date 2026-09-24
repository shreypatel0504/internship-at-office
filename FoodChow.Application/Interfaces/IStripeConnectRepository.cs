using FoodChow.Application.DTOs;

namespace FoodChow.Application.Interfaces
{
    public interface IStripeConnectRepository
    {
        // =========================
        // CREATE / UPDATE
        // =========================
        Task<long> CreateStripeConnectAsync(StripeConnectDTO dto);

        Task<int> UpdateStripeConnectAsync(StripeConnectDTO dto);

        // =========================
        // GET DATA
        // =========================
        Task<StripeConnectDTO?> GetByShopIdAsync(long shopId);

        Task<StripeConnectDTO?> GetByIdAsync(long stripeConnectId);

        // =========================
        // STATUS MANAGEMENT
        // =========================
        Task<int> UpdateStatusAsync(long stripeConnectId, string status, long updatedBy);

        // =========================
        // STRIPE IDS MANAGEMENT
        // =========================
        Task<int> SaveStripeAccountIdAsync(long shopId, string stripeAccountId);

        Task<int> SaveStripeCustomerIdAsync(long shopId, string stripeCustomerId);

        // =========================
        // DELETE
        // =========================
        Task<int> DeleteAsync(long stripeConnectId);
    }
}
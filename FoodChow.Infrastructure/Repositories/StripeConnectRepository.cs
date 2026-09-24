using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class StripeConnectRepository : IStripeConnectRepository
    {
        private readonly MySqlDalc dalc;

        public StripeConnectRepository(MySqlDalc dalc)
        {
            this.dalc = dalc;
        }

        // =========================
        // CREATE STRIPE CONNECT
        // =========================
        public async Task<long> CreateStripeConnectAsync(StripeConnectDTO dto)
        {
            return await dalc.ExecuteSpScalarAsync<long>(
                "USP_CreateStripeConnect",
                new
                {
                    p_shop_id = dto.ShopId,
                    p_stripe_account_id = dto.StripeAccountId,
                    p_stripe_customer_id = dto.StripeCustomerId,
                    p_account_email = dto.AccountEmail,
                    p_country = dto.Country,
                    p_currency = dto.Currency,
                    p_status = dto.Status,
                    //p_created_by = dto.CreatedBy
                });
        }

        // =========================
        // UPDATE STRIPE CONNECT
        // =========================
        public async Task<int> UpdateStripeConnectAsync(StripeConnectDTO dto)
        {
            return await dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStripeConnect",
                new
                {
                    p_stripe_connect_id = dto.StripeConnectId,
                    p_shop_id = dto.ShopId,
                    p_stripe_account_id = dto.StripeAccountId,
                    p_stripe_customer_id = dto.StripeCustomerId,
                    p_account_email = dto.AccountEmail,
                    p_country = dto.Country,
                    p_currency = dto.Currency,
                    p_status = dto.Status,
                    p_updated_by = dto.UpdatedBy
                });
        }

        // =========================
        // GET BY SHOP ID
        // =========================
        public async Task<StripeConnectDTO?> GetByShopIdAsync(long shopId)
        {
            return await dalc.ExecuteSpSingleAsync<StripeConnectDTO>(
                "USP_GetStripeConnectByShopId",
                new
                {
                    p_shop_id = shopId
                });
        }

        // =========================
        // GET BY ID
        // =========================
        public async Task<StripeConnectDTO?> GetByIdAsync(long stripeConnectId)
        {
            return await dalc.ExecuteSpSingleAsync<StripeConnectDTO>(
                "USP_GetStripeConnectById",
                new
                {
                    p_stripe_connect_id = stripeConnectId
                });
        }

        // =========================
        // UPDATE STATUS
        // =========================
        public async Task<int> UpdateStatusAsync(long stripeConnectId, string status, long updatedBy)
        {
            return await dalc.ExecuteSpNonQueryAsync(
                "USP_UpdateStripeConnectStatus",
                new
                {
                    p_stripe_connect_id = stripeConnectId,
                    p_status = status,
                    p_updated_by = updatedBy
                });
        }

        // =========================
        // SAVE STRIPE ACCOUNT ID
        // =========================
        public async Task<int> SaveStripeAccountIdAsync(long shopId, string stripeAccountId)
        {
            return await dalc.ExecuteSpNonQueryAsync(
                "USP_SaveStripeAccountId",
                new
                {
                    p_shop_id = shopId,
                    p_stripe_account_id = stripeAccountId
                });
        }

        // =========================
        // SAVE STRIPE CUSTOMER ID
        // =========================
        public async Task<int> SaveStripeCustomerIdAsync(long shopId, string stripeCustomerId)
        {
            return await dalc.ExecuteSpNonQueryAsync(
                "USP_SaveStripeCustomerId",
                new
                {
                    p_shop_id = shopId,
                    p_stripe_customer_id = stripeCustomerId
                });
        }

        // =========================
        // DELETE
        // =========================
        public async Task<int> DeleteAsync(long stripeConnectId)
        {
            return await dalc.ExecuteSpNonQueryAsync(
                "USP_DeleteStripeConnect",
                new
                {
                    p_stripe_connect_id = stripeConnectId
                });
        }
    }
}
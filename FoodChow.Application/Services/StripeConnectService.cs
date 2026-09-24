using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;

namespace FoodChow.Application.Services
{
    public class StripeConnectService
    {
        private readonly IStripeConnectRepository repo;

        public StripeConnectService(IStripeConnectRepository repo)
        {
            this.repo = repo;
        }

        // =========================
        // CREATE / UPDATE CONNECT ACCOUNT
        // =========================
        public async Task<ApiResponse<object>> CreateAsync(StripeConnectDTO dto)
        {
            try
            {
                if (dto.ShopId <= 0)
                    return ApiResponse<object>.Fail("Invalid ShopId");

                var id = await repo.CreateStripeConnectAsync(dto);

                return ApiResponse<object>.Ok(id, "Stripe Connect Created Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<object>> UpdateAsync(StripeConnectDTO dto)
        {
            try
            {
                if (dto.StripeConnectId <= 0)
                    return ApiResponse<object>.Fail("Invalid StripeConnectId");

                await repo.UpdateStripeConnectAsync(dto);

                return ApiResponse<object>.Ok("", "Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // GET DATA
        // =========================
        public async Task<ApiResponse<object>> GetByShopIdAsync(long shopId)
        {
            try
            {
                var data = await repo.GetByShopIdAsync(shopId);

                return ApiResponse<object>.Ok(data, "Success");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<object>> GetByIdAsync(long id)
        {
            try
            {
                var data = await repo.GetByIdAsync(id);

                return ApiResponse<object>.Ok(data, "Success");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // STATUS UPDATE
        // =========================
        public async Task<ApiResponse<object>> UpdateStatusAsync(long id, string status, long updatedBy)
        {
            try
            {
                await repo.UpdateStatusAsync(id, status, updatedBy);

                return ApiResponse<object>.Ok("", "Status Updated Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // SAVE STRIPE IDS
        // =========================
        public async Task<ApiResponse<object>> SaveStripeAccountIdAsync(long shopId, string stripeAccountId)
        {
            try
            {
                await repo.SaveStripeAccountIdAsync(shopId, stripeAccountId);

                return ApiResponse<object>.Ok("", "Stripe Account Saved");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<object>> SaveStripeCustomerIdAsync(long shopId, string stripeCustomerId)
        {
            try
            {
                await repo.SaveStripeCustomerIdAsync(shopId, stripeCustomerId);

                return ApiResponse<object>.Ok("", "Stripe Customer Saved");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }

        // =========================
        // DELETE
        // =========================
        public async Task<ApiResponse<object>> DeleteAsync(long id)
        {
            try
            {
                await repo.DeleteAsync(id);

                return ApiResponse<object>.Ok("", "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.Fail(ex.Message);
            }
        }
    }
}
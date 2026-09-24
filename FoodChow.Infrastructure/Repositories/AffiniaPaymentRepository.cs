using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Infrastructure.DALC;

namespace FoodChow.Infrastructure.Repositories
{
    public class AffiniaPaymentRepository(MySqlDalc dalc) : IAffiniaPaymentRepository
    {
        // ========================= CREATE PAYMENT =========================
        public Task<long> CreatePaymentAsync(CreatePaymentDto dto)
        {
            return dalc.ExecuteSpScalarAsync<long>(
                "USP_add_affinia_payment",
                new
                {
                    p_order_id = dto.OrderId,
                    p_shop_id = dto.ShopId,
                    p_amount = dto.Amount,
                    p_payment_method = dto.PaymentMethod,
                    p_transaction_id = dto.TransactionId,
                    p_status = dto.Status,
                    p_currency = "INR",
                    p_reference_no = dto.TransactionId
                });
        }

        // ========================= GET PAYMENT BY ID =========================
        public Task<AffiniaPaymentDto?> GetPaymentByIdAsync(long id, long shopId)
        {
            return dalc.ExecuteSpSingleAsync<AffiniaPaymentDto>(
                "USP_get_affinia_payment_by_id",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });
        }

        // ========================= UPDATE PAYMENT =========================
        public Task<int> UpdatePaymentAsync(UpdateAffiniaPaymentDto dto) =>
            dalc.ExecuteSpNonQueryAsync(
                "USP_update_affinia_payment",
                new
                {
                    p_id = dto.Id,
                    p_status = dto.Status ?? string.Empty,
                    p_transaction_id = dto.TransactionId ?? string.Empty,
                    p_reference_no = dto.ReferenceNo ?? string.Empty,
                    p_remarks = dto.Remarks ?? string.Empty,
                    p_paid_at = dto.PaidAt
                });

        public Task<int> DeletePaymentAsync(long id, long shopId)
        {
            return dalc.ExecuteSpNonQueryAsync(
                "USP_delete_affinia_payment",
                new
                {
                    p_id = id,
                    p_shop_id = shopId
                });
        }
    }
}
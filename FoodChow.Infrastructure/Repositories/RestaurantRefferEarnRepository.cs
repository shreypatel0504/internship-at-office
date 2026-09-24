using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class RestaurantReferEarnRepository
        : IRestaurantReferEarnRepository
    {
        private readonly MySqlDalc _dalc;

        public RestaurantReferEarnRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetReferredRestaurants()
            => await _dalc.CreateConnection().QueryAsync<ReferredRestaurantEntity>(
                "USP_GetReferredRestaurants",
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetOwnReferredRestaurantsByShopId(string shopId)
            => await _dalc.CreateConnection().QueryAsync<ReferredRestaurantEntity>(
                "USP_GetOwnReferredRestaurantsByShopId",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ReferredRestaurantEntity>>
            GetReferredRestaurantsByShopId(string shopId)
            => await _dalc.CreateConnection().QueryAsync<ReferredRestaurantEntity>(
                "USP_GetReferredRestaurantsByShopId",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long>
            AddReferredRestaurant(ReferredRestaurantEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddReferredRestaurant",
                new
                {
                    p_restaurant_id = e.RestaurantId,
                    p_referring_restaurant_id = e.ReferringRestaurantId,
                    p_name = e.Name,
                    p_mobile = e.Mobile,
                    p_email = e.Email,
                    p_referred_by = e.ReferredBy
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int>
            DeleteReferredRestaurant(int id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteReferredRestaurant",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<int>
            DeleteCashback(string shopId)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCashback",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long>
            AddClaimRequestByOwner(ClaimRequestOwnerEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddClaimRequestByOwner",
                new
                {
                    p_shop_id = e.ShopId,
                    p_new_email = e.NewEmail,
                    p_country_code = e.CountryCode,
                    p_contact_no = e.ContactNo
                },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ClaimRequestOwnerEntity>>
            GetClaimRequestByOwner(string shopId)
            => await _dalc.CreateConnection().QueryAsync<ClaimRequestOwnerEntity>(
                "USP_GetClaimRequestByOwner",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<int>
            SendReferralMailForUser(string email)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_SendReferralMailForUser",
                new { p_email = email },
                commandType: CommandType.StoredProcedure);

        public async Task<int>
            SendWhatsAppMessageForRefferdRestaurant(string shopId)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_SendWhatsAppMessageForRefferdRestaurant",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
    }
}
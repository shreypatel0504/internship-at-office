using FoodChow.Domain.Entities;
using System.Threading.Tasks;

namespace FoodChow.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<dynamic> CheckOrderTimingSettings(long shopId);

        Task<dynamic> GetStoreShopOffer(long shopId);

        Task UpdateOnlineShopTiming(long shopId, string timing);

        Task<dynamic> GetCouponDetails(long shopId);

        Task<dynamic> GetShopTimings(long shopId);

        Task<dynamic> GetLatLng(long shopId);

        Task<dynamic> GetFoodPlanDetails(long shopId);

        Task<dynamic> GetStoreAllOrderCount(long shopId);

        Task<dynamic> GetItemTotalCount(long shopId);

        Task<dynamic> GetReservationList(long shopId);

        Task<dynamic> GetDashboardDetails(long shopId);

        Task<dynamic> GetDeliveryMethodId(long shopId);

        Task SetStoreBusinessType(long shopId, int businessType);

        Task<dynamic> GetStoreBusinessType(long shopId);

        Task UpdateToken(DashboardEntity model);

        Task UpdateTokenPOS(DashboardEntity model);

        Task<dynamic> GetStoreStatus(long shopId);

        Task SaveShopRequestForPublish(long shopId);

        Task<dynamic> GetStoreDetails(long shopId);

        Task<dynamic> GetShopRequestData(long shopId);

        Task SaveShopDeleteRequest(long shopId, string requestText);

        Task<dynamic> GetDecimalPoint(long shopId);

        Task UpdatePaymentStatus(long shopId, string orderId, string paymentMethod);

        Task<dynamic> GetShopDetails(long shopId);

        Task<dynamic> GetFoodItems(long shopId);
    }
}
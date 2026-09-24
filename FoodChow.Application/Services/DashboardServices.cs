using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodChow.Application.Services
{
    public class DashboardService
    {
        private readonly IDashboardRepository _repo;

        public DashboardService(IDashboardRepository reop)
        {
            _repo = reop;
        }

        public Task<dynamic> CheckOrderTimingSettings(long shopId)
            => _repo.CheckOrderTimingSettings(shopId);

        public Task<dynamic> GetStoreShopOffer(long shopId)
            => _repo.GetStoreShopOffer(shopId);

        public Task UpdateOnlineShopTiming(long shopId, string timing)
            => _repo.UpdateOnlineShopTiming(shopId, timing);

        public Task<dynamic> GetCouponDetails(long shopId)
            => _repo.GetCouponDetails(shopId);

        public Task<dynamic> GetShopTimings(long shopId)
            => _repo.GetShopTimings(shopId);

        public Task<dynamic> GetLatLng(long shopId)
            => _repo.GetLatLng(shopId);

        public Task<dynamic> GetFoodPlanDetails(long shopId)
            => _repo.GetFoodPlanDetails(shopId);

        public Task<dynamic> GetStoreAllOrderCount(long shopId)
            => _repo.GetStoreAllOrderCount(shopId);
        public Task<dynamic> GetItemTotalCount(long shopId)
            => _repo.GetItemTotalCount(shopId);

        public Task<dynamic> GetReservationList(long shopId)
            => _repo.GetReservationList(shopId);

        public Task<dynamic> GetDashboardDetails(long shopId)
            => _repo.GetDashboardDetails(shopId);

        public Task<dynamic> GetDeliveryMethodId(long shopId)
            => _repo.GetDeliveryMethodId(shopId);

        public Task SetStoreBusinessType(long shopId, int businessType)
            => _repo.SetStoreBusinessType(shopId, businessType);

        public Task<dynamic> GetStoreBusinessType(long shopId)
            => _repo.GetStoreBusinessType(shopId);

        public Task UpdateToken(DashboardEntity model)
            => _repo.UpdateToken(model);

        public Task UpdateTokenPOS(DashboardEntity model)
            => _repo.UpdateTokenPOS(model);
        public Task<dynamic> GetStoreStatus(long shopId)
           => _repo.GetStoreStatus(shopId);

        public Task SaveShopRequestForPublish(long shopId)
            => _repo.SaveShopRequestForPublish(shopId);

        public Task<dynamic> GetStoreDetails(long shopId)
            => _repo.GetStoreDetails(shopId);

        public Task<dynamic> GetShopRequestData(long shopId)
            => _repo.GetShopRequestData(shopId);

        public Task SaveShopDeleteRequest(long shopId, string requestText)
            => _repo.SaveShopDeleteRequest(shopId, requestText);

        public Task<dynamic> GetDecimalPoint(long shopId)
            => _repo.GetDecimalPoint(shopId);

        public async Task UpdatePaymentStatus(long shopId, string orderId, string paymentMethod)
        {
            await _repo.UpdatePaymentStatus(shopId, orderId, paymentMethod);
        }

        public Task<dynamic> GetShopDetails(long shopId)
            => _repo.GetShopDetails(shopId);
        public Task<dynamic> GetFoodItems(long shopId)
           => _repo.GetFoodItems(shopId);
    }
}

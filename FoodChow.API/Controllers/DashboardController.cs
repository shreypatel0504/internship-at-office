using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDashboardDetails(long shopId)
        {
            return Ok(await _service.GetDashboardDetails(shopId));
        }

        [HttpGet("order-count")]
        public async Task<IActionResult> GetStoreAllOrderCount(long shopId)
        {
            return Ok(await _service.GetStoreAllOrderCount(shopId));
        }
        [HttpGet("item-count")]
        public async Task<IActionResult> GetItemTotalCount(long shopId)
        {
            return Ok(await _service.GetItemTotalCount(shopId));
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetReservationList(long shopId)
        {
            return Ok(await _service.GetReservationList(shopId));
        }

        [HttpGet("food-items")]
        public async Task<IActionResult> GetFoodItems(long shopId)
        {
            return Ok(await _service.GetFoodItems(shopId));
        }
        [HttpGet("shop-details")]
        public async Task<IActionResult> GetShopDetails(long shopId)
        {
            return Ok(await _service.GetShopDetails(shopId));
        }

        [HttpGet("store-offers")]
        public async Task<IActionResult> GetStoreShopOffer(long shopId)
        {
            return Ok(await _service.GetStoreShopOffer(shopId));
        }

        [HttpGet("coupons")]
        public async Task<IActionResult> GetCouponDetails(long shopId)
        {
            return Ok(await _service.GetCouponDetails(shopId));
        }
        [HttpGet("shop-timings")]
        public async Task<IActionResult> GetShopTimings(long shopId)
        {
            return Ok(await _service.GetShopTimings(shopId));
        }

        [HttpGet("latlng")]
        public async Task<IActionResult> GetLatLng(long shopId)
        {
            return Ok(await _service.GetLatLng(shopId));
        }

        [HttpGet("food-plan")]
        public async Task<IActionResult> GetFoodPlanDetails(long shopId)
        {
            return Ok(await _service.GetFoodPlanDetails(shopId));
        }

        [HttpGet("delivery-method")]
        public async Task<IActionResult> GetDeliveryMethodId(long shopId)
        {
            return Ok(await _service.GetDeliveryMethodId(shopId));
        }

        [HttpGet("store-business-type")]
        public async Task<IActionResult> GetStoreBusinessType(long shopId)
        {
            return Ok(await _service.GetStoreBusinessType(shopId));
        }

        [HttpPut("store-business-type")]
        public async Task<IActionResult> SetStoreBusinessType(long shopId, int businessType)
        {
            await _service.SetStoreBusinessType(shopId, businessType);
            return Ok();
        }

        [HttpPut("update-token")]
        public async Task<IActionResult> UpdateToken([FromBody] DashboardEntity model)
        {
            await _service.UpdateToken(model);
            return Ok();
        }


        [HttpPut("update-token-pos")]
        public async Task<IActionResult> UpdateTokenPOS([FromBody] DashboardEntity model)
        {
            await _service.UpdateTokenPOS(model);
            return Ok();
        }

        [HttpGet("store-status")]
        public async Task<IActionResult> GetStoreStatus(long shopId)
        {
            return Ok(await _service.GetStoreStatus(shopId));
        }

        [HttpPost("publish-request")]
        public async Task<IActionResult> SaveShopRequestForPublish(long shopId)
        {
            await _service.SaveShopRequestForPublish(shopId);
            return Ok();
        }
        [HttpGet("store-details")]
        public async Task<IActionResult> GetStoreDetails(long shopId)
        {
            return Ok(await _service.GetStoreDetails(shopId));
        }

        [HttpGet("shop-request-data")]
        public async Task<IActionResult> GetShopRequestData(long shopId)
        {
            return Ok(await _service.GetShopRequestData(shopId));
        }

        [HttpDelete("delete-request")]
        public async Task<IActionResult> SaveShopDeleteRequest(long shopId, string requestText)
        {
            await _service.SaveShopDeleteRequest(shopId, requestText);
            return Ok();
        }

        [HttpGet("decimal-point")]
        public async Task<IActionResult> GetDecimalPoint(long shopId)
        {
            return Ok(await _service.GetDecimalPoint(shopId));
        }
        [HttpPut("update-payment-status")]
        public async Task<IActionResult> UpdatePaymentStatus(
            long shopId,
            string orderId,
            string paymentMethod)
        {
            await _service.UpdatePaymentStatus(shopId, orderId, paymentMethod);

            return Ok(new
            {
                message = "Payment updated successfully"
            });
        }
    }
}

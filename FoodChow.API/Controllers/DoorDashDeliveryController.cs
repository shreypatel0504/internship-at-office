using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/doordash")]
    public class DoorDashDeliveryController : ControllerBase
    {
        private readonly DoorDashDeliveryService _service;

        public DoorDashDeliveryController(DoorDashDeliveryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoorDashDeliveryEntity model)
        {
            await _service.Add(model);
            return Ok();
        }

        //[HttpPost("GetQuote")]
        //public async Task<IActionResult> GetQuote([FromBody] object model)
        //{
        //    // Later integrate actual DoorDash API

        //    return Ok(new
        //    {
        //        success = true,
        //        message = "Quote generated",
        //        delivery_fee = 50,
        //        currency = "USD"
        //    });
        //}

        [HttpPost("create-delivery")]
        public async Task<IActionResult> CreateDelivery(
    DoorDashDeliveryEntity model)
        {
            await _service.Add(model);

            return Ok(new
            {
                success = true,
                message = "Delivery created"
            });
        }

        [HttpPut("delivery")]
        public async Task<IActionResult> UpdateByDeliveryId(DoorDashDeliveryEntity model)
        {
            await _service.UpdateByDeliveryId(model);
            return Ok();
        }

        [HttpDelete("orders/{orderId}/shops/{shopId}/cancel-delivery")]
        public async Task<IActionResult> CancelDelivery(int orderId,int shopId)
        {
            await _service.UpdateStatus(orderId,shopId,"CANCELLED");

            return Ok(new
            {
                success = true,
                message = "Delivery cancelled"
            });
        }

        [HttpPatch("orders/{orderId}/shops/{shopId}/UpdateDelivery")]
        public async Task<IActionResult> UpdateDelivery(int orderId,int shopId,DoorDashDeliveryEntity model)
        {
            model.foodchow_order_id = orderId.ToString();
            model.shop_id = shopId.ToString();

            await _service.UpdateByDeliveryId(model);

            return Ok(new
            {
                success = true,
                message = "Delivery updated"
            });
        }

        [HttpGet("delivery-status/{orderId}/shops/{shopId}")]
        public async Task<IActionResult> DeliveryStatus(int orderId,int shopId)
        {
            var result = await _service.Get(orderId, shopId);

            return Ok(result);
        }

        [HttpGet("orders/{order_id}/delivery-details")]
        public async Task<IActionResult> GetDetails(int order_id,int shopId)
        {
            var result = await _service.Get(order_id, shopId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int orderId, int shopId)
        {
            return Ok(await _service.Get(orderId, shopId));
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(int orderId,int shopId,string status)
        {
            await _service.UpdateStatus(orderId, shopId, status);
            return Ok();
        }

        [HttpPut("external-status")]
        public async Task<IActionResult> UpdateExternalStatus(string externalId,string status,string trackingUrl,decimal? deliveryFee)
        {
            await _service.UpdateStatusByExternalId(externalId,status,trackingUrl,deliveryFee);
            return Ok();
        }

        [HttpPost("ReceiveWebhook")]
        public async Task<IActionResult> ReceiveWebhook([FromBody] DoorDashDeliveryEntity model)
        {
            await _service.UpdateStatusByExternalId(
                model.external_delivery_id,
                model.delivery_status,
                model.tracking_url,
                model.deliveryfee
            );

            return Ok();
        }
    }
}
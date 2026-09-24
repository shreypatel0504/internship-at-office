using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpGet("accept/{orderId}")]
        public async Task<IActionResult> AcceptOrder(string orderId) => Ok(await _service.AcceptOrder(orderId));

        [HttpDelete("delete/{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId) => Ok(await _service.DeleteOrder(orderId));

        [HttpPost("SaveCartWD_web")]
        public async Task<IActionResult> SaveCart([FromBody] OrderEntity model)
        {
            await _service.SaveCart(model);
            return Ok();
        }

        [HttpGet("PendingOrdersWDDriver")]
        public async Task<IActionResult> PendingOrders(long shopId, DateTime timezone, DateTime timedifferent, int startLimit = 0, int endLimit = 10)
            => Ok(await _service.GetPendingOrders(shopId, timezone, timedifferent, startLimit, endLimit));

        [HttpGet("GetDashboardNewOrdersWD")]
        public async Task<IActionResult> DashboardOrders(long shopId, DateTime timezone, int offset = 0, int limits = 10)
            => Ok(await _service.GetDashboardNewOrders(shopId, timezone, offset, limits));

        [HttpGet("MissedOrdersForPosOnlineOrderWD")]
        public async Task<IActionResult> MissedOrders(long shopId, DateTime timezone, int startLimit = 0, int endLimit = 10)
            => Ok(await _service.GetMissedOrders(shopId, timezone, startLimit, endLimit));

        [HttpGet("DeliveredOrdersForPosOnlineOrderW")]
        public async Task<IActionResult> DeliveredOrders(long shopId, DateTime timezone, int start = 0, int limits = 10)
            => Ok(await _service.GetDeliveredOrders(shopId, timezone, start, limits));

        [HttpGet("GetFullOrderDetails/{orderId}")]
        public async Task<IActionResult> GetFullOrderDetails(string orderId) => Ok(await _service.GetFullOrderDetails(orderId));

        [HttpGet("GetOrderItems/{orderId}")]
        public async Task<IActionResult> GetOrderItems(string orderId) => Ok(await _service.GetOrderItems(orderId));

        [HttpPut("UpdateOrderItemQty")]
        public async Task<IActionResult> UpdateOrderItemQty(long transId, double quantity)
        {
            await _service.UpdateOrderItemQty(transId, quantity);
            return Ok();
        }

        [HttpDelete("DeleteOrderItem/{transId}")]
        public async Task<IActionResult> DeleteOrderItem(long transId)
        {
            await _service.DeleteOrderItem(transId);
            return Ok();
        }

        [HttpGet("GetOrdersByStatus")]
        public async Task<IActionResult> GetOrdersByStatus(long shopId, long status) => Ok(await _service.GetOrdersByStatus(shopId, status));

        [HttpPut("UpdatePaymentMethod")]
        public async Task<IActionResult> UpdatePaymentMethod(string orderId, string paymentMethod)
        {
            await _service.UpdatePaymentMethod(orderId, paymentMethod);
            return Ok();
        }

        [HttpPut("MarkOrderPaid/{orderId}")]
        public async Task<IActionResult> MarkOrderPaid(string orderId)
        {
            await _service.MarkOrderPaid(orderId);
            return Ok();
        }

        [HttpGet("GetTodayOrderCount/{shopId}")]
        public async Task<IActionResult> GetTodayOrderCount(long shopId) => Ok(await _service.GetTodayOrderCount(shopId));

        [HttpGet("SearchOrders")]
        public async Task<IActionResult> SearchOrders(long shopId, string search) => Ok(await _service.SearchOrders(shopId, search));

        [HttpGet("GetLatestOrders/{shopId}")]
        public async Task<IActionResult> GetLatestOrders(long shopId) => Ok(await _service.GetLatestOrders(shopId));

        [HttpPost("SaveCart")]
        public async Task<IActionResult> SaveOrder([FromBody] SaveOrderDto orderData, [FromQuery] string url)
        {
            var result = await _service.SaveOrderAsync(orderData, url);
            return Ok(result);
        }
    }
}
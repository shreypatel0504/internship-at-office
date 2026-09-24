using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YocoPaymentController : ControllerBase
    {
        private readonly YocoPaymentService _service;

        public YocoPaymentController(YocoPaymentService service)
        {
            _service = service;
        }

        [HttpPost("SaveCredential")]
        public async Task<IActionResult> SaveCredential(YocoCredentialEntity e)
            => Ok(await _service.SaveCredential(e));

        [HttpGet("GetCredential/{shopId}")]
        public async Task<IActionResult> GetCredential(string shopId)
            => Ok(await _service.GetCredential(shopId));

        [HttpPost("CreateCheckout")]
        public async Task<IActionResult> CreateCheckout(YocoOrderPaymentEntity e)
            => Ok(await _service.CreateCheckout(e));

        [HttpPost("RefundPayment")]
        public async Task<IActionResult> RefundPayment(YocoOrderPaymentEntity e)
            => Ok(await _service.RefundPayment(e));

        [HttpGet("GetPaymentStatus/{orderId}")]
        public async Task<IActionResult> GetPaymentStatus(string orderId)
            => Ok(await _service.GetPaymentStatus(orderId));

        [HttpPost("SavePaymentError")]
        public async Task<IActionResult> SavePaymentError(YocoPaymentErrorEntity e)
            => Ok(await _service.SavePaymentError(e));

        [HttpPost("AddYocoCredential")]
        public async Task<IActionResult> Add(YocoCredentialEntity e)
        => Ok(await _service.AddYocoCredential(e));

        [HttpPut("UpdateYocoCredential")]
        public async Task<IActionResult> Update(YocoCredentialEntity e)
            => Ok(await _service.UpdateYocoCredential(e));

        [HttpGet("GetYocoCredential")]
        public async Task<IActionResult> Get(string shopId)
            => Ok(await _service.GetYocoCredential(shopId));

        [HttpPost("OrderCheckoutByYoco")]
        public async Task<IActionResult> Checkout(YocoOrderPaymentEntity e)
            => Ok(await _service.OrderCheckoutByYoco(e));

        [HttpPut("ReceiveYocoWebhook")]
        public async Task<IActionResult> Webhook(
            string checkoutId,
            string paymentId,
            string status)
            => Ok(await _service.ReceiveYocoWebhook(
                checkoutId, paymentId, status));

        [HttpPut("YocoPaymentRefund")]
        public async Task<IActionResult> Refund(
            string orderId,
            string refundId,
            string response)
            => Ok(await _service.YocoPaymentRefund(
                orderId, refundId, response));

        [HttpGet("GetYocoOrderPaymentDetails")]
        public async Task<IActionResult> Details(string orderId)
            => Ok(await _service.GetYocoOrderPaymentDetails(orderId));
    }

}
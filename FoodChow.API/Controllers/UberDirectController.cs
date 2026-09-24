using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UberDirectController : ControllerBase
    {
        private readonly UberDirectService _service;

        public UberDirectController(UberDirectService service)
        {
            _service = service;
        }

        [HttpPost("SaveIntegration")]
        public async Task<IActionResult> SaveIntegration(UberDirectIntegrationEntity e)
            => Ok(await _service.SaveIntegration(e));

        [HttpGet("GetIntegration/{shopId}")]
        public async Task<IActionResult> GetIntegration(long shopId)
            => Ok(await _service.GetIntegration(shopId));

        [HttpPost("CreateQuote")]
        public async Task<IActionResult> CreateQuote(UberDirectQuoteEntity e)
            => Ok(await _service.CreateQuote(e));

        [HttpGet("GetQuote/{quoteId}")]
        public async Task<IActionResult> GetQuote(string quoteId)
            => Ok(await _service.GetQuote(quoteId));

        [HttpPost("CreateDelivery")]
        public async Task<IActionResult> CreateDelivery(UberDirectQuoteEntity e)
            => Ok(await _service.CreateDelivery(e));

        [HttpGet("GetDelivery/{deliveryId}")]
        public async Task<IActionResult> GetDelivery(string deliveryId)
            => Ok(await _service.GetDelivery(deliveryId));

        [HttpPut("UpdateDeliveryStatus")]
        public async Task<IActionResult> UpdateStatus(string deliveryId, string status)
            => Ok(await _service.UpdateDeliveryStatus(deliveryId, status));

        [HttpGet("GetTrackingUrl/{orderId}")]
        public async Task<IActionResult> GetTracking(string orderId)
            => Ok(await _service.GetTrackingUrl(orderId));

        [HttpPost("quote")]
        public async Task<IActionResult> Quote(UberDirectQuoteEntity e)
            => Ok(await _service.AddQuote(e));

        [HttpPost("delivery")]
        public async Task<IActionResult> Delivery(UberDirectQuoteEntity e)
            => Ok(await _service.AddDelivery(e));

        [HttpDelete("cancel")]
        public async Task<IActionResult> Cancel(string deliveryId)
            => Ok(await _service.CancelDelivery(deliveryId));

        [HttpPost("ReceiveWebhook")]
        public async Task<IActionResult> ReceiveWebhook(UberDirectQuoteEntity e)
            => Ok(await _service.SaveWebhook(e));

    }
}
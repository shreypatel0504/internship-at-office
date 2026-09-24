using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _service;

        public InvoiceController(InvoiceService service)
        {
            _service = service;
        }

        [HttpPost("submit-document")]
        public async Task<IActionResult> SubmitDocument([FromBody] EInvoiceSubmitDocumentEntity model)
        {
            await _service.SubmitDocument(model);
            return Ok();
        }

        [HttpGet("document")]
        public async Task<IActionResult> GetDocument(
             [FromQuery] string shopId,
             [FromQuery] string orderId)
        {
            return Ok(await _service.GetSubmitDocument(shopId, orderId));
        }

        [HttpGet("shop-details/{shopId}")]
        public async Task<IActionResult> GetShopDetails(long shopId)
        {
            return Ok(await _service.GetShopInvoiceMalaysia(shopId));
        }

        [HttpPost("submit-status/add")]
        public async Task<IActionResult> AddStatus([FromBody] EInvoiceSubmitStatusEntity model)
        {
            await _service.AddSubmitStatus(model);
            return Ok();
        }

        [HttpPut("submit-status/update")]
        public async Task<IActionResult> UpdateStatus([FromBody] EInvoiceSubmitStatusEntity model)
        {
            await _service.UpdateSubmitStatus(model);
            return Ok();
        }

        [HttpGet("submit-status/{orderId}")]
        public async Task<IActionResult> GetStatus(string orderId)
        {
            return Ok(await _service.GetSubmitStatus(orderId));
        }

        [HttpPost("details/add")]
        public async Task<IActionResult> AddDetails([FromBody] EInvoiceDetailsEntity model)
        {
            await _service.AddInvoiceDetails(model);
            return Ok();
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(
             [FromQuery] string shopId,
             [FromQuery] string orderId)
        {
            return Ok(await _service.GetInvoiceDetails(shopId, orderId));
        }
    }
}

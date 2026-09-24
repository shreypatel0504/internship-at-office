using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppMasterController : ControllerBase
    {
        private readonly WhatsAppMasterService _service;

        public WhatsAppMasterController(WhatsAppMasterService service)
        {
            _service = service;
        }

        [HttpGet("GetCampaigns")]
        public async Task<IActionResult> GetCampaigns()
            => Ok(await _service.GetCampaigns());

        [HttpGet("GetCampaignByShop")]
        public async Task<IActionResult> GetCampaignByShop(string shopId)
            => Ok(await _service.GetCampaignByShop(shopId));

        [HttpPost("AddCampaign")]
        public async Task<IActionResult> AddCampaign(WhatsAppCampaignEntity e)
            => Ok(await _service.AddCampaign(e));

        [HttpPut("UpdateCampaign")]
        public async Task<IActionResult> UpdateCampaign([FromBody] WhatsAppCampaignEntity model)
        {
            return Ok(await _service.UpdateCampaign(model));
        }

        [HttpDelete("DeleteCampaign")]
        public async Task<IActionResult> DeleteCampaign(int id)
            => Ok(await _service.DeleteCampaign(id));

        [HttpGet("GetNotificationNumbers")]
        public async Task<IActionResult> GetNotificationNumbers(string shopId)
            => Ok(await _service.GetNotificationNumbers(shopId));

        [HttpPost("AddNotificationNumber")]
        public async Task<IActionResult> AddNotificationNumber(WhatsAppNotificationNumberEntity e)
            => Ok(await _service.AddNotificationNumber(e));

        [HttpDelete("DeleteNotificationNumber")]
        public async Task<IActionResult> DeleteNotificationNumber(int id)
            => Ok(await _service.DeleteNotificationNumber(id));

        [HttpGet("GetWebhookLogs")]
        public async Task<IActionResult> GetWebhookLogs()
            => Ok(await _service.GetWebhookLogs());

        [HttpPost("AddWebhookLog")]
        public async Task<IActionResult> AddWebhookLog(WhatsAppWebhookEntity e)
            => Ok(await _service.AddWebhookLog(e));

        [HttpGet("GetShopWhatsAppSummary")]
        public async Task<IActionResult> GetShopWhatsAppSummary(string shopId)
            => Ok(await _service.GetShopWhatsAppSummary(shopId));

        [HttpGet("GetTableWhatsAppSummary")]
        public async Task<IActionResult> GetTableWhatsAppSummary(string shopId)
            => Ok(await _service.GetTableWhatsAppSummary(shopId));
    }
}
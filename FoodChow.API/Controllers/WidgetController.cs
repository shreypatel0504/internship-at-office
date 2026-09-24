using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetSettingsController : ControllerBase
    {
        private readonly WidgetSettingsService _service;

        public WidgetSettingsController(WidgetSettingsService service)
        {
            _service = service;
        }

        [HttpGet("GetSeoConfig/{shopId}")]
        public async Task<IActionResult> GetSeoConfig(long shopId)
            => Ok(await _service.GetSeoConfig(shopId));

        [HttpPost("SaveSeoConfig")]
        public async Task<IActionResult> SaveSeoConfig(SeoConfigEntity e)
            => Ok(await _service.SaveSeoConfig(e));

        [HttpGet("GetWidgetSettings/{shopId}")]
        public async Task<IActionResult> GetWidgetSettings(long shopId)
            => Ok(await _service.GetWidgetSettings(shopId));

        [HttpPost("SaveWidgetSettings")]
        public async Task<IActionResult> SaveWidgetSettings(WidgetSettingEntity e)
            => Ok(await _service.SaveWidgetSettings(e));

        [HttpPut("ChangeWebsiteColor")]
        public async Task<IActionResult> ChangeWebsiteColor(long shopId, string color)
            => Ok(await _service.ChangeWebsiteColor(shopId, color));

        [HttpGet("GetVideoHelp")]
        public async Task<IActionResult> GetVideoHelp()
            => Ok(await _service.GetVideoHelp());

        [HttpGet("GetVideoHelpBySection/{section}")]
        public async Task<IActionResult> GetVideoHelpBySection(string section)
            => Ok(await _service.GetVideoHelpBySection(section));

        [HttpPost("AddVideoHelp")]
        public async Task<IActionResult> AddVideoHelp(VideoHelpEntity e)
            => Ok(await _service.AddVideoHelp(e));

        [HttpPut("UpdateVideoHelp")]
        public async Task<IActionResult> UpdateVideoHelp(VideoHelpEntity e)
            => Ok(await _service.UpdateVideoHelp(e));

        [HttpDelete("DeleteVideoHelp/{id}")]
        public async Task<IActionResult> DeleteVideoHelp(int id)
            => Ok(await _service.DeleteVideoHelp(id));

        [HttpGet("GetStoreWidgetSettings")]
        public async Task<IActionResult> GetStoreWidgetSettings(long shopId)
        {
            return Ok(await _service.GetStoreWidgetSettings(shopId));
        }

        [HttpGet("CheckStoreCustomDomain")]
        public async Task<IActionResult> CheckStoreCustomDomain(long shopId)
        {
            return Ok(await _service.CheckStoreCustomDomain(shopId));
        }

        [HttpPut("UpdateWidgetSettingsGlobal")]
        public async Task<IActionResult> UpdateWidgetSettingsGlobal(long shopId, string websiteColor)
        {
            return Ok(await _service.UpdateWidgetSettingsGlobal(shopId, websiteColor));
        }

        [HttpPut("UpdateFoodchowVideoHelpStatus")]
        public async Task<IActionResult> UpdateFoodchowVideoHelpStatus(int id, int status)
        {
            return Ok(await _service.UpdateFoodchowVideoHelpStatus(id, status));
        }
    }
}
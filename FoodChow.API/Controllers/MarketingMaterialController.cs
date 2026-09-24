using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingMaterialController : ControllerBase
    {
        private readonly MarketingMaterialService _service;

        public MarketingMaterialController(MarketingMaterialService service)
        {
            _service = service;
        }

        [HttpGet("GetMarketing/{shopId}")]
        public async Task<IActionResult> GetMarketing(long shopId)
            => Ok(await _service.GetMarketing(shopId));

        [HttpPost("AddMarketing")]
        public async Task<IActionResult> AddMarketing(MarketingEntity e)
            => Ok(await _service.AddMarketing(e));

        [HttpPut("UpdateMarketing")]
        public async Task<IActionResult> UpdateMarketing(MarketingEntity e)
            => Ok(await _service.UpdateMarketing(e));

        [HttpDelete("DeleteMarketing/{id}")]
        public async Task<IActionResult> DeleteMarketing(long id)
            => Ok(await _service.DeleteMarketing(id));

        [HttpGet("GetBanners/{shopId}")]
        public async Task<IActionResult> GetBanners(long shopId)
            => Ok(await _service.GetBanners(shopId));

        [HttpPost("AddBanner")]
        public async Task<IActionResult> AddBanner(BannerEntity e)
            => Ok(await _service.AddBanner(e));

        [HttpGet("GetSeo/{shopId}")]
        public async Task<IActionResult> GetSeo(long shopId)
            => Ok(await _service.GetSeo(shopId));

        [HttpPost("SaveSeo")]
        public async Task<IActionResult> SaveSeo(SeoEntity e)
            => Ok(await _service.SaveSeo(e));
    }
}
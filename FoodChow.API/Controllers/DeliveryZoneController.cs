using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryZoneController : ControllerBase
    {
        private readonly DeliveryZoneService _service;

        public DeliveryZoneController(DeliveryZoneService service)
        {
            _service = service;
        }

        [HttpPost("SaveDeliveryZone")]
        public async Task<IActionResult> SaveDeliveryZone([FromBody] DeliveryZoneEntity model)
        {
            await _service.SaveDeliveryZone(model);
            return Ok();
        }

        [HttpGet("GetAllStoreZone")]
        public async Task<IActionResult> GetAllStoreZone(long shopId)
        {
            return Ok(await _service.GetAllStoreZone(shopId));
        }

        [HttpDelete("DeleteZoneByZoneId")]
        public async Task<IActionResult> DeleteZoneByZoneId(long shopId, int zoneId)
        {
            await _service.DeleteZoneByZoneId(shopId, zoneId);
            return Ok();
        }

        [HttpGet("GetZoneDetailsByZoneName")]
        public async Task<IActionResult> GetZoneDetailsByZoneName(string zoneNo, long shopId)
        {
            return Ok(await _service.GetZoneDetailsByZoneName(zoneNo, shopId));
        }

        [HttpPut("UpdateZoneDetails")]
        public async Task<IActionResult> UpdateZoneDetails([FromBody] DeliveryZoneEntity model)
        {
            await _service.UpdateZoneDetails(model);
            return Ok();
        }

        [HttpPost("InsertDeliveryOption")]
        public async Task<IActionResult> InsertDeliveryOption(int shopId, int optionId, int status)
        {
            await _service.InsertDeliveryOption(shopId, optionId, status);
            return Ok();
        }

        [HttpPut("UpdateDeliveryOption")]
        public async Task<IActionResult> UpdateDeliveryOption(int shopId, int optionId, int status)
        {
            await _service.UpdateDeliveryOption(shopId, optionId, status);
            return Ok();
        }

        [HttpGet("GetDeliveryOptions")]
        public async Task<IActionResult> GetDeliveryOptions(int shopId)
        {
            return Ok(await _service.GetDeliveryOptions(shopId));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using FoodChow.Application.Entities;
using FoodChow.Application.Services;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly MasterService _masterService;

        public MasterController(MasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpGet("GetCustomDomainAdmin")]
        public async Task<IActionResult> GetCustomDomainAdmin(long shopId)
        {
            return Ok(await _masterService.GetCustomDomain(shopId));
        }

        [HttpPost("SaveCustomDomainAdmin")]
        public async Task<IActionResult> SaveCustomDomainAdmin(long shopId, string subdomain, string customDomain)
        {
            await _masterService.SaveCustomDomain(shopId, subdomain, customDomain);
            return Ok("Saved successfully");
        }

        [HttpGet("CheckSubdomainExistsOrNot")]
        public async Task<IActionResult> CheckSubdomainExistsOrNot(string subdomain)
        {
            return Ok(await _masterService.CheckSubdomain(subdomain));
        }

        [HttpGet("CheckEmailVerifiedOrNot")]
        public async Task<IActionResult> CheckEmailVerifiedOrNot(string email)
        {
            return Ok(await _masterService.CheckEmailVerified(email));
        }

        [HttpGet("GetStoreEmailFromShopId")]
        public async Task<IActionResult> GetStoreEmailFromShopId(long shopId)
        {
            return Ok(await _masterService.GetStoreEmail(shopId));
        }

        [HttpPost("SaveStoreSetupPhase1")]
        public async Task<IActionResult> SaveStoreSetupPhase1([FromBody] MasterEntity model)
        {
            return Ok(await _masterService.SaveStoreSetupPhase1(model));
        }

        [HttpPost("SaveStoreSetupPhaseFinal")]
        public async Task<IActionResult> SaveStoreSetupPhaseFinal([FromBody] MasterEntity model)
        {
            return Ok(await _masterService.SaveStoreSetupFinal(model));
        }

        [HttpPut("UpdateShopCnameEntry")]
        public async Task<IActionResult> UpdateShopCnameEntry(long shopId, string domain)
        {
            await _masterService.UpdateShopCname(shopId, domain);
            return Ok("Updated successfully");
        }

        [HttpGet("GetAllTypeOfBusiness")]
        public async Task<IActionResult> GetAllTypeOfBusiness()
        {
            return Ok(await _masterService.GetAllBusinessTypes());
        }

        [HttpPost("Add_PosSserviceCharge")]
        public async Task<IActionResult> Add_PosSserviceCharge(long shopId, double rate, string label)
        {
            await _masterService.AddPosServiceCharge(shopId, rate, label);
            return Ok("Added successfully");
        }

        [HttpPut("UpdatePosSserviceCharge")]
        public async Task<IActionResult> UpdatePosSserviceCharge(long shopId, double rate, string label)
        {
            await _masterService.UpdatePosServiceCharge(shopId, rate, label);
            return Ok("Updated successfully");
        }

        [HttpGet("GetAiMenuAddList")]
        public async Task<IActionResult> GetAiMenuAddList()
        {
            return Ok(await _masterService.GetAiMenuList());
        }

        [HttpPut("UpdateAiMenuStatus")]
        public async Task<IActionResult> UpdateAiMenuStatus(int id, int status)
        {
            await _masterService.UpdateAiMenuStatus(id, status);
            return Ok("Updated successfully");
        }

        [HttpGet("GetAiMenuByShopId")]
        public async Task<IActionResult> GetAiMenuByShopId(long shopId)
        {
            return Ok(await _masterService.GetAiMenuByShopId(shopId));
        }
        [HttpGet("GetShopDetails")]
        public async Task<IActionResult> GetShopDetails(string subdomain)
        => Ok(await _masterService.GetShopDetails(subdomain));

        [HttpGet("GetShopAddress")]
        public async Task<IActionResult> GetShopAddress(long shopId)
        => Ok(await _masterService.GetShopAddress(shopId));

        [HttpGet("GetShopSettings")]
        public async Task<IActionResult> GetShopSettings(long shopId)
        => Ok(await _masterService.GetShopSettings(shopId));

        [HttpPut("UpdateShopStatus")]
        public async Task<IActionResult> UpdateShopStatus(long shopId, int status)
        {
            await _masterService.UpdateShopStatus(shopId, status);
            return Ok();
        }

        [HttpGet("GetPosServiceCharge")]
        public async Task<IActionResult> GetPosServiceCharge(long shopId)
        => Ok(await _masterService.GetPosServiceCharge(shopId));

        [HttpDelete("DeletePosServiceCharge")]
        public async Task<IActionResult> DeletePosServiceCharge(int id)
        {
            await _masterService.DeletePosServiceCharge(id);
            return Ok();
        }

        [HttpGet("GetDomainStatus")]
        public async Task<IActionResult> GetDomainStatus(long shopId)
        => Ok(await _masterService.GetDomainStatus(shopId));

        [HttpPost("UpdateDomainStatus")]
        public async Task<IActionResult> UpdateDomainStatus(long shopId, int status)
        {
            await _masterService.UpdateDomainStatus(shopId, status);
            return Ok();
        }

        [HttpDelete("DeleteAiMenu")]
        public async Task<IActionResult> DeleteAiMenu(int id)
        {
            await _masterService.DeleteAiMenu(id);
            return Ok();
        }

        [HttpGet("GetShopTimezone")]
        public async Task<IActionResult> GetShopTimezone(long shopId)
        => Ok(await _masterService.GetShopTimezone(shopId));
    }
}
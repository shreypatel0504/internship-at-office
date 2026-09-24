using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferAndEarnController : ControllerBase
    {
        private readonly ReferAndEarnService _service;

        public ReferAndEarnController(ReferAndEarnService service)
        {
            _service = service;
        }

        [HttpGet("AllCampaign")]
        public async Task<IActionResult> GetAllCampaign()
            => Ok(await _service.GetAllCampaign());

        [HttpGet("CampaignsByShop")]
        public async Task<IActionResult> GetCampaignsByShop(string shopId)
            => Ok(await _service.GetCampaignsByShop(shopId));

        [HttpPost("AddCampaign")]
        public async Task<IActionResult> AddCampaign(CampaignEntity e)
            => Ok(await _service.AddCampaign(e));

        [HttpPut("UpdateCampaign")]
        public async Task<IActionResult> UpdateCampaign(CampaignEntity e)
            => Ok(await _service.UpdateCampaign(e));

        [HttpDelete("DeleteCampaign")]
        public async Task<IActionResult> DeleteCampaign(int id)
            => Ok(await _service.DeleteCampaign(id));

        [HttpGet("AllReferralRewards")]
        public async Task<IActionResult> GetAllReferralRewards()
            => Ok(await _service.GetAllReferralRewards());

        [HttpGet("GetRewardsForUser")]
        public async Task<IActionResult> GetRewardsForUser(string userId)
            => Ok(await _service.GetRewardsForUser(userId));

        [HttpGet("AllUser")]
        public async Task<IActionResult> GetAllUsers()
            => Ok(await _service.GetAllUsers());

        [HttpGet("GetWalletByUserId")]
        public async Task<IActionResult> GetWalletByUserId(string userId)
            => Ok(await _service.GetWalletByUserId(userId));

        [HttpGet("AllCashback")]
        public async Task<IActionResult> GetAllCashback()
            => Ok(await _service.GetAllCashback());

        //[HttpGet("GetCashback")]
        //public async Task<IActionResult> GetCashback(string shopId)
        //    => Ok(await _service.GetCashback(shopId));

        [HttpPut("UpdateReferralReward")]
        public async Task<IActionResult> UpdateReferralReward(ReferralRewardEntity e)
        => Ok(await _service.UpdateReferralReward(e));

        [HttpDelete("DeleteReferralReward")]
        public async Task<IActionResult> DeleteReferralReward(int id)
        => Ok(await _service.DeleteReferralReward(id));

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(string userId)
        => Ok(await _service.AddUser(userId));

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        => Ok(await _service.DeleteUser(userId));

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(WalletEntity e)
        => Ok(await _service.UpdateUser(e));

        [HttpGet("GetCashback")]
        public async Task<IActionResult> GetCashback(string shopId)
        => Ok(await _service.GetCashback(shopId));

        [HttpPut("UpdateRefferedStatus")]
        public async Task<IActionResult> UpdateRefferedStatus(int id)
        => Ok(await _service.UpdateRefferedStatus(id));

        [HttpGet("UsersShopCashbackHistory")]
        public async Task<IActionResult> UsersShopCashbackHistory(string userId)
        => Ok(await _service.UsersShopCashbackHistory(userId));

        [HttpGet("UsersFoodchowCashbackHistory")]
        public async Task<IActionResult> UsersFoodchowCashbackHistory(string userId)
        => Ok(await _service.UsersFoodchowCashbackHistory(userId));

        [HttpGet("ActiveCampaignsByShop")]
        public async Task<IActionResult> ActiveCampaignsByShop(string shopId)
        => Ok(await _service.ActiveCampaignsByShop(shopId));
    }
}
using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _service;

        public WalletController(WalletService service)
        {
            _service = service;
        }

        [HttpGet("GetUserWallet")]
        public async Task<IActionResult> GetUserWallet(string userId)
            => Ok(await _service.GetUserWallet(userId));

        [HttpPost("AddUserWallet")]
        public async Task<IActionResult> AddUserWallet(WalletEntity e)
            => Ok(await _service.AddUserWallet(e));

        [HttpPut("UpdateUserWallet")]
        public async Task<IActionResult> UpdateUserWallet(WalletEntity e)
            => Ok(await _service.UpdateUserWallet(e));

        [HttpGet("GetPointPlanHistory")]
        public async Task<IActionResult> GetPointPlanHistory(long shopId)
            => Ok(await _service.GetPointPlanHistory(shopId));

        [HttpPost("AddPointPlan")]
        public async Task<IActionResult> AddPointPlan(PointPlanDetailsEntity e)
            => Ok(await _service.AddPointPlan(e));

        [HttpGet("GetCurrentPointPlan")]
        public async Task<IActionResult> GetCurrentPointPlan(long shopId)
            => Ok(await _service.GetCurrentPointPlan(shopId));

        [HttpPut("UpdateCurrentPointPlan")]
        public async Task<IActionResult> UpdateCurrentPointPlan(CurrentPointPlanEntity e)
            => Ok(await _service.UpdateCurrentPointPlan(e));
        [HttpGet("GetRestaurantWalletSummary")]
        public async Task<IActionResult> GetRestaurantWalletSummary(long shopId)
            => Ok(await _service.GetRestaurantWalletSummary(shopId));

        [HttpGet("GetReferralDetailsByRestaurant")]
        public async Task<IActionResult> GetReferralDetailsByRestaurant(string shopId)
            => Ok(await _service.GetReferralDetailsByRestaurant(shopId));

        [HttpPost("AddFoodChowPricingPlanPoint")]
        public async Task<IActionResult> AddFoodChowPricingPlanPoint(
            long shopId,
            double amount,
            double coins,
            string planName)
        {
            var obj = new PointPlanDetailsEntity
            {
                ShopId = shopId,
                Amount = amount,
                Coins = coins,
                PlanName = planName
            };

            return Ok(await _service.AddFoodChowPricingPlanPoint(obj));
        }

        [HttpGet("GetFoodChowPricingPlanPoint")]
        public async Task<IActionResult> GetFoodChowPricingPlanPoint(long shopId)
            => Ok(await _service.GetFoodChowPricingPlanPoint(shopId));
    }
}
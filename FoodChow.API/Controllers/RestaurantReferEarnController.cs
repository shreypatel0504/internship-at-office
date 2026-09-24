using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Restaurant_Refer_EarnController : ControllerBase
    {
        private readonly RestaurantReferEarnService _service;

        public Restaurant_Refer_EarnController(
            RestaurantReferEarnService service)
        {
            _service = service;
        }

        [HttpGet("GetReferredRestaurants")]
        public async Task<IActionResult> GetReferredRestaurants()
            => Ok(await _service.GetReferredRestaurants());

        [HttpGet("GetOwnReferredRestaurantsByShopId")]
        public async Task<IActionResult>
            GetOwnReferredRestaurantsByShopId(string shopId)
            => Ok(await _service
                .GetOwnReferredRestaurantsByShopId(shopId));

        [HttpGet("GetReferredRestaurantsByShopId")]
        public async Task<IActionResult>
            GetReferredRestaurantsByShopId(string shopId)
            => Ok(await _service
                .GetReferredRestaurantsByShopId(shopId));

        [HttpPost("AddReferredRestaurants")]
        public async Task<IActionResult>
            AddReferredRestaurants(ReferredRestaurantEntity e)
            => Ok(await _service.AddReferredRestaurant(e));

        [HttpDelete("DeleteReferredRestaurant")]
        public async Task<IActionResult>
            DeleteReferredRestaurant(int id)
            => Ok(await _service.DeleteReferredRestaurant(id));

        [HttpDelete("DeleteCashback")]
        public async Task<IActionResult>
            DeleteCashback(string shopId)
            => Ok(await _service.DeleteCashback(shopId));

        [HttpGet("SendReferralMailForUser")]
        public async Task<IActionResult>
            SendReferralMailForUser(string email)
            => Ok(await _service.SendReferralMailForUser(email));

        [HttpGet("SendWhatsAppMessageForRefferdRestaurant")]
        public async Task<IActionResult>
            SendWhatsAppMessageForRefferdRestaurant(string shopId)
            => Ok(await _service
                .SendWhatsAppMessageForRefferdRestaurant(shopId));

        [HttpPost("AddClaimRequestByOwner")]
        public async Task<IActionResult>
            AddClaimRequestByOwner(ClaimRequestOwnerEntity e)
            => Ok(await _service.AddClaimRequestByOwner(e));

        [HttpGet("GetClaimRequestByOwner")]
        public async Task<IActionResult>
            GetClaimRequestByOwner(string shopId)
            => Ok(await _service.GetClaimRequestByOwner(shopId));
    }
}
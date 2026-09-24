using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTreeController : ControllerBase
    {
        private readonly RestaurantTreeService _service;

        public RestaurantTreeController(RestaurantTreeService service)
        {
            _service = service;
        }

        [HttpPost("AddRestaurantShoptree")]
        public async Task<IActionResult> Add(RestaurantTreeEntity e)
            => Ok(await _service.AddRestaurantShoptree(e));

        [HttpPut("UpdateRestaurantShoptree")]
        public async Task<IActionResult> Update(RestaurantTreeEntity e)
            => Ok(await _service.UpdateRestaurantShoptree(e));

        [HttpPut("UpdateRestaurantShoptreeStatus")]
        public async Task<IActionResult> UpdateStatus(long id, int status)
            => Ok(await _service.UpdateRestaurantShoptreeStatus(id, status));

        [HttpPut("UpdateRestaurantShoptreeImage")]
        public async Task<IActionResult> UpdateImage(long id, string image)
            => Ok(await _service.UpdateRestaurantShoptreeImage(id, image));

        [HttpDelete("DeleteRestaurantShoptree")]
        public async Task<IActionResult> Delete(long id)
            => Ok(await _service.DeleteRestaurantShoptree(id));

        [HttpGet("GetRestaurantShoptree")]
        public async Task<IActionResult> Get(string shopId)
            => Ok(await _service.GetRestaurantShoptree(shopId));

        [HttpGet("GetRestaurantOverView")]
        public async Task<IActionResult> GetOverview(long shopId)
            => Ok(await _service.GetRestaurantOverView(shopId));

        [HttpGet("GetShopOffersAndDeals")]
        public async Task<IActionResult> GetOffers(long shopId)
            => Ok(await _service.GetShopOffersAndDeals(shopId));

        [HttpGet("GetRecommendedAndTopSellingItemsByShop")]
        public async Task<IActionResult> GetRecommended(int shopId)
            => Ok(await _service.GetRecommendedAndTopSellingItemsByShop(shopId));


        [HttpPost("AddUserWhatsAppSubscribe")]
        public async Task<IActionResult> AddWhatsApp(UserWhatsAppSubscribeEntity e)
        => Ok(await _service.AddUserWhatsAppSubscribe(e));


        [HttpPost("AddFoodShopFaqDetails")]
        public async Task<IActionResult> AddFaq(FoodShopFaqEntity e)
        => Ok(await _service.AddFoodShopFaqDetails(e));


        [HttpGet("GetFaqCategories")]
        public async Task<IActionResult> GetFaqCategories()
        => Ok(await _service.GetFaqCategories());


        [HttpGet("GetFoodShopFaqDetails")]
        public async Task<IActionResult> GetFaq(string shopId)
        => Ok(await _service.GetFoodShopFaqDetails(shopId));


        [HttpPut("UpdateFoodShopFaqDetails")]
        public async Task<IActionResult> UpdateFaq(FoodShopFaqEntity e)
        => Ok(await _service.UpdateFoodShopFaqDetails(e));


        [HttpPut("UpdateFoodShopFaqStatus")]
        public async Task<IActionResult> UpdateFaqStatus(int id, int status)
        => Ok(await _service.UpdateFoodShopFaqStatus(id, status));


        [HttpDelete("DeleteFoodShopFaq")]
        public async Task<IActionResult> DeleteFaq(int id)
        => Ok(await _service.DeleteFoodShopFaq(id));


        [HttpGet("GetRestaurantTestimonials")]
        public async Task<IActionResult> GetTestimonials(string shopId)
        => Ok(await _service.GetRestaurantTestimonials(shopId));

        [HttpPost("AddFeedBack")]
        public async Task<IActionResult> AddFeedBack(FoodFeedbackEntity model)
        {
            return Ok(await _service.AddFeedBack(model));
        }

        [HttpGet("GetRestaurantJobRequirement")]
        public async Task<IActionResult> GetRestaurantJobRequirement(string shopId)
        {
            return Ok(await _service.GetRestaurantJobRequirement(shopId));
        }

        [HttpGet("GetRestaurantWebSiteColor")]
        public async Task<IActionResult> GetRestaurantWebSiteColor(long shopId)
        {
            return Ok(await _service.GetRestaurantWebSiteColor(shopId));
        }
        [HttpPut("ChangeWebSiteColor")]
        public async Task<IActionResult> ChangeWebSiteColor(long shopId, string color)
        {
            return Ok(await _service.ChangeWebSiteColor(shopId, color));
        }

        [HttpGet("GetRestaurantOverViewForWeb")]
        public async Task<IActionResult>
        GetRestaurantOverViewForWeb(long shopId)
        {
            return Ok(await _service.GetRestaurantOverViewForWeb(shopId));
        }

        [HttpGet("SendWhatsAppMessageForSubscribeUserAutoChat")]
        public async Task<IActionResult> SendWhatsAppMessagerForSubscribeUserAutoChat(string shopId)
        {
            return Ok(await _service.SendWhatsAppMessageForSubscribeUserAutoChat(shopId));
        }
            



    }
}
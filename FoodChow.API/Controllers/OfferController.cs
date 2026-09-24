using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly OfferService _service;

        public OfferController(OfferService service)
        {
            _service = service;
        }

        [HttpPost("SaveStoreOfferRMS")]
        public async Task<IActionResult> SaveOffer([FromBody] OfferEntity model)
        {
            await _service.SaveOffer(model);
            return Ok();
        }

        [HttpPost("SaveStoreOfferRMSNew")]
        public async Task<IActionResult> SaveOfferNew([FromBody] OfferEntity model)
        {
            await _service.SaveOfferNew(model);
            return Ok();
        }

        [HttpPost("OfferImageUpload")]
        public async Task<IActionResult> OfferImageUpload(long id, string image_name)
        {
            await _service.UploadOfferImage(id, image_name);

            return Ok(new
            {
                success = true,
                message = "Offer image uploaded successfully"
            });
        }
        [HttpGet("GetAllRestaurantsOffersRMS")]
        public async Task<IActionResult> GetAllRestaurantsOffersRMS(
     long shopId,
     int flag,
     string currtime)
        {
            var result = await _service.GetAllOffers(
                shopId,
                flag,
                currtime);

            return Ok(result);
        }

        [HttpGet("GetAllRestaurantsOffersRMSNew")]
        public async Task<IActionResult> GetOffersNew(long shopId)
        {
            return Ok(await _service.GetAllOffersNew(shopId));
        }

        [HttpPut("ChangeRestaurantOfferStatusRMS")]
        public async Task<IActionResult> ChangeStatus(long id, int status)
        {
            await _service.ChangeOfferStatus(id, status);
            return Ok();
        }

        [HttpPut("UpdateRestaurantOfferRMS")]
        public async Task<IActionResult> UpdateOffer([FromBody] OfferEntity model)
        {
            await _service.UpdateOffer(model);
            return Ok();
        }

        [HttpPut("UpdateRestaurantOfferRMSNew")]
        public async Task<IActionResult> UpdateOfferNew([FromBody] OfferEntity model)
        {
            await _service.UpdateOfferNew(model);
            return Ok();
        }

        [HttpGet("GetLastOfferImageForRMS")]
        public async Task<IActionResult> GetLastImage(long shopId)
        {
            return Ok(await _service.GetLastOfferImage(shopId));
        }

        [HttpPost("UploadRestaurantImageRMS")]
        public async Task<IActionResult> UploadRestaurantImage(long shopId, string image)
        {
            await _service.UploadRestaurantImage(shopId, image);
            return Ok();
        }

        [HttpGet("GetOfferById/{id}")]
        public async Task<IActionResult> GetOfferById(long id)
        {
            return Ok(await _service.GetOfferById(id));
        }

        [HttpDelete("DeleteOffer/{id}")]
        public async Task<IActionResult> DeleteOffer(long id)
        {
            await _service.DeleteOffer(id);
            return Ok("Offer deleted");
        }

        [HttpPatch("ChangeOfferStatus")]
        public async Task<IActionResult> ChangeOfferStatus(long id, int status)
        {
            await _service.ChangeOfferStatus(id, status);
            return Ok("Status updated");
        }

        [HttpGet("GetActiveOffers/{shopId}")]
        public async Task<IActionResult> GetActiveOffers(long shopId)
        {
            return Ok(await _service.GetActiveOffers(shopId));
        }

        //[HttpGet("GetExpiredOffers/{shopId}")]
        //public async Task<IActionResult> GetExpiredOffers(long shopId)
        //{
        //    return Ok(await _service.GetExpiredOffers(shopId));
        //}

        [HttpGet("GetOffersByDate")]
        public async Task<IActionResult> GetOffersByDate(long shopId,DateTime start,DateTime end)
        {
            return Ok(await _service
                .GetOffersByDate(shopId, start, end));
        }

        [HttpPut("UpdateOfferTiming")]
        public async Task<IActionResult> UpdateOfferTiming(long id,DateTime startDateTime,DateTime endDateTime,DateTime startDate,DateTime endDate,string startTime,string endTime,string days)
        {
            await _service.UpdateOfferTiming(id,startDateTime,endDateTime,startDate,endDate,startTime,endTime,days);

            return Ok("Updated Successfully");
        }
    }
}
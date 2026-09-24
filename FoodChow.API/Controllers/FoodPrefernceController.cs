using FoodChow.Application.Entities;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodPreferenceController : ControllerBase
    {
        private readonly FoodPreferenceService _service;

        public FoodPreferenceController(FoodPreferenceService service)
        {
            _service = service;
        }

        [HttpGet("GetAll/{shopId}")]
        public async Task<IActionResult> GetAll(long shopId)
        {
            var data = await _service.GetAllPreferences(shopId);
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.GetPreferenceById(id);
            return Ok(data);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] FoodPreferenceEntity model)
        {
            var id = await _service.AddPreference(model);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] FoodPreferenceEntity model)
        {
            await _service.UpdatePreference(model);
            return Ok("Updated Successfully");
        }

        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(long id, int status)
        {
            await _service.ChangePreferenceStatus(id, status);
            return Ok("Status Updated");
        }

        [HttpGet("GetOptions/{preferenceId}")]
        public async Task<IActionResult> GetOptions(long preferenceId)
        {
            var data = await _service.GetPreferenceOptions(preferenceId);
            return Ok(data);
        }

        //[HttpPost("AddOption")]
        //public async Task<IActionResult> AddOption([FromBody] FoodPreferenceOptionEntity model)
        //{
        //    var id = await _service.AddPreferenceOption(model);
        //    return Ok(id);
        //}

        //[HttpPut("UpdateOption")]
        //public async Task<IActionResult> UpdateOption([FromBody] FoodPreferenceOptionEntity model)
        //{
        //    await _service.UpdatePreferenceOption(model);
        //    return Ok("Updated Successfully");
        //}

        //[HttpDelete("DeleteOption/{id}")]
        //public async Task<IActionResult> DeleteOption(long id)
        //{
        //    await _service.DeletePreferenceOption(id);
        //    return Ok("Deleted Successfully");
        //}

        [HttpPost("MapToItem")]
        public async Task<IActionResult> MapToItem(
            long itemId,
            long preferenceId,
            int isMandatory,
            long maxSelection)
        {
            var id = await _service.MapPreferenceToItem(
                itemId,
                preferenceId,
                isMandatory,
                maxSelection);

            return Ok(id);
        }
    }
}
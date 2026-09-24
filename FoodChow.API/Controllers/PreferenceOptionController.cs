using FoodChow.Application.Entities;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceOptionController : ControllerBase
    {
        private readonly PreferenceOptionService _service;

        public PreferenceOptionController(
            PreferenceOptionService service)
        {
            _service = service;
        }

        [HttpGet("GetAll/{preferenceId}")]
        public async Task<IActionResult> GetAll(long preferenceId)
        {
            var result = await _service.GetAll(preferenceId);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(
            [FromBody] FoodPreferenceOptionEntity model)
        {
            var id = await _service.Add(model);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(
            [FromBody] FoodPreferenceOptionEntity model)
        {
            await _service.Update(model);
            return Ok("Updated Successfully");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.Delete(id);
            return Ok("Deleted Successfully");
        }
    }
}
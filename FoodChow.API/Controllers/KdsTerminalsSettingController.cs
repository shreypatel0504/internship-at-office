using FoodChow.Application.DTOs;
using FoodChow.Application.Interfaces;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KdsTerminalsSettingController : ControllerBase
    {
        private readonly IKdsTerminalsSettingRepository _service;

        public KdsTerminalsSettingController(IKdsTerminalsSettingRepository service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddKdsTerminalSettingDto dto)
        {
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateKdsTerminalSettingDto dto)
        {
            var result = await _service.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(long id, long shopId)
        {
            var result = await _service.DeleteAsync(id, shopId);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(long shopId)
        {
            var result = await _service.GetAllAsync(shopId);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(long id, long shopId)
        {
            var result = await _service.GetByIdAsync(id, shopId);
            return Ok(result);
        }
    }
}
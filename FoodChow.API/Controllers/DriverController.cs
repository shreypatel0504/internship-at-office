using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _service;
        public DriverController(DriverService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] DriverEntity model)
        {
            await _service.AddDriver(model);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] DriverEntity model)
        {
            await _service.UpdateDriver(model);
            return Ok();
        }
        [HttpGet("all/{shopId}")]
        public async Task<IActionResult> GetAll(long shopId)
        {
            return Ok(await _service.GetAllDrivers(shopId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.GetDriverById(id));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            return Ok(await _service.DriverLogin(email, password));
        }
        [HttpPut("status")]
        public async Task<IActionResult> ChangeStatus(long id, int status)
        {
            await _service.ChangeDriverStatus(id, status);
            return Ok();
        }
        [HttpPut("online-status")]
        public async Task<IActionResult> ChangeOnlineStatus(long id, int status)
        {
            await _service.ChangeOnlineStatus(id, status);
            return Ok();
        }
        [HttpPut("location")]
        public async Task<IActionResult> UpdateLocation(long id, string
        latitude, string longitude)
        {
            await _service.UpdateLocation(id, latitude, longitude);
            return Ok();
        }
        [HttpPut("token")]
        public async Task<IActionResult> UpdateToken(long id, string token)
        {
            await _service.UpdateToken(id, token);
            return Ok();
        }

        [HttpPost("assign-order")]
        public async Task<IActionResult> AssignOrder([FromBody] DriverOrderAssignEntity model)
        {
            await _service.AssignOrder(model);
            return Ok();
        }
        [HttpGet("orders/{orderId}")]
        public async Task<IActionResult> Orders(string orderId)
        {
            return Ok(await _service.GetDriverOrders(orderId));
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> Profile(long id)
        {
            return Ok(await _service.GetDriverProfile(id));
        }
    }
}
            
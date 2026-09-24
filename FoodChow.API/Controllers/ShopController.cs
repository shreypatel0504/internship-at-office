using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("{shop_id:int}")]
        [ProducesResponseType(typeof(ApiResponse<ShopDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ShopDetailsDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShopDetails([FromRoute] int shop_id)
        {
            var result = await _shopService.GetShopDetailsAsync(shop_id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}

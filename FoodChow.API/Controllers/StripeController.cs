using FoodChow.Application.Services;
using FoodChow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly StripeService _service;

        public StripeController(StripeService service)
        {
            _service = service;
        }

        [HttpPost("StripeCharges")]
        public async Task<IActionResult> StripeCharges(StripeTransactionEntity e)
            => Ok(await _service.StripeCharges(e));

        [HttpPost("StripeConnectRefund")]
        public async Task<IActionResult> Refund(string chargeId)
            => Ok(await _service.StripeRefund(chargeId));

        [HttpPost("CreateStripeConnectAccount")]
        public async Task<IActionResult> CreateAccount(StripeConnectAccountEntity e)
            => Ok(await _service.CreateStripeConnectAccount(e));

        [HttpGet("CheckStripeAccount")]
        public async Task<IActionResult> Check(string shopId)
            => Ok(await _service.CheckStripeAccount(shopId));

        [HttpGet("GetStripeConnectPlatFormDetails")]
        public async Task<IActionResult> Platform()
            => Ok(await _service.GetStripePlatform());

        [HttpGet("GetStripeConnectTransactionReportsToday")]
        public async Task<IActionResult> Today()
            => Ok(await _service.GetTodayReport());

        [HttpGet("GetStripeConnectTransactionReportsWeekly")]
        public async Task<IActionResult> Weekly()
            => Ok(await _service.GetWeeklyReport());

        [HttpGet("GetStripeConnectTransactionReportsMonthly")]
        public async Task<IActionResult> Monthly()
            => Ok(await _service.GetMonthlyReport());

        [HttpGet("GetStripeConnectTransactionReportsYearly")]
        public async Task<IActionResult> Yearly()
            => Ok(await _service.GetYearlyReport());

        [HttpPut("UpdateStripeConnectAccountStatus")]
        public async Task<IActionResult> UpdateStripeConnectAccountStatus(string shopId,int status)
        {
            var result =
                await _service.UpdateStripeAccountStatus(shopId, status);

            return Ok(result);
        }
    }
}
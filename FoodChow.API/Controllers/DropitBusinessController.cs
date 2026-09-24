using FoodChow.Application.DTOs;
using FoodChow.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodChow.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class DropitBusinessController : ControllerBase
    {
        private readonly HealthService _healthService;
        private readonly MetaService _metaService;
        private readonly FareEstimateService _fareEstimateService;
        private readonly RiderAvailabilityService _riderAvailabilityService;
        private readonly OrderCreateService _orderCreateService;
        private readonly OrderCancelService _orderCancelService;
        private readonly OrderTrackService _orderTrackService;
        private readonly WalletBalanceService _walletBalanceService;

        public DropitBusinessController(
            HealthService healthService,
            MetaService metaService,
            FareEstimateService fareEstimateService,
            RiderAvailabilityService riderAvailabilityService,
            OrderCreateService orderCreateService,
            OrderCancelService orderCancelService,
            OrderTrackService orderTrackService,
            WalletBalanceService walletBalanceService)
        {
            _healthService = healthService;
            _metaService = metaService;
            _fareEstimateService = fareEstimateService;
            _riderAvailabilityService = riderAvailabilityService;
            _orderCreateService = orderCreateService;
            _orderCancelService = orderCancelService;
            _orderTrackService = orderTrackService;
            _walletBalanceService = walletBalanceService;
        }

        // ---- Health ----
        [HttpGet("health-check")]
        public async Task<IActionResult> HealthCheck([FromHeader(Name = "x-api-key")] string? apiKey)
        {
            var result = await _healthService.CheckHealthAsync(apiKey);
            return StatusCode(result.Status, result);
        }

        // ---- Meta ----
        [HttpPost("orders/checkAreaServiceability/batch")]
        public async Task<IActionResult> CheckAreaServiceabilityBatch([FromBody] AreaServiceabilityBatchRequestDto request)
        {
            var result = await _metaService.CheckAreaServiceabilityBatchAsync(request);
            return StatusCode(result.Status, result);
        }

        [HttpGet("meta-types")]
        public async Task<IActionResult> GetMetaTypes()
        {
            var result = await _metaService.GetMetaTypesAsync();
            return StatusCode(result.Status, result);
        }

        // ---- Fare Estimate ----
        [HttpPost("fare-estimate")]
        public async Task<IActionResult> EstimateFare([FromBody] FareEstimateRequestDto request)
        {
            var result = await _fareEstimateService.EstimateFareAsync(request);
            return StatusCode(result.Status, result);
        }

        // ---- Rider Availability ----
        [HttpPost("rider-availability")]
        public async Task<IActionResult> CheckRiderAvailability([FromBody] RiderAvailabilityRequestDto request)
        {
            var result = await _riderAvailabilityService.CheckAvailabilityAsync(request);
            return StatusCode(result.Status, result);
        }

        // ---- Orders: Create / Cancel / Track ----
        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
        {
            var result = await _orderCreateService.CreateOrderAsync(request);
            return StatusCode(result.Status, result);
        }

        [HttpPost("orders/{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(string orderId, [FromBody] CancelOrderRequestDto request)
        {
            var result = await _orderCancelService.CancelOrderAsync(orderId, request);
            return StatusCode(result.Status, result);
        }

        [HttpGet("orders/{orderId}/track")]
        public async Task<IActionResult> TrackOrder(string orderId)
        {
            var result = await _orderTrackService.TrackOrderAsync(orderId);
            return StatusCode(result.Status, result);
        }

        // ---- Wallet ----
        [HttpGet("getWalletBalance")]
        public async Task<IActionResult> GetWalletBalance([FromHeader(Name = "x-api-key")] string? apiKey)
        {
            var result = await _walletBalanceService.GetWalletBalanceAsync(apiKey);
            return StatusCode(result.Status, result);
        }
    }
}
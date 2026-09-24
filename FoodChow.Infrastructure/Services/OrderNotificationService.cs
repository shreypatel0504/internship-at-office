using FoodChow.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FoodChow.Infrastructure.Services
{
    public class OrderNotificationService : IOrderNotificationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly ILogger<OrderNotificationService> _logger;

        public OrderNotificationService(IHttpClientFactory httpClientFactory, IConfiguration config, ILogger<OrderNotificationService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _logger = logger;
        }

        public async Task SendShopDevicePushAsync(string deviceToken, int deviceType, string message, long shopId, string orderId)
        {
            var baseUrl = _config["NotificationSettings:BaseUrl"];
            var pushPath = _config["NotificationSettings:PushRmsUrlMulti"];
            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(pushPath)) { _logger.LogWarning("Shop push skipped. OrderId={OrderId}", orderId); return; }
            await SafeGetAsync($"{baseUrl}{pushPath}?devicetoken={deviceToken}&devicetype={deviceType}&message={Uri.EscapeDataString(message)}&isorder=1&shopid={shopId}&order_id={orderId}&title=Order Received", "shop push");
        }

        public async Task SendPosDevicePushAsync(string message, long shopId, string orderId)
        {
            var baseUrl = _config["NotificationSettings:BaseUrl"];
            var pushPath = _config["NotificationSettings:PushPosUrlMulti"];
            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(pushPath)) { _logger.LogWarning("POS push skipped. OrderId={OrderId}", orderId); return; }
            await SafeGetAsync($"{baseUrl}{pushPath}?message={Uri.EscapeDataString(message)}&isorder=1&shopid={shopId}&order_id={orderId}&title=Order Received", "POS push");
        }

        public async Task SendWhatsAppNewOrderNotificationAsync(string orderId)
        {
            await SafeGetAsync($"https://api.foodchow.com/api/MenuMaster/SendWhatsAppMessageForNewOrderReceived?order_id={orderId}", "WhatsApp");
        }

        public Task SendSmsAsync(string message, string mobileNo)
        {
            _logger.LogInformation("SMS placeholder. To={Mobile}", mobileNo);
            return Task.CompletedTask;
        }

        private async Task SafeGetAsync(string url, string description)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) _logger.LogWarning("{Desc} returned {Status}", description, response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "{Desc} failed", description);
            }
        }
    }
}
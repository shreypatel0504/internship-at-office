using FoodChow.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace FoodChow.Infrastructure.Services
{
    public class OrderEmailService : IOrderEmailService
    {
        private readonly ILogger<OrderEmailService> _logger;

        public OrderEmailService(ILogger<OrderEmailService> logger)
        {
            _logger = logger;
        }

        public Task SendOrderEmailAsync(string orderId, string finalAmount, string currency, string logoUrl, string baseUrl, string? otherEmail, long emailNotifyEnable, long emailNotifyCustomer, string sendMailFrom, string whiteLabelBrandName, string defaultMailLanguage, int decimalPoint)
        {
            _logger.LogInformation("Order email placeholder fired. OrderId={OrderId}", orderId);
            return Task.CompletedTask;
        }
    }
}
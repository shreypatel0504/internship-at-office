using System;

namespace FoodChow.Domain.Entities
{
    public class PaymentConfiguration
    {
        public int Id { get; set; }

        // Link to shop/restaurant
        public int ShopId { get; set; }

        // Payment provider name (Stripe, Razorpay, PayPal, etc.)
        public string ProviderName { get; set; } = string.Empty;

        // Public API Key / Key ID
        public string? ApiKey { get; set; }

        // Secret Key / API Secret (store encrypted if possible)
        public string? ApiSecret { get; set; }

        // Merchant/Account ID if required by provider
        public string? MerchantId { get; set; }

        // Currency (INR, USD, etc.)
        public string Currency { get; set; } = "INR";

        // Is this payment method enabled for shop
        public bool IsActive { get; set; } = true;

        // Optional mode (Test / Live)
        public string Mode { get; set; } = "Test";

        // Extra configuration in JSON format (flexible for future updates)
        public string? ExtraConfig { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
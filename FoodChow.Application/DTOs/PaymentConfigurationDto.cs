using System;

namespace FoodChow.Application.DTOs
{
    // CREATE DTO
    public class CreatePaymentConfigurationDto
    {
        public int ShopId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? ApiKey { get; set; }
        public string? ApiSecret { get; set; }
        public string? MerchantId { get; set; }
        public string Currency { get; set; } = "INR";
        public string Mode { get; set; } = "Test";
        public string? ExtraConfig { get; set; }
    }

    // UPDATE DTO
    public class UpdatePaymentConfigurationDto
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? ApiKey { get; set; }
        public string? ApiSecret { get; set; }
        public string? MerchantId { get; set; }
        public string Currency { get; set; } = "INR";
        public string Mode { get; set; } = "Test";
        public string? ExtraConfig { get; set; }
        public bool IsActive { get; set; }
    }

    // RESPONSE DTO
    public class PaymentConfigurationDto
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? ApiKey { get; set; }
        public string? MerchantId { get; set; }
        public string Currency { get; set; } = "INR";
        public string Mode { get; set; } = "Test";
        public string? ExtraConfig { get; set; }
        public bool IsActive { get; set; }
    }
}
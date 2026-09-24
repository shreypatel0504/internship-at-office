namespace FoodChow.Application.Interfaces
{
    public interface IShopTimeZoneService
    {
        Task<DateTime> GetShopLocalTimeAsync(long shopId);
    }

    public interface IShopCurrencyService
    {
        Task<string> GetShopCurrencyByIdAsync(string shopId);
    }

    public interface IOrderNotificationService
    {
        Task SendShopDevicePushAsync(string deviceToken, int deviceType, string message, long shopId, string orderId);
        Task SendPosDevicePushAsync(string message, long shopId, string orderId);
        Task SendWhatsAppNewOrderNotificationAsync(string orderId);
        Task SendSmsAsync(string message, string mobileNo);
    }

    public interface IOrderEmailService
    {
        Task SendOrderEmailAsync(string orderId, string finalAmount, string currency, string logoUrl, string baseUrl, string? otherEmail, long emailNotifyEnable, long emailNotifyCustomer, string sendMailFrom, string whiteLabelBrandName, string defaultMailLanguage, int decimalPoint);
    }
}
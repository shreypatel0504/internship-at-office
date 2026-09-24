using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IWhatsappRepository
    {
        Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaigns();
        Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaignByShop(string shopId);
        Task<long> AddCampaign(WhatsAppCampaignEntity e);
        Task<int> UpdateCampaign(WhatsAppCampaignEntity model);
        Task<int> DeleteCampaign(int id);

        Task<IEnumerable<WhatsAppNotificationNumberEntity>> GetNotificationNumbers(string shopId);
        Task<long> AddNotificationNumber(WhatsAppNotificationNumberEntity e);
        Task<int> DeleteNotificationNumber(int id);

        Task<IEnumerable<WhatsAppWebhookEntity>> GetWebhookLogs();
        Task<long> AddWebhookLog(WhatsAppWebhookEntity e);

        Task<IEnumerable<ShopWhatsAppSummaryEntity>> GetShopWhatsAppSummary(string shopId);
        Task<IEnumerable<TableWhatsAppSummaryEntity>> GetTableWhatsAppSummary(string shopId);
    }
}
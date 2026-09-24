using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class WhatsAppMasterService
    {
        private readonly IWhatsappRepository _repo;

        public WhatsAppMasterService(IWhatsappRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaigns()
            => _repo.GetCampaigns();

        public Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaignByShop(string shopId)
            => _repo.GetCampaignByShop(shopId);

        public Task<long> AddCampaign(WhatsAppCampaignEntity e)
            => _repo.AddCampaign(e);

        public Task<int> UpdateCampaign(WhatsAppCampaignEntity model)
            => _repo.UpdateCampaign(model);

        public Task<int> DeleteCampaign(int id)
            => _repo.DeleteCampaign(id);

        public Task<IEnumerable<WhatsAppNotificationNumberEntity>> GetNotificationNumbers(string shopId)
            => _repo.GetNotificationNumbers(shopId);

        public Task<long> AddNotificationNumber(WhatsAppNotificationNumberEntity e)
            => _repo.AddNotificationNumber(e);

        public Task<int> DeleteNotificationNumber(int id)
            => _repo.DeleteNotificationNumber(id);

        public Task<IEnumerable<WhatsAppWebhookEntity>> GetWebhookLogs()
            => _repo.GetWebhookLogs();

        public Task<long> AddWebhookLog(WhatsAppWebhookEntity e)
            => _repo.AddWebhookLog(e);

        public Task<IEnumerable<ShopWhatsAppSummaryEntity>> GetShopWhatsAppSummary(string shopId)
            => _repo.GetShopWhatsAppSummary(shopId);

        public Task<IEnumerable<TableWhatsAppSummaryEntity>> GetTableWhatsAppSummary(string shopId)
            => _repo.GetTableWhatsAppSummary(shopId);
    }
}
using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using Microsoft.IdentityModel.Logging;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class WhatsappRepository : IWhatsappRepository
    {
        private readonly MySqlDalc _dalc;

        public WhatsappRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaigns()
            => await _dalc.CreateConnection().QueryAsync<WhatsAppCampaignEntity>("USP_GetCampaigns",
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<WhatsAppCampaignEntity>> GetCampaignByShop(string shopId)
            => await _dalc.CreateConnection().QueryAsync<WhatsAppCampaignEntity>(
                "USP_GetCampaignByShop",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddCampaign(WhatsAppCampaignEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddCampaign",
                new
                {
                   p_shop_id= e.ShopId,
                    p_campaign_name=e.CampaignName,
                    p_reward_type=e.RewardType,
                    p_customer_reward=e.CustomerReward,
                    p_referrer_reward=e.ReferrerReward,
                    p_min_purchase=e.minPur

                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> UpdateCampaign(WhatsAppCampaignEntity model)
    => await _dalc.CreateConnection().ExecuteAsync(
        "USP_UpdateCampaign",
        new
        {
            p_campaign_id = model.Id,
            p_campaign_name = model.CampaignName,
            p_reward_type = model.RewardType,
            p_customer_reward = model.CustomerReward,
            p_referrer_reward = model.ReferrerReward
        },
        commandType: CommandType.StoredProcedure);

        public async Task<int> DeleteCampaign(int id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteCampaign",
                new { p_campaign_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<WhatsAppNotificationNumberEntity>> GetNotificationNumbers(string shopId)
            => await _dalc.CreateConnection().QueryAsync<WhatsAppNotificationNumberEntity>(
                "USP_GetNotificationNumbers",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddNotificationNumber(WhatsAppNotificationNumberEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddNotificationNumber",
                new
                {
                    p_shop_id = e.ShopId,
                    p_notification_no = e.NotificationNo,
                    p_country_code = e.CountryCode
                },
                commandType: CommandType.StoredProcedure);

        public async Task<int> DeleteNotificationNumber(int id)
            => await _dalc.CreateConnection().ExecuteAsync(
                "USP_DeleteNotificationNumber",
                new { p_id = id },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<WhatsAppWebhookEntity>> GetWebhookLogs()
            => await _dalc.CreateConnection().QueryAsync<WhatsAppWebhookEntity>(
                "USP_GetWebhookLogs",
                commandType: CommandType.StoredProcedure);

        public async Task<long> AddWebhookLog(WhatsAppWebhookEntity e)
            => await _dalc.CreateConnection().ExecuteScalarAsync<long>(
                "USP_AddWebhookLog",
                new
                {
                    p_success_response = e.SuccessResponse,
                    p_message_id = e.MessageId,
                    p_whatsapp_response = e.WhatsappResponse,
                    p_element_type = e.ElementType,
                    p_phone_number = e.PhoneNumber,
                    p_name = e.Name
                },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ShopWhatsAppSummaryEntity>> GetShopWhatsAppSummary(string shopId)
            => await _dalc.CreateConnection().QueryAsync<ShopWhatsAppSummaryEntity>(
                "USP_GetShopWhatsAppSummary",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<TableWhatsAppSummaryEntity>> GetTableWhatsAppSummary(string shopId)
            => await _dalc.CreateConnection().QueryAsync<TableWhatsAppSummaryEntity>(
                "USP_GetTableWhatsAppSummary",
                new { p_shop_id = shopId },
                commandType: CommandType.StoredProcedure);
    }
}
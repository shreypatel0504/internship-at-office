namespace FoodChow.Domain.Entities
{
    public class WhatsAppCampaignEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }        
        public int Status { get; set; }
        public string NotificationType { get; set; }
        public string CampaignName { get; set; }
        public string RewardType { get; set; }
        public string CustomerReward { get; set; }
        public string ReferrerReward { get; set; }
        public int minPur { get; set; }
    }
    public class WhatsAppWebhookEntity
    {
        public int Id { get; set; }
        public string SuccessResponse { get; set; }
        public string MessageId { get; set; }
        public string WhatsappResponse { get; set; }
        public string ElementType { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
    public class ShopWhatsAppSummaryEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string OrderId { get; set; }
        public string SuccessResponse { get; set; }
        public string WhatsappResponse { get; set; }
        public string MessageId { get; set; }
        public string ElementType { get; set; }
    }
    public class TableWhatsAppSummaryEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string TableId { get; set; }
        public string SuccessResponse { get; set; }
        public string WhatsappResponse { get; set; }
        public string MessageId { get; set; }
        public string ElementType { get; set; }
    }
    
    public class WhatsAppNotificationNumberEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string NotificationNo { get; set; }
        public string CountryCode { get; set; }
        public int Status { get; set; }
    }
    
}